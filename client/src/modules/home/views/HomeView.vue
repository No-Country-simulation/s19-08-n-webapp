<script setup lang="ts">
import posts from '@/data/posts.json';
import { useAuthStore } from '@/modules/auth/stores/auth.store';
import PostCard from '@/modules/posts/components/PostCard.vue';
import PostEntryBox from '@/modules/posts/components/PostEntryBox.vue';

const authStore = useAuthStore();
</script>

<template>
  <div class="px-3 animate__animated animate__fadeIn animate__faster">
    <main class="max-w-xl mx-auto">
      <post-entry-box />

      <div class="divider"></div>

      <div class="flex flex-col gap-4 pb-4">
        <post-card
          v-for="(post, index) in posts"
          :key="post.id"
          :post="post"
          :num="index + 1"
          @click-collaborate="
            authStore.isAuthenticated ? () => {} : $router.push({ name: 'login' })
          "
        />
      </div>
    </main>
  </div>
</template>
