<script setup lang="ts">
import NavBar from '@/modules/common/components/NavBar.vue';
import BellIcon from '@/modules/common/icons/BellIcon.vue';
import GearIcon from '@/modules/common/icons/GearIcon.vue';
import PersonShieldIcon from '@/modules/common/icons/PersonShieldIcon.vue';
</script>

<template>
  <div class="bg-base-300 h-screen">
    <nav-bar />

    <div class="mx-auto max-w-4xl mt-4 px-4">
      <h1 class="text-4xl font-semibold">Settings</h1>

      <div class="divider"></div>

      <div class="flex flex-col lg:flex-row gap-4">
        <aside>
          <ul class="menu menu-horizontal lg:menu-vertical bg-base-200 rounded-box w-full lg:w-56">
            <li class="flex-wrap flex-1 lg:flex-auto lg:flex-nowrap">
              <router-link
                :to="{ name: 'general' }"
                class="justify-center lg:justify-start"
                exact-active-class="active"
              >
                <gear-icon class="size-4" aria-hidden="true" />
                General
              </router-link>
            </li>
            <li class="flex-wrap flex-1 lg:flex-auto lg:flex-nowrap">
              <router-link
                :to="{ name: 'account' }"
                class="justify-center lg:justify-start"
                exact-active-class="active"
              >
                <person-shield-icon class="size-4" aria-hidden="true" />
                Account
              </router-link>
            </li>
            <li class="flex-wrap flex-1 lg:flex-auto lg:flex-nowrap">
              <router-link
                to="notifications"
                class="justify-center lg:justify-start"
                exact-active-class="active"
              >
                <bell-icon class="size-4" aria-hidden="true" />
                Notifications
              </router-link>
            </li>
          </ul>
        </aside>

        <main class="w-full">
          <router-view />
        </main>
      </div>
    </div>
  </div>
</template>
