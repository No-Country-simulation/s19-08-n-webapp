<script setup lang="ts"></script>

<template>
  <div class="">
    <section class="rounded-box bg-base-200 p-4">
      <h2 class="sr-only">section for language selector</h2>
      <div class="flex items-center justify-between gap-2">
        <div>
          <div class="text-xl font-semibold">Language</div>
          <p class="text-sm text-gray-500">Select the language you use on FreeConnect</p>
        </div>
        <select class="select select-primary">
          <option>English</option>
          <option>Spanish</option>
        </select>
      </div>
    </section>
  </div>
</template>
