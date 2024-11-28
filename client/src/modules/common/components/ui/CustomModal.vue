<script setup lang="ts">
defineEmits<{
  close: [void];
}>();
</script>

<template>
  <!-- <dialog class="modal" :aria-hidden="!open" :open="open" @close="$emit('close')"> -->
  <dialog class="modal" @close="$emit('close')">
    <div class="modal-box">
      <form method="dialog">
        <button class="btn btn-sm btn-circle btn-ghost absolute right-2 top-2">✕</button>
      </form>
      <slot name="body" />
      <div class="modal-action">
        <slot name="actions" />
      </div>
    </div>
    <form method="dialog" class="modal-backdrop">
      <button class="bg-black bg-opacity-35">close</button>
    </form>
  </dialog>
</template>
