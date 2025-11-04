import type { BaseEntity } from "./common.types";


export interface User extends BaseEntity {
    email: string;
    firstName: string;
    lastName: string;
    role: 'admin' | 'teacher' | 'parent' | 'health_staff';
    phoneNumber?: string;
    avatarUrl?: string;
    isActive: boolean;
}

export interface LoginRequest{
    email: string;
    password: string;
}

export interface RegisterRequest{
    email: string;
    password: string;
    firstName: string;
    lastName: string;
    role: string;
    phoneNumber?: string;
}