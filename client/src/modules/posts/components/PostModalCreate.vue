<script setup lang="ts">
import type { HTMLAttributes } from 'vue';

import { useAuthStore } from '@/modules/auth/stores/auth.store';
import CustomModal from '@/modules/common/components/ui/CustomModal.vue';

interface Props {
  btnClass?: HTMLAttributes['class'];
}

defineProps<Props>();

const authStore = useAuthStore();
</script>

<template>
  <custom-modal>
    <template #trigger="{ showModal, open }">
      <button
        type="button"
        :class="btnClass"
        :aria-expanded="open"
        :aria-controls="undefined"
        aria-haspopup="dialog"
        @click="authStore.isAuthenticated ? showModal() : $router.push({ name: 'login' })"
      >
        <slot />
      </button>
    </template>
    <template #body>
      <form action=""></form>
    </template>
    <template #actions>
      <button type="submit" class="btn btn-primary">Publicar</button>
    </template>
  </custom-modal>
</template>
