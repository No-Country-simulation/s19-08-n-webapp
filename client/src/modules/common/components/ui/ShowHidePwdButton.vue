<script setup lang="ts">
import { EyeIcon, EyeOffIcon } from 'lucide-vue-next';

interface Props {
  passwordVisible: boolean;
}

defineProps<Props>();
</script>

<template>
  <button type="button" class="btn btn-circle btn-ghost btn-sm">
    <eye-off-icon v-if="passwordVisible" :size="20" />
    <eye-icon v-else :size="20" />
  </button>
</template>
