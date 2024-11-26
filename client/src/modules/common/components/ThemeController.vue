<script setup lang="ts">
import { useId } from 'vue';
import { useLocalStorage } from '@vueuse/core';

import SunIcon from '../icons/SunIcon.vue';
import MoonIcon from '../icons/MoonIcon.vue';
import SystemIcon from '../icons/SystemIcon.vue';

const id = useId();
const theme = useLocalStorage('theme', '', { writeDefaults: false });

const getSwitchId = (theme: string) => `theme-switch-${theme}-${id}`;

const themeChangeHanlder = (event: Event) => {
  const t = (event.target as HTMLInputElement).value;
  theme.value = t;
  document.documentElement.setAttribute('data-theme', t);
};
</script>

<template>
  <fieldset class="controller-container">
    <legend class="sr-only">{{ $t('common.theme_controller.select') }}</legend>
    <span>
      <input
        :id="getSwitchId('system')"
        type="radio"
        value="system"
        name="theme-radios"
        :checked="theme === 'system'"
        class="peer theme-switch"
        :aria-label="$t('common.theme_controller.system')"
        @change="themeChangeHanlder($event)"
      />
      <label :for="getSwitchId('system')" class="theme-switch-label">
        <span class="sr-only">{{ $t('common.theme_controller.system') }}</span>
        <system-icon aria-hidden="true" />
      </label>
    </span>
    <span>
      <input
        :id="getSwitchId('light')"
        type="radio"
        value="light"
        name="theme-radios"
        :checked="theme === 'light'"
        class="peer theme-switch"
        :aria-label="$t('common.theme_controller.light')"
        @change="themeChangeHanlder($event)"
      />
      <label :for="getSwitchId('light')" class="theme-switch-label">
        <span class="sr-only">{{ $t('common.theme_controller.light') }}</span>
        <sun-icon aria-hidden="true" />
      </label>
    </span>
    <span>
      <input
        :id="getSwitchId('dark')"
        type="radio"
        value="dark"
        name="theme-radios"
        :checked="theme === 'dark'"
        class="peer theme-switch"
        :aria-label="$t('common.theme_controller.dark')"
        @change="themeChangeHanlder($event)"
      />
      <label :for="getSwitchId('dark')" class="theme-switch-label">
        <span class="sr-only">{{ $t('common.theme_controller.dark') }}</span>
        <moon-icon aria-hidden="true" />
      </label>
    </span>
  </fieldset>
</template>

<style scoped lang="css">
.controller-container {
  @apply flex rounded-full p-0 m-0 border-0 shadow-[0_0_0_1px] shadow-current;
}

.theme-switch {
  @apply appearance-none p-0 m-0 outline-none absolute;
}

.theme-switch-label {
  @apply flex items-center justify-center w-6 h-6 m-0 relative cursor-pointer rounded-full peer-checked:shadow-[0_0_0_1px] peer-checked:shadow-current;
}
</style>
