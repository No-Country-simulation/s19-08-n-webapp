<script setup lang="ts">
import { FolderGit2Icon, HomeIcon, MessageSquareCode } from 'lucide-vue-next';
</script>

<template>
  <ul>
    <li>
      <router-link to="/home" active-class="active">
        <home-icon class="size-4 lg:size-5" aria-hidden="true" />
        {{ $t('common.navbar.home') }}
      </router-link>
    </li>
    <li>
      <router-link to="/messaging" active-class="active">
        <message-square-code class="size-4 lg:size-5" />
        {{ $t('common.navbar.messaging') }}
      </router-link>
    </li>
    <li>
      <router-link to="/projects" active-class="active">
        <folder-git2-icon class="size-4 lg:size-5" />
        {{ $t('common.navbar.projects') }}
      </router-link>
    </li>
  </ul>
</template>
