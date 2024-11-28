import type { RouteRecordRaw } from 'vue-router';

export const settingRoutes: RouteRecordRaw = {
  path: '/settings',
  name: 'settings',
  component: () => import('@/modules/settings/layouts/SettingsLayout.vue'),
  children: [
    {
      path: '',
      name: 'general',
      component: () => import('@/modules/settings/views/GeneralView.vue'),
    },
    {
      path: 'account',
      name: 'account',
      component: () => import('@/modules/settings/views/AccountView.vue'),
    },
  ],
};
