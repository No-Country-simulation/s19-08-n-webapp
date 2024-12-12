<script setup lang="ts">
import { ref } from 'vue';
import { useForm } from 'vee-validate';

import { useAuthStore } from '../stores/auth.store';
import type { IRegisterRequestData } from '../interfaces';
import { registerFormSchema } from '../schemas/auth.schema';
import CustomInput from '@/modules/common/components/ui/CustomInput.vue';
import CustomButton from '@/modules/common/components/ui/CustomButton.vue';
import ShowHidePwdButton from '@/modules/common/components/ui/ShowHidePwdButton.vue';

const authStore = useAuthStore();
const { meta, handleSubmit, isSubmitting } = useForm<IRegisterRequestData>({
  validationSchema: registerFormSchema,
});

const passwordVisible = ref(false);

const submitHandler = handleSubmit(authStore.startRegister);
</script>

<template>
  <section class="card card-compact sm:card-normal bg-base-100 shadow-xl">
    <div class="card-body">
      <h1 class="card-title text-2xl">{{ $t('auth.register.title') }}</h1>
      <form @submit.prevent="submitHandler" class="grid grid-cols-1 md:grid-cols-2 gap-2.5">
        <custom-input name="firstName" :label="$t('auth.register.form.firstName')" />
        <custom-input name="lastName" :label="$t('auth.register.form.lastName')" />
        <custom-input name="username" :label="$t('auth.register.form.username')" />
        <custom-input name="email" :label="$t('auth.register.form.email')" />
        <custom-input
          name="password"
          :label="$t('auth.register.form.password')"
          :type="passwordVisible ? 'text' : 'password'"
        >
          <template #adornment-end>
            <show-hide-pwd-button
              :password-visible="passwordVisible"
              @click="passwordVisible = !passwordVisible"
            />
          </template>
        </custom-input>
        <custom-input
          type="password"
          name="confirmPassword"
          :label="$t('auth.register.form.confirmPassword')"
        />
        <custom-button
          class="md:col-span-2"
          :loading="meta.valid && isSubmitting"
          :disabled="meta.valid && isSubmitting"
        >
          {{ $t('auth.register.form.btn_submit') }}
        </custom-button>
      </form>

      <div class="flex justify-center gap-1 mt-2">
        <span class="text-gray-500">{{ $t('auth.register.already_have_account') }}</span>
        <router-link to="/auth/login" class="text-secondary font-semibold hover:underline">
          {{ $t('auth.register.sign_in_title') }}
        </router-link>
      </div>
    </div>
  </section>
</template>
