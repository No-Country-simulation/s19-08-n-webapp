import { computed, ref } from 'vue';
import { defineStore } from 'pinia';
import { useRouter } from 'vue-router';
import { useToast } from 'vue-toastification';
import { useLocalStorage } from '@vueuse/core';

import i18n from '@/i18n';

import { AuthStatus } from '../enums';
import { delay } from '@/modules/common/utils';
import { login, register, refreshToken } from '../actions';
import type { IUser, ILoginRequestData, IRegisterRequestData } from '../interfaces';

export const useAuthStore = defineStore('auth', () => {
  const toast = useToast();
  const router = useRouter();

  const user = ref<IUser>();
  const token = useLocalStorage('token', '', { writeDefaults: false });
  const status = ref<AuthStatus>(AuthStatus.Checking);

  const profileImg = computed(() => {
    return user.value
      ? `https://avatars.jakerunzer.com/${user.value.userName}`
      : 'https://upload.wikimedia.org/wikipedia/commons/7/7c/Profile_avatar_placeholder_large.png';
  });

  const startLogin = async (data: ILoginRequestData): Promise<void> => {
    try {
      await delay(1);
      const loginData = await login(data);

      user.value = loginData.user;
      token.value = loginData.token;
      status.value = AuthStatus.Authenticated;

      router.replace({ name: 'home' });
      toast.success(i18n.global.t('auth.login.toast_messages.success.login'));
    } catch (error) {
      startLogout();
      toast.error(i18n.global.t((error as Error).message));
    }
  };

  const startRegister = async (data: IRegisterRequestData): Promise<void> => {
    try {
      await delay(1);
      await register(data);
      router.replace({ name: 'login' });
      toast.success(i18n.global.t('auth.register.toast_messages.success.registered'));
    } catch (error) {
      startLogout();
      toast.error(i18n.global.t((error as Error).message, { username: data.username }));
    }
  };

  const startLogout = () => {
    user.value = undefined;
    token.value = undefined;
    status.value = AuthStatus.Unauthenticated;
  };

  const startRefreshToken = async (): Promise<void> => {
    if (!token.value || token.value.length === 0) {
      startLogout();
      return;
    }

    status.value = AuthStatus.Checking;

    try {
      await delay(1.5);
      const refreshTokenData = await refreshToken({ token: token.value });

      user.value = refreshTokenData.user;
      token.value = refreshTokenData.token;
      status.value = AuthStatus.Authenticated;
    } catch (error) {
      startLogout();
      toast.error(i18n.global.t((error as Error).message));
    }
  };

  return {
    // Properties
    user,
    token,
    status,

    // Getters
    profileImg,
    isChecking: computed(() => status.value === AuthStatus.Checking),
    isAuthenticated: computed(() => status.value === AuthStatus.Authenticated),
    isUnauthenticated: computed(() => status.value === AuthStatus.Unauthenticated),

    // Actions
    startLogin,
    startLogout,
    startRegister,
    startRefreshToken,
  };
});
