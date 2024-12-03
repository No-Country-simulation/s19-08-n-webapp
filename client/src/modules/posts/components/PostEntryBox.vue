<script setup lang="ts">
import PostModalCreate from './PostModalCreate.vue';
</script>

<template>
  <section class="card card-compact bg-base-100 shadow-lg mt-4">
    <h2 class="sr-only">{{ $t('posts.new') }}</h2>
    <div class="card-body flex-row">
      <div class="avatar">
        <div class="size-10 sm:size-12 rounded-full">
          <img src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp" />
        </div>
      </div>
      <post-modal-create
        btn-class="input input-bordered input-primary flex h-auto w-full rounded-full hover:bg-base-200 focus:bg-base-200 transition-colors"
      >
        <span class="self-center">
          <strong class="text-gray-400 font-normal text-sm sm:text-base">
            {{ $t('posts.btn_start') }}
          </strong>
        </span>
      </post-modal-create>
    </div>
  </section>
</template>
