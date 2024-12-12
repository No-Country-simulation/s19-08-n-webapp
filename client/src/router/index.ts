import { createRouter, createWebHistory } from 'vue-router';

import { authRoutes } from '@/modules/auth/routes';
import { settingRoutes } from '@/modules/settings/router';
import { useAuthStore } from '@/modules/auth/stores/auth.store';
import MainLayout from '@/modules/common/layouts/MainLayout.vue';
import NotFoundView from '@/modules/common/views/NotFoundView.vue';
import isAuthenticatedGuard from '@/modules/auth/guards/is-authenticated.guard';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'main',
      redirect: { name: 'home' },
      component: MainLayout,
      children: [
        {
          path: 'home',
          name: 'home',
          component: () => import('@/modules/home/views/HomeView.vue'),
        },
        {
          path: 'profile/:user',
          name: 'profile',
          beforeEnter: [isAuthenticatedGuard],
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

router.beforeEach(async (_, __, next) => {
  const authStore = useAuthStore();
  if (authStore.isChecking) await authStore.startRefreshToken();
  next();
});

export default router;
