<script setup lang="ts">
import { useRouter } from 'vue-router';

import {
  BellIcon,
  LogInIcon,
  LogOutIcon,
  SearchIcon,
  SettingsIcon,
  CircleUserRoundIcon,
} from 'lucide-vue-next';

import NavMenu from './NavMenu.vue';
import MenuIcon from '../icons/MenuIcon.vue';
import ThemeController from './ThemeController.vue';
import FreeConnectIcon from '../icons/FreeConnectIcon.vue';
import { useAuthStore } from '@/modules/auth/stores/auth.store';

interface Props {
  search?: boolean;
  navLinks?: boolean;
}

withDefaults(defineProps<Props>(), { search: false, navLinks: false });

const router = useRouter();
const authStore = useAuthStore();

const logoutHandler = () => {
  authStore.startLogout();
  router.replace({ name: 'home' });
};
</script>

<template>
  <header class="navbar min-h-12 bg-base-100 sticky top-0 z-[1] shadow-lg">
    <div class="lg:navbar-start">
      <div v-if="navLinks && authStore.isAuthenticated" class="dropdown">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle btn-sm lg:hidden mr-2">
          <menu-icon class="size-5" />
        </div>
        <nav-menu
          class="menu menu-sm dropdown-content bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow-lg"
        />
      </div>
      <router-link to="/home" class="btn btn-ghost gap-1 hidden lg:inline-flex">
        <free-connect-icon class="size-7" />
        <div class="text-xl">
          <span class="text-primary">Free</span>
          <span class="text-secondary">Connect</span>
        </div>
      </router-link>
    </div>

    <div v-if="navLinks && authStore.isAuthenticated" class="flex-shrink-0 hidden lg:flex">
      <nav-menu class="menu menu-horizontal py-0" />
    </div>

    <div class="justify-end w-full lg:w-1/2 gap-2">
      <div v-if="search" class="w-full lg:w-auto">
        <label
          class="input input-sm md:input-md input-primary input-bordered flex items-center gap-2 bg-base-200"
        >
          <input type="search" class="w-full" :placeholder="$t('common.navbar.search')" />
          <search-icon :size="16" class="opacity-70" />
        </label>
      </div>
      <div v-if="authStore.isUnauthenticated" class="flex-shrink-0">
        <router-link to="/auth/login" class="btn btn-primary btn-outline btn-sm md:btn-md">
          {{ $t('common.navbar.login') }}
          <log-in-icon :size="16" aria-hidden="true" />
        </router-link>
      </div>
      <div v-if="authStore.isAuthenticated">
        <button type="button" class="btn btn-sm md:btn-md btn-circle">
          <span class="sr-only">{{ $t('common.navbar.notifications') }}</span>
          <bell-icon class="size-4 md:size-6" aria-label="true" />
        </button>
      </div>
      <div v-if="authStore.isAuthenticated" class="dropdown dropdown-end flex md:inline-block">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle btn-sm md:btn-md avatar">
          <div class="rounded-full">
            <img :src="authStore.profileImg" :alt="authStore.user?.userName" />
          </div>
        </div>
        <ul
          tabindex="0"
          class="menu menu-md dropdown-content bg-base-100 rounded-box z-[1] mt-11 md:mt-3 w-52 p-2 shadow-lg"
        >
          <li>
            <div class="justify-between !cursor-auto">
              {{ $t('common.navbar.appearance') }}
              <theme-controller />
            </div>
          </li>
          <li>
            <router-link :to="`/profile/${authStore.user?.userName}`" class="justify-between">
              {{ $t('common.navbar.profile') }}
              <circle-user-round-icon :size="16" aria-hidden="true" />
            </router-link>
          </li>
          <li>
            <router-link to="/settings" class="justify-between">
              {{ $t('common.navbar.settings') }}
              <settings-icon :size="16" aria-hidden="true" />
            </router-link>
          </li>
          <li>
            <button type="button" class="justify-between" @click="logoutHandler">
              <span>{{ $t('common.navbar.logout') }}</span>
              <log-out-icon :size="16" aria-hidden="true" />
            </button>
          </li>
        </ul>
      </div>
    </div>
  </header>
</template>
