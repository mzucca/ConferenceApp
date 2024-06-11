import { Segment, List, Label, Item, Image } from 'semantic-ui-react'
import { Link } from 'react-router-dom'
import { observer } from 'mobx-react-lite'
import { Activity } from '../../../app/models/activity'
import { useTranslation } from 'react-i18next'

interface Props {
    activity: Activity
}

export default observer(function ActivityDetailedSidebar ({activity: {attendees, host}}: Props) {
    
    const {t} = useTranslation();

    if (!attendees) return null;


    return (
        <>
            <Segment
                textAlign='center'
                style={{ border: 'none' }}
                attached='top'
                secondary
                inverted
                color='teal'
            >
               {attendees.length === 1 ? t('one_attendant') : t('more_attendant', {people : attendees.length})}
            </Segment>
            <Segment attached>
                <List relaxed divided>
                    {attendees.map(attendee => (
                        <Item key={attendee.username} style={{ position: 'relative' }}>
                            {attendee.username === host?.username &&
                            <Label
                                style={{ position: 'absolute' }}
                                color='orange'
                                ribbon='right'
                            >
                                {t('doctor')}
                            </Label>}
                            <Image size='tiny' src={'/assets/user.png'} />
                            <Item.Content verticalAlign='middle'>
                                <Item.Header as='h3'>
                                    <Link to={`/profiles/${attendee.username}`}>{attendee.displayName}</Link>
                                </Item.Header>
                                {attendee.following &&
                                <Item.Extra style={{ color: 'orange' }}>Following</Item.Extra>}
                            </Item.Content>
                        </Item>
                    ))}
                </List>
            </Segment>
        </>

    )
})
