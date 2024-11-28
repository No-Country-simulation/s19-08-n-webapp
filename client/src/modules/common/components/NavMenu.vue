<script setup lang="ts">
import HomeIcon from '../icons/HomeIcon.vue';
import DiagramIcon from '../icons/DiagramIcon.vue';
import MessageCodeIcon from '../icons/MessageCodeIcon.vue';
</script>

<template>
  <ul>
    <li>
      <router-link to="/home" active-class="active">
        <home-icon class="size-5" aria-hidden="true" />
        {{ $t('common.navbar.home') }}
      </router-link>
    </li>
    <li>
      <router-link to="/messaging" active-class="active">
        <message-code-icon class="size-5" />
        {{ $t('common.navbar.messaging') }}
      </router-link>
    </li>
    <li>
      <router-link to="/projects" active-class="active">
        <diagram-icon class="size-5" />
        {{ $t('common.navbar.projects') }}
      </router-link>
    </li>
  </ul>
</template>
