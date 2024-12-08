<script setup lang="ts">
import { onMounted } from 'vue';
import Tr from '@/i18n/translation';

onMounted(async () => {
  const locale = localStorage.getItem('locale')!;
  await Tr.loadLocaleMessages(locale);
  Tr.currentLocale = locale;
});
</script>

<template>
  <router-view />
</template>
