<script setup lang="ts">
import { CalendarIcon, LinkIcon, MapPinIcon, PencilIcon } from 'lucide-vue-next';

import posts from '@/data/user_posts.json';
import PostCard from '@/modules/posts/components/PostCard.vue';
import { useAuthStore } from '@/modules/auth/stores/auth.store';
import PostModalCreate from '@/modules/posts/components/PostModalCreate.vue';

const authStore = useAuthStore();
</script>

<template>
  <div class="px-3 mt-4 animate__animated animate__fadeIn animate__faster">
    <main class="flex flex-col lg:flex-row gap-4 max-w-5xl mx-auto">
      <div class="lg:w-2/5">
        <section class="card bg-base-100 h-fit mb-4">
          <div class="card-body">
            <button class="btn btn-circle btn-sm absolute right-0 mr-8" aria-label="edit profile">
              <pencil-icon class="size-5" aria-hidden="true" />
            </button>

            <div class="avatar mx-auto">
              <div class="size-24 rounded-full">
                <img :src="authStore.profileImg" alt="Profile image of user" />
              </div>
            </div>

            <div class="mx-auto text-center">
              <h1 class="text-3xl font-semibold">{{ authStore.user?.fullName }}</h1>
              <span class="text-lg text-gray-500">@{{ authStore.user?.userName }}</span>
            </div>

            <div>
              <p class="text-center">
                Lorem ipsum dolor sit amet consectetur adipisicing elit. Quo quaerat, dolore eius et
                ut maxime, asperiores sunt quos obcaecati delectus voluptates qui minima, voluptate
                iure!
              </p>
            </div>

            <div class="my-2">
              <div class="flex items-center gap-2">
                <map-pin-icon :size="16" class="text-gray-500" />
                <span class="text-gray-500">Los Angeles, CA</span>
              </div>
              <div class="flex items-center gap-2">
                <link-icon :size="16" class="text-gray-500" />
                <span>{{ authStore.user?.userName }}.dev</span>
              </div>
              <div class="flex items-center gap-2">
                <calendar-icon :size="16" class="text-gray-500" />
                <span class="text-gray-500">{{ $t('user_profile.joined') }} 2020</span>
              </div>
            </div>

            <div class="flex flex-wrap gap-1">
              <span class="badge badge-outline">HTML</span>
              <span class="badge badge-outline">CSS</span>
              <span class="badge badge-outline">JavaScript</span>
            </div>
          </div>
        </section>

        <section class="card bg-base-100 h-fit">
          <div class="card-body">
            <h1 class="text-2xl font-semibold mb-2">{{ $t('user_profile.stats.title') }}</h1>
            <div class="stats stats-vertical shadow">
              <div class="stat">
                <div class="stat-figure text-primary">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    class="inline-block h-8 w-8 stroke-current"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z"
                    ></path>
                  </svg>
                </div>
                <div class="stat-title">{{ $t('user_profile.stats.total_likes') }}</div>
                <div class="stat-value text-primary">25.6K</div>
                <div class="stat-desc">21% {{ $t('user_profile.stats.more') }}</div>
              </div>

              <div class="stat">
                <div class="stat-figure text-secondary">
                  <svg
                    xmlns="http://www.w3.org/2000/svg"
                    fill="none"
                    viewBox="0 0 24 24"
                    class="inline-block h-8 w-8 stroke-current"
                  >
                    <path
                      stroke-linecap="round"
                      stroke-linejoin="round"
                      stroke-width="2"
                      d="M13 10V3L4 14h7v7l9-11h-7z"
                    ></path>
                  </svg>
                </div>
                <div class="stat-title">{{ $t('user_profile.stats.page_views') }}</div>
                <div class="stat-value text-secondary">2.6M</div>
                <div class="stat-desc">21% {{ $t('user_profile.stats.more') }}</div>
              </div>

              <div class="stat">
                <div class="stat-figure text-secondary">
                  <div class="avatar online">
                    <div class="w-16 rounded-full">
                      <img :src="authStore.profileImg" />
                    </div>
                  </div>
                </div>
                <div class="stat-value">86%</div>
                <div class="stat-title">{{ $t('user_profile.stats.tasks_done') }}</div>
                <div class="stat-desc text-secondary">
                  31 {{ $t('user_profile.stats.tasks_remaining') }}
                </div>
              </div>
            </div>
          </div>
        </section>
      </div>

      <section class="lg:w-3/5">
        <div class="card card-compact bg-base-100 mb-4">
          <div class="card-body flex-row items-center justify-between">
            <h2 class="text-2xl font-semibold">{{ $t('user_profile.recent_posts') }}</h2>
            <post-modal-create btn-class="btn btn-primary">{{
              $t('user_profile.btn_create_post')
            }}</post-modal-create>
          </div>
        </div>
        <div class="flex flex-col gap-4 pb-4">
          <post-card
            v-for="(post, index) in posts"
            :key="post.id"
            :post="{
              ...post,
              author: {
                ...post.author,
                name: authStore.user?.fullName!,
                profile_img: authStore.profileImg,
              },
            }"
            :num="index + 1"
            is-owner
          />
        </div>
      </section>
    </main>
  </div>
</template>
