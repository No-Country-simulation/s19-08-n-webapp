<script setup lang="ts">
import { ref, useId } from 'vue';
import { useLocalStorage } from '@vueuse/core';

import SunIcon from '../icons/SunIcon.vue';
import MoonIcon from '../icons/MoonIcon.vue';
import SystemIcon from '../icons/SystemIcon.vue';

const id = useId();
const theme = useLocalStorage('theme', '');

const systemRef = ref<HTMLInputElement | null>(null);
const lightRef = ref<HTMLInputElement | null>(null);
const darkRef = ref<HTMLInputElement | null>(null);

const getSwitchId = (theme: string) => `theme-switch-${theme}-${id}`;
</script>

<template>
  <fieldset class="theme-controller">
    <legend class="sr-only">Select a display theme:</legend>
    <span>
      <input
        ref="systemRef"
        :id="getSwitchId('system')"
        type="radio"
        value="system"
        class="peer theme-switch"
      />
      <label :for="getSwitchId('system')" class="theme-switch-label">
        <span class="sr-only">system</span>
        <system-icon />
      </label>
    </span>
    <span>
      <input
        ref="lightRef"
        :id="getSwitchId('light')"
        type="radio"
        value="light"
        class="peer theme-switch"
      />
      <label :for="getSwitchId('light')" class="theme-switch-label">
        <span class="sr-only">light</span>
        <sun-icon />
      </label>
    </span>
    <span>
      <input
        ref="darkRef"
        :id="getSwitchId('dark')"
        type="radio"
        value="dark"
        class="peer theme-switch"
      />
      <label :for="getSwitchId('dark')" class="theme-switch-label">
        <span class="sr-only">dark</span>
        <moon-icon />
      </label>
    </span>
  </fieldset>
</template>

<style scoped lang="css">
.theme-controller {
  @apply flex rounded-full p-0 m-0 border-0 shadow-[0_0_0_1px] shadow-current;
}

.theme-switch {
  @apply appearance-none p-0 m-0 outline-none absolute;
}

.theme-switch-label {
  @apply flex items-center justify-center w-6 h-6 m-0 relative cursor-pointer rounded-full peer-checked:shadow-[0_0_0_1px] peer-checked:shadow-current;
}
</style>
