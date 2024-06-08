import { observer } from "mobx-react-lite";
import { Grid } from "semantic-ui-react";
import ActivityList from "./ActivityList";
import { useStore } from "../../../app/stores/store";
import { useEffect } from "react";
import LoadingComponent from "../../../app/layout/LoadingComponent";

export default observer(function ActivityDashboard() {
    const {activityStore} = useStore();

    useEffect(()=>{
        activityStore.loadActivities();
    }, [])

    if(activityStore.loadingInitial) return <LoadingComponent content="Loading App" />

  return (
    <Grid>
      <Grid.Column width="10">
        <ActivityList />
      </Grid.Column>
    </Grid>
  )
})
