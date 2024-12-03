<script setup lang="ts">
import { ref } from 'vue';
import type { Directive } from 'vue';

const open = ref(false);
const modalRef = ref<HTMLDialogElement | null>(null);

const showModal = () => {
  open.value = true;
  modalRef.value?.showModal();
};

const vClickOutside: Directive = {
  beforeMount(el, binding) {
    el.clickOutsideEvent = (event: MouseEvent) => {
      if (!(el === event.target || el.contains(event.target))) {
        binding.value(event);
      }
    };
    document.addEventListener('mousedown', el.clickOutsideEvent);
  },
  unmounted(el) {
    document.removeEventListener('mousedown', el.clickOutsideEvent);
  },
};
</script>

<template>
  <slot name="trigger" v-bind="{ showModal, open }" />
  <dialog
    ref="modalRef"
    tabindex="-1"
    class="modal backdrop:backdrop-blur-sm backdrop:bg-black/35"
    @close="open = false"
    :aria-hidden="!open"
  >
    <div class="modal-box" v-click-outside="() => modalRef?.close()">
      <button
        type="button"
        class="btn btn-sm btn-circle btn-ghost absolute right-2 top-2"
        @click="modalRef?.close()"
      >
        ✕
      </button>
      <slot name="body" />
      <div class="modal-action">
        <slot name="actions" />
      </div>
    </div>
  </dialog>
</template>
