<script setup lang="ts">
import Tr from '@/i18n/translation';

const supportedLocales = Tr.supportedLocales;
</script>

<template>
  <select class="select select-primary" v-model="$i18n.locale">
    <option
      v-for="sLocale in supportedLocales"
      :key="sLocale"
      :value="sLocale"
      :selected="$i18n.locale === sLocale"
    >
      {{ $t(`common.lang_controller.${sLocale}`) }}
    </option>
  </select>
</template>
