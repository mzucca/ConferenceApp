import { Role } from "./roles";

export interface User {
    username: string;
    displayName: string;
    token: string;
    roles: Role[],
    image?: string;
    role: string;
}

export interface OauthToken {
    provider: string;
    token: string;
}

export interface UserFormValues {
    email: string;
    password: string;
    displayName?: string;
    username?: string;
}