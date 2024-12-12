<script setup lang="ts">
import FreeConnectIcon from '../icons/FreeConnectIcon.vue';
</script>

<template>
  <div class="flex justify-center items-center h-screen w-screen">
    <div class="flex flex-col items-center gap-2">
      <free-connect-icon class="size-24 animate-spin" />
      <div class="animate-pulse select-none">
        <span class="text-4xl font-semibold text-primary">Free</span>
        <span class="text-4xl font-semibold text-secondary">Connect</span>
      </div>
    </div>
  </div>
</template>
