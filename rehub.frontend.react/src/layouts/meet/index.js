import React from "react";
import useAxios, { configure } from "axios-hooks";

import "@livekit/components-styles";
import { VideoConference, LiveKitRoom, ControlBar } from "@livekit/components-react";
import config from "config";

//const serverUrl = "wss://marioz-test-geie7rrs.livekit.cloud";
//const token =
//  "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJleHAiOjE3MTc1MTYyOTYsImlzcyI6IkFQSWNBanZpODlYZkVBZyIsIm5hbWUiOiJtYXJpb3oiLCJuYmYiOjE3MTcyNTcwOTYsInN1YiI6Im1hcmlveiIsInZpZGVvIjp7InJvb20iOiJteS1maXJzdC1yb29tIiwicm9vbUpvaW4iOnRydWV9fQ.wi45c6cafbUKa73fnEg_98_GX6XlvhqtVHrkrYRGiYQ";
let endPoint = "http://localhost:5008/rehub/get_livekit-token?user=marioz1&room=room1'";

export default function Meet() {
  const [{ data, loading, error }, refetch] = useAxios(endPoint);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error!</p>;
  return (
    <LiveKitRoom video={true} audio={true} token={data.token} serverUrl={data.url} connect={true}>
      <VideoConference />
    </LiveKitRoom>
  );
}
