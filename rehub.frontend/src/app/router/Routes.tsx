import { createBrowserRouter, RouteObject } from "react-router-dom";
import App from "../layout/App";
import HomePage from "../../features/activities/dashboard/home/HomePage";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import SessionView from "../../features/activities/dashboard/conference/SessionView";

export const routes: RouteObject[] = [
    {
        path: '/',
        element: <App/>,
        children:[
            {path:'', element: <HomePage />},
            {path:'sessions', element: <ActivityDashboard />},
            {path:'sessions/:id', element: <SessionView />},
            //{path:'', element:<HomePage />},
        ]
    }
]
export const router = createBrowserRouter(routes);