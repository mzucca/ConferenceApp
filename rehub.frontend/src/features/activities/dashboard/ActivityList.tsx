import { Button, Item, Label, Segment } from "semantic-ui-react";
import { useStore } from "../../../app/stores/store";
import { Activity } from "../../../app/models/activity";
import { Link } from "react-router-dom";
import { observer } from "mobx-react-lite";


export default observer(function ActivityList(){
    const {activityStore} = useStore();
    const{activitiesByDate,loading}=activityStore;
    return (
        <Segment>
            <Item.Group divided>
                {activityStore.activitiesByDate.map((activity: Activity) => (
                    <Item key={activity.id}>
                        <Item.Content>
                            <Item.Header as='a'>{activity.name}</Item.Header>
                            <Item.Meta>{activity.date}</Item.Meta>
                            <Item.Extra>
                                <Button as={Link} to={`/sessions/${activity.name}`} floated="right" content="Join" color='blue' />
                                <Label basic content={activity.district} />
                            </Item.Extra>
                        </Item.Content>

                    </Item>
                ))}
            </Item.Group>
        </Segment>
    )
})