<script setup lang="ts">
import { FrownIcon, HomeIcon, RefreshCcwIcon } from 'lucide-vue-next';
</script>

<template>
  <div
    class="flex min-h-screen flex-col items-center justify-center bg-gradient-to-r from-primary via-accent to-secondary"
  >
    <div class="text-center">
      <h1 class="mb-4 text-6xl font-bold text-white">
        4
        <span class="inline-block animate-bounce">0</span>
        4
      </h1>
      <div class="mb-8 text-5xl font-semibold text-white">
        <frown-icon class="inline-block size-12 animate-pulse" />
        <span class="ml-2">{{ $t('common.not_found.title') }}</span>
      </div>
      <p class="mb-8 text-2xl text-white">
        {{ $t('common.not_found.subtitle') }}
      </p>
      <div class="flex justify-center space-x-4">
        <router-link
          to="/"
          class="flex items-center rounded-full bg-white px-6 py-3 text-lg font-semibold text-purple-600 transition-colors hover:bg-purple-100"
        >
          <home-icon class="mr-2 size-5" />
          {{ $t('common.not_found.btn_home') }}
        </router-link>
        <button
          type="button"
          onclick="window.location.reload()"
          class="flex items-center rounded-full bg-white px-6 py-3 text-lg font-semibold text-pink-600 transition-colors hover:bg-pink-100"
        >
          <refresh-ccw-icon class="mr-2 size-5" />
          {{ $t('common.not_found.btn_refresh') }}
        </button>
      </div>
    </div>
  </div>
</template>
