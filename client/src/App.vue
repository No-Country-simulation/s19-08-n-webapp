<script setup lang="ts">
import { onMounted } from 'vue';

import Tr from '@/i18n/translation';
import { useAuthStore } from '@/modules/auth/stores/auth.store';
import FullScreenLoader from '@/modules/common/components/FullScreenLoader.vue';

const authStore = useAuthStore();

onMounted(async () => {
  const locale = localStorage.getItem('locale')!;
  await Tr.loadLocaleMessages(locale);
  Tr.currentLocale = locale;
});
</script>

<template>
  <full-screen-loader v-if="authStore.isChecking" />
  <router-view v-else />
</template>
