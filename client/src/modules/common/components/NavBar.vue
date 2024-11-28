<script setup lang="ts">
import NavMenu from './NavMenu.vue';
import MenuIcon from '../icons/MenuIcon.vue';
import GearIcon from '../icons/GearIcon.vue';
import BellIcon from '../icons/BellIcon.vue';
import LogOutIcon from '../icons/LogOutIcon.vue';
import SearchIcon from '../icons/SearchIcon.vue';
import ProfileIcon from '../icons/ProfileIcon.vue';
import ThemeController from './ThemeController.vue';

interface Props {
  search?: boolean;
  navLinks?: boolean;
}

withDefaults(defineProps<Props>(), { search: false, navLinks: false });
</script>

<template>
  <header class="navbar min-h-12 bg-base-100 sticky top-0 z-[1] shadow-lg">
    <div class="lg:navbar-start">
      <div v-if="navLinks" class="dropdown">
        <div tabindex="0" role="button" class="btn btn-ghost btn-sm lg:hidden">
          <menu-icon class="size-5" />
        </div>
        <nav-menu
          class="menu menu-sm dropdown-content bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow-lg"
        />
      </div>
      <router-link to="/home" class="btn btn-ghost text-xl gap-0 hidden lg:flex">
        <span class="text-primary">Free</span>
        <span class="text-secondary">Connect</span>
      </router-link>
    </div>

    <div v-if="navLinks" class="flex-shrink-0 hidden lg:flex">
      <nav-menu class="menu menu-horizontal py-0" />
    </div>

    <div class="justify-end w-full lg:w-1/2 gap-2">
      <div v-if="search" class="w-full lg:w-auto">
        <label
          class="input input-sm md:input-md input-primary input-bordered flex items-center gap-2 bg-base-200"
        >
          <input type="search" class="w-full" :placeholder="$t('common.navbar.search')" />
          <search-icon class="size-4 opacity-70" />
        </label>
      </div>
      <div>
        <button class="btn btn-sm md:btn-md btn-circle">
          <bell-icon class="size-4 md:size-6" />
        </button>
      </div>
      <div class="dropdown dropdown-end flex md:inline-block">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle btn-sm md:btn-md avatar">
          <div class="size-10 rounded-full">
            <img
              alt="Tailwind CSS Navbar component"
              src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
            />
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
            <router-link to="/profile/juan" class="justify-between">
              {{ $t('common.navbar.profile') }}
              <profile-icon class="size-4" aria-hidden="true" />
            </router-link>
          </li>
          <li>
            <router-link to="/settings" class="justify-between">
              {{ $t('common.navbar.settings') }}
              <gear-icon class="size-4" aria-hidden="true" />
            </router-link>
          </li>
          <li>
            <button type="button" class="justify-between">
              <span>{{ $t('common.navbar.logout') }}</span>
              <log-out-icon class="size-4" aria-hidden="true" />
            </button>
          </li>
        </ul>
      </div>
    </div>
  </header>
</template>
