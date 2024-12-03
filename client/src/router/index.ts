import { createRouter, createWebHistory } from 'vue-router';

import { authRoutes } from '@/modules/auth/routes';
import { settingRoutes } from '@/modules/settings/router';
import RootLayout from '@/modules/common/layouts/RootLayout.vue';
import NotFoundView from '@/modules/common/views/NotFoundView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'root',
      redirect: { name: 'home' },
      component: RootLayout,
      children: [
        {
          path: 'home',
          name: 'home',
          component: () => import('@/modules/home/views/HomeView.vue'),
        },
        {
          path: 'profile/:user',
          name: 'profile',
          component: () => import('@/modules/profiles/views/ProfileView.vue'),
        },
      ],
    },
    authRoutes,
    settingRoutes,
    {
      path: '/:pathMatch(.*)*',
      name: 'not-found',
      component: NotFoundView,
    },
  ],
});

export default router;
