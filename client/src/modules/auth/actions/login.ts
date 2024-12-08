import freeConectApi from '@/apis/freeConect.api';
import type { LoginData } from '../interfaces/userInterfaces';

export const login = async (data: LoginData) => {
  try {
    console.log('Datos enviados al login:', data);

    const response = await freeConectApi.post('/api/Auth/login', data);

    console.log('Respuesta del servidor:', response.data);

    return response.data;
  } catch (error: any) {
    console.error('Error en el login:', error.response?.data || error.message);
    throw error;
  }
};
