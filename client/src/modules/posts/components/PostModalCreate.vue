<script setup lang="ts">
import CustomModal from '@/modules/common/components/ui/CustomModal.vue';
</script>

<template>
  <custom-modal id="postModalCreate">
    <template #body>
      <form action=""></form>
    </template>
    <template #actions>
      <button type="submit" class="btn btn-primary">Publicar</button>
    </template>
  </custom-modal>
</template>
