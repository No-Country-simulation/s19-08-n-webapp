<script setup lang="ts">
import NavBar from '../components/NavBar.vue';
</script>

<template>
  <div class="bg-base-300">
    <nav-bar search nav-links />
    <router-view />
  </div>
</template>
