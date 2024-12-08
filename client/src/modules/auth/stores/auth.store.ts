import { defineStore } from 'pinia';
import { login } from '../actions/login';
import type { LoginData } from '../interfaces/userInterfaces';

export const useAuthStore = defineStore('auth', {
  state: () => ({
    user: null,
    token: null,
  }),

  actions: {
    async loginAction(data: LoginData) {
      try {
        const response = await login(data);
        console.log('Respuesta del login:', response);

        this.token = response.token;
        this.user = response.user;
      } catch (error: any) {
        console.error('Error en el login:', error.response?.data || error.message);
        throw error;
      }
    },
  },
});
