<script setup lang="ts">
import Tr from '@/i18n/translation';

const supportedLocales = Tr.supportedLocales;

const langChangeHandler = async (event: Event) => {
  const locale = (event.target as HTMLSelectElement).value;
  await Tr.switchLanguage(locale);
};
</script>

<template>
  <select class="select select-primary" @change="langChangeHandler">
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
