<script setup lang="ts">
import { usePostsStore } from '../stores/posts.store';
import CustomModal from '@/modules/common/components/ui/CustomModal.vue';

const postsStore = usePostsStore();
</script>

<template>
  <custom-modal :open="postsStore.isModalCreateOpen" @close="postsStore.isModalCreateOpen = false">
    <template #body>
      <form action=""></form>
    </template>
    <template #actions>
      <button type="submit" class="btn btn-primary">Publicar</button>
    </template>
  </custom-modal>
</template>
