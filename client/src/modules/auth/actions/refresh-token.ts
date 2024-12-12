import { isAxiosError } from 'axios';
import freeConnectApi from '@/apis/free-connect.api';
import type { IRefreshTokenRequestData, IRefreshTokenResponseData } from '../interfaces';

export const refreshToken = async (
  data: IRefreshTokenRequestData,
): Promise<IRefreshTokenResponseData> => {
  try {
    const res = await freeConnectApi.post<IRefreshTokenResponseData>('/Auth/refresh', data);

    if (res.status !== 200) {
      throw new Error('auth.common.generic_messages.error.went_wrong');
    }

    return res.data;
  } catch (error) {
    if (isAxiosError(error) && (error.response?.status === 401 || error.response?.status === 400)) {
      throw new Error('auth.refresh_token.toast_messages.error.expired');
    } else if (error instanceof Error) {
      throw error;
    } else {
      throw new Error('auth.common.generic_messages.error.server_error');
    }
  }
};
