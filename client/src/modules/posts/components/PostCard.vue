<script setup lang="ts">
import type { Post } from '../interfaces/post.interface';

interface Props {
  num: number;
  post: Post;
}

defineProps<Props>();
</script>

<template>
  <article class="card bg-base-100 w-full shadow-lg" :aria-label="`Post number ${num}`">
    <figure class="h-[20rem]">
      <img :src="post.images[0]" :alt="post.title" class="w-full h-full object-cover" />
    </figure>

    <div class="card-body">
      <section class="card" aria-label="">
        <div class="flex gap-2">
          <a class="avatar" href="#">
            <div class="size-10 rounded-full">
              <img
                src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
                alt=""
              />
            </div>
          </a>
          <a href="#" class="">
            <span
              class="block w-fit leading-5 font-semibold hover:text-secondary hover:underline"
              >{{ post.author }}</span
            >
            <span class="block text-sm text-gray-500">Example | Example | Example</span>
            <span class="block text-sm italic text-gray-500">{{ post.published_date }}</span>
          </a>
        </div>
      </section>

      <section>
        <h2 class="card-title">
          {{ post.title }}
          <span
            :class="[
              'badge uppercase',
              {
                'badge-secondary': post.status === 'nuevo',
                'badge-success': post.status === 'activo',
                'badge-accent': post.status === 'completado',
              },
            ]"
          >
            {{ post.status }}
          </span>
        </h2>
        <p>{{ post.description }}</p>
      </section>

      <div class="divider my-0"></div>

      <section class="mb-1">
        <h3 class="font-semibold mb-1">Habilidades ofrecidas</h3>
        <div class="flex flex-wrap gap-1">
          <span
            v-for="(offSkill, index) in post.skills_offered"
            :key="index"
            class="badge badge-outline"
          >
            {{ offSkill }}
          </span>
        </div>
      </section>

      <section>
        <h3 class="font-semibold mb-1">Habilidades requeridas</h3>
        <div class="flex flex-wrap gap-1">
          <span
            v-for="(offSkill, index) in post.skills_requested"
            :key="index"
            class="badge badge-outline"
          >
            {{ offSkill }}
          </span>
        </div>
      </section>

      <section class="card-actions justify-end">
        <button type="button" class="btn btn-primary">Colaborar</button>
      </section>
    </div>
  </article>
</template>
