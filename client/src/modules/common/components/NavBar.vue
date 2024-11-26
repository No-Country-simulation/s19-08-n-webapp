<script setup lang="ts">
import LogOutIcon from '../icons/LogOutIcon.vue';
import SearchIcon from '../icons/SearchIcon.vue';
import ThemeController from './ThemeController.vue';
</script>

<template>
  <header class="navbar bg-base-100 sticky top-0 z-[1] shadow-lg">
    <div class="hidden sm:block flex-1">
      <a class="btn btn-ghost text-xl">FreeConnect</a>
    </div>
    <div class="flex-1 sm:flex-none gap-2">
      <div class="form-control w-full">
        <label class="input input-primary input-bordered flex items-center gap-2 bg-base-200">
          <input type="search" class="grow" :placeholder="$t('common.navbar.search')" />
          <search-icon class="h-4 w-4 opacity-70" />
        </label>
      </div>
      <div class="dropdown dropdown-end">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle avatar">
          <div class="w-10 rounded-full">
            <img
              alt="Tailwind CSS Navbar component"
              src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
            />
          </div>
        </div>
        <ul
          tabindex="0"
          class="menu menu-md dropdown-content bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow-lg"
        >
          <li>
            <a>{{ $t('common.navbar.profile') }}</a>
          </li>
          <li>
            <a>{{ $t('common.navbar.settings') }}</a>
          </li>
          <li>
            <div class="justify-between !cursor-auto">
              {{ $t('common.navbar.appearance') }}
              <theme-controller />
            </div>
          </li>
          <li>
            <button type="button" class="justify-between">
              <span>{{ $t('common.navbar.logout') }}</span>
              <log-out-icon class="w-4 h-4" />
            </button>
          </li>
        </ul>
      </div>
    </div>
  </header>
</template>
