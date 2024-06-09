import { useParams } from "react-router-dom";
import { useEffect, useState } from "react";

import { ConferenceToken } from "../../app/models/conferenceToken";
import LoadingComponent from "../../app/layout/LoadingComponent";
import { useNavigate } from 'react-router-dom';
import agent from "../../app/api/agent";
import '@livekit/components-styles';
import { LiveKitRoom, MediaDeviceMenu, VideoConference } from "@livekit/components-react";

export default function SessionView() {
    const [data, setData] = useState<ConferenceToken | null>(null);
    const [loading, setLoading] = useState<boolean>(true);
    const {room} = useParams();
    const navigate = useNavigate();

    useEffect(() => {
      const fetchData = async () => {
        try {
          const response = await agent.Token.details(room!);
          setData(response);
          setLoading(false);
        } catch (error) {
          console.error('Error fetching data: ', error);
          setLoading(false);
        }
      };
  
      fetchData();
    }, []);
    const onLeave = () => {
        navigate('/');
      };
    if (loading) {
      return <LoadingComponent content="Wait while the Session begins" />
    }
  
    if (!data) {
      return <div>No data available</div>; // Or handle the error in another way
    }
  
    return (
        <LiveKitRoom 
            video={true}
            audio={true}
            token={data.token}
            serverUrl={data.url}
            connect={true}
            onDisconnected={onLeave}
            data-lk-theme="default">
                <VideoConference />
                <MediaDeviceMenu />
      </LiveKitRoom>
    );
}
