<script setup lang="ts">
import { EllipsisVerticalIcon } from 'lucide-vue-next';
import type { IPost } from '../interfaces/post.interface';

interface Props {
  num: number;
  post: IPost;
  isOwner?: boolean;
}

defineEmits(['clickCollaborate']);
withDefaults(defineProps<Props>(), { isOwner: false });
</script>

<template>
  <article class="card bg-base-100 w-full shadow-lg" :aria-label="`Post number ${num}`">
    <figure class="h-[20rem]">
      <img :src="post.images[0]" :alt="post.title" class="w-full h-full object-cover" />
    </figure>

    <div class="card-body">
      <section class="flex justify-between items-start" aria-label="">
        <div class="flex gap-2">
          <a class="avatar" href="#">
            <div class="size-10 rounded-full">
              <img :src="post.author.profile_img" :alt="post.author.name" />
            </div>
          </a>
          <a href="#">
            <span
              class="block w-fit leading-5 font-semibold hover:text-secondary hover:underline"
              >{{ post.author.name }}</span
            >
            <span class="block text-sm text-gray-500">{{ post.author.headline }}</span>
            <span class="block text-sm italic text-gray-500">{{ post.published_date }}</span>
          </a>
        </div>
        <div v-if="isOwner">
          <button class="btn btn-circle btn-sm mr-2" aria-label="edit post">
            <ellipsis-vertical-icon class="size-5" aria-hidden="true" />
          </button>
        </div>
      </section>

      <section>
        <h2 class="card-title">
          {{ post.title }}
          <span
            :class="[
              'badge uppercase',
              {
                'badge-secondary': post.status === 'new',
                'badge-success': post.status === 'active',
                'badge-accent': post.status === 'completed',
              },
            ]"
          >
            {{ $t(`posts.card.status.${post.status}`) }}
          </span>
        </h2>
        <p>{{ post.description }}</p>
      </section>

      <div class="divider my-0"></div>

      <section class="mb-1">
        <h3 class="font-semibold mb-1">{{ $t('posts.card.skills_offered') }}</h3>
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
        <h3 class="font-semibold mb-1">{{ $t('posts.card.skills_requested') }}</h3>
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

      <section v-if="!isOwner" class="card-actions justify-end">
        <button type="button" class="btn btn-primary" @click="$emit('clickCollaborate')">
          {{ $t('posts.card.btn_collab') }}
        </button>
      </section>
    </div>
  </article>
</template>
