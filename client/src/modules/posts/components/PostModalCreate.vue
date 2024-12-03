<script setup lang="ts">
import type { HTMLAttributes } from 'vue';
import CustomModal from '@/modules/common/components/ui/CustomModal.vue';

interface Props {
  btnClass?: HTMLAttributes['class'];
}

defineProps<Props>();
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
        @click="showModal()"
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
