import { defineStore } from 'pinia';
import { login, register } from '../actions/login';

import type { LoginData } from '../interfaces/userInterfaces';
import type { RegisterData } from '../interfaces/registerData';

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

    async registroAction(data: RegisterData) {
      try {
        const response = await register(data);
        console.log('Respuesta del registro:', response);

        this.token = response.token;
        this.user = response.user;
      } catch (error: any) {
        console.error('Error en el registro:', error.response?.data || error.message);
        throw error;
      }
    },
  },
});
