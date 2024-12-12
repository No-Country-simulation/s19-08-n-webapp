import { isAxiosError } from 'axios';
import freeConnectApi from '@/apis/free-connect.api';
import type { IRegisterRequestData } from '../interfaces';

export const register = async (data: IRegisterRequestData): Promise<void> => {
  try {
    const { status } = await freeConnectApi.post<string>('/Auth/register', data);

    if (status !== 200) {
      throw new Error('auth.common.generic_messages.error.went_wrong');
    }

    return;
  } catch (error) {
    if (isAxiosError(error) && error.response?.status === 400) {
      if (error.response.data[''][0] === `Username '${data.username}' is already taken.`) {
        throw new Error('auth.register.toast_messages.error.username_taken');
      } else {
        throw new Error('auth.common.generic_messages.error.field_error');
      }
    } else if (error instanceof Error) {
      throw error;
    } else {
      throw new Error('auth.common.generic_messages.error.server_error');
    }
  }
};
