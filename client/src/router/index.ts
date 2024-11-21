import { createRouter, createWebHistory } from 'vue-router';

import { authRoutes } from '@/modules/auth/routes';
import RootLayout from '@/modules/common/layouts/RootLayout.vue';
import NotFoundView from '@/modules/common/views/NotFoundView.vue';

const router = createRouter({
  history: createWebHistory(import.meta.env.BASE_URL),
  routes: [
    {
      path: '/',
      name: 'root',
      component: RootLayout,
      children: [
        {
          path: '',
          name: 'home',
          component: () => import('@/modules/home/views/HomeView.vue'),
        },
      ],
    },
    authRoutes,
    {
      path: '/:pathMatch(.*)*',
      name: 'not-found',
      component: NotFoundView,
    },
  ],
});

export default router;
