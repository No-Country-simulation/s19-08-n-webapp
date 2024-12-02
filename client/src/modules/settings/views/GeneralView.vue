<script setup lang="ts">
import LangController from '@/modules/common/components/LangController.vue';
</script>

<template>
  <div class="">
    <section class="rounded-box bg-base-200 p-4">
      <h2 class="sr-only">{{ $t('settings.lang.title') }}</h2>
      <div class="flex items-center justify-between gap-2">
        <div>
          <div class="text-xl font-semibold">{{ $t('settings.lang.lang') }}</div>
          <p class="text-sm text-gray-500">
            {{ $t('settings.lang.help_text', { companyName: 'FreeConnect' }) }}
          </p>
        </div>
        <lang-controller />
      </div>
    </section>
  </div>
</template>
