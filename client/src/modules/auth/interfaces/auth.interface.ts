import type { IUser } from './user.interface';

export interface ILoginRequestData {
  username: string;
  password: string;
}

export interface ILoginResponseData {
  token: string;
  user: IUser;
}

export interface IRegisterRequestData {
  firstName: string;
  lastName: string;
  username: string;
  email: string;
  password: string;
}

export interface IRefreshTokenRequestData {
  token: string;
}

export interface IRefreshTokenResponseData {
  token: string;
  user: IUser;
}
