import { defineStore } from 'pinia';
import { ref } from 'vue';

export const usePostsStore = defineStore('posts', () => {
  const isModalCreateOpen = ref(false);

  return {
    isModalCreateOpen,
  };
});
