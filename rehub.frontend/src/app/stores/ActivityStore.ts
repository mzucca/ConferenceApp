import { makeAutoObservable, runInAction } from "mobx";
import { Activity } from "../models/activity";
import agent from "../api/agent";

export default class ActivityStore {
    activityRegistry = new Map<number,Activity>();
    selectedActivity: Activity | undefined = undefined;
    editMode = false;
    loading = false;
    loadingInitial = true;

    constructor(){
        makeAutoObservable(this);
    }
    get activitiesByDate() {
        return Array.from(this.activityRegistry.values())
            .sort((a,b) =>Date.parse(a.date)-Date.parse(b.date));
    }
    loadActivities = async () => {
        try{
            if(this.loadingInitial){
                const activities = await agent.Activities.list();
                activities.forEach(activity => {
                    this.setActivity(activity);
                });    
            }
            this.setLoadingInitial(false);
        } catch(error) {
            console.log(error);
            this.setLoadingInitial(false);
        }
    }
    loadActivity = async (id:number)=>{
        let activity = this.getActivity(id);
        if(activity) this.selectedActivity=activity;
        else{
            this.setLoadingInitial(true);
            try{
                activity = await agent.Activities.details(id);
                this.setActivity(activity);
                this.setLoadingInitial(false);
            } catch(error) {
                console.log(error);
                this.setLoadingInitial(false);
            }
        }
    }
    private setActivity = (activity:Activity) => {
        activity.date = activity.date.split('T')[0];
         this.activityRegistry.set(activity.id,activity);                    
    }
    private getActivity = (id:number)=>{
        return this.activityRegistry.get(id);
    }
    // This is an action otherwise you need runInAction()
    setLoadingInitial = (state: boolean) => {
        this.loadingInitial = state;
    }

    selectActivity = (id: number) => {
        this.selectedActivity = this.activityRegistry.get(id);
    }

    cancelSelectedActivity = () =>{
        this.selectedActivity = undefined;
    }
}