import { isAxiosError } from 'axios';
import freeConnectApi from '@/apis/free-connect.api';
import type { ILoginRequestData, ILoginResponseData } from '../interfaces';

export const login = async (data: ILoginRequestData): Promise<ILoginResponseData> => {
  try {
    const res = await freeConnectApi.post<ILoginResponseData>('/Auth/login', data);

    if (res.status !== 200) {
      throw new Error('auth.common.generic_messages.error.went_wrong');
    }

    return res.data;
  } catch (error) {
    if (isAxiosError(error) && (error.response?.status === 401 || error.response?.status === 400)) {
      throw new Error('auth.login.toast_messages.error.credentials');
    } else if (error instanceof Error) {
      throw error;
    } else {
      throw new Error('auth.common.generic_messages.error.server_error');
    }
  }
};
