import axios, { AxiosResponse } from 'axios';
import { Activity } from '../models/activity';
import { ConferenceToken } from '../models/conferenceToken';

axios.defaults.baseURL="http://localhost:5000/rehub";
axios.interceptors.response.use(async response => {
    try {
        await sleep(1000);
        return response;
    }
    catch(error) {
        console.log(error);
        return await Promise.reject(error);
    }
}

)
const responseBody = <T>(response: AxiosResponse<T>)=> response.data;

const requests = {
    get:<T> (url: string) => axios.get<T>(url).then(responseBody),
    post:<T> (url: string, body: {}) => axios.post<T>(url, body).then(responseBody),
    put:<T> (url: string, body: {}) => axios.put<T>(url, body).then(responseBody),
    delete:<T> (url: string) => axios.delete<T>(url).then(responseBody),
}

const Activities = {
    list: () => requests.get<Activity[]>('/my-appointments'),
    details: (id:number) =>requests.get<Activity>(`/appointments/${id}`)
}
const Token ={
    details:(room:string)=>requests.get<ConferenceToken>(`/get_livekit-token?room=${room}`)
}

const agent = {
    Activities,
    Token
}
export default agent;

function sleep(delay: number) {
    return new Promise((resolve)=>{
        setTimeout(resolve,delay);
    })
}
