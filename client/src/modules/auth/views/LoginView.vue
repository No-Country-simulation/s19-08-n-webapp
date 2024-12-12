<script setup lang="ts">
import { ref } from 'vue';
import { useForm } from 'vee-validate';

import { useAuthStore } from '../stores/auth.store';
import type { ILoginRequestData } from '../interfaces';
import { loginFormSchema } from '../schemas/auth.schema';
import CustomInput from '@/modules/common/components/ui/CustomInput.vue';
import FreeConnectIcon from '@/modules/common/icons/FreeConnectIcon.vue';
import CustomButton from '@/modules/common/components/ui/CustomButton.vue';
import ShowHidePwdButton from '@/modules/common/components/ui/ShowHidePwdButton.vue';

const authStore = useAuthStore();
const { meta, handleSubmit, isSubmitting } = useForm<ILoginRequestData>({
  validationSchema: loginFormSchema,
});

const passwordVisible = ref(false);

const submitHandler = handleSubmit(authStore.startLogin);
</script>

<template>
  <section class="card card-compact sm:card-normal bg-base-100 shadow-xl max-w-sm mx-auto">
    <div class="card-body">
      <div class="mx-auto size-24" aria-hidden="true">
        <free-connect-icon class="size-24" />
      </div>

      <h1 class="card-title justify-center text-2xl">{{ $t('auth.login.title') }}</h1>

      <form @submit.prevent="submitHandler" class="flex flex-col gap-2.5">
        <custom-input name="username" :label="$t('auth.login.form.username')" />
        <custom-input
          name="password"
          :label="$t('auth.login.form.password')"
          :type="passwordVisible ? 'text' : 'password'"
        >
          <template #adornment-end>
            <show-hide-pwd-button
              :password-visible="passwordVisible"
              @click="passwordVisible = !passwordVisible"
            />
          </template>
        </custom-input>
        <custom-button :loading="meta.valid && isSubmitting" :disabled="meta.valid && isSubmitting">
          {{ $t('auth.login.form.btn_submit') }}
        </custom-button>
      </form>

      <div class="flex justify-center gap-1 mt-2">
        <span class="text-gray-500">{{ $t('auth.login.do_not_have_account') }}</span>
        <router-link to="/auth/register" class="text-secondary font-semibold hover:underline">
          {{ $t('auth.login.sign_up_title') }}
        </router-link>
      </div>
    </div>
  </section>
</template>
