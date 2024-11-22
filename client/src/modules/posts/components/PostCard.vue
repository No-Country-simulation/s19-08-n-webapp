<script setup lang="ts">
import type { Post } from '../interfaces/post.interface';

interface Props {
  post: Post;
}

defineProps<Props>();
</script>

<template>
  <article class="card bg-base-100 w-full shadow-lg">
    <figure class="h-[20rem]">
      <img :src="post.images[0]" :alt="post.title" class="w-full h-full object-cover" />
    </figure>
    <section class="card-body">
      <em>{{ post.published_date }}</em>
      <h2 class="card-title">
        {{ post.title }}
        <div
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
        </div>
      </h2>
      <p>{{ post.description }}</p>

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

      <div class="card-actions justify-end">
        <button type="button" class="btn btn-primary">Colaborar</button>
      </div>
    </section>
  </article>
</template>
