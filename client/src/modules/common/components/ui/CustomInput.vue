<script setup lang="ts">
import { ref, useId } from 'vue';
import { useField } from 'vee-validate';

import type { ColorVariant } from '@/modules/common/types';

export interface Props {
  type?: 'text' | 'email' | 'number' | 'password';
  value?: string;
  name: string;
  label?: string;
  placeholder?: string;
  variant?: ColorVariant;
}

const props = withDefaults(defineProps<Props>(), { type: 'text', variant: 'primary' });

const id = useId();
const inputId = `${props.name}-${id}`;
const errorId = `${props.name}-error-${id}`;

const inputRef = ref<HTMLInputElement | null>(null);

const { value, errorMessage } = useField(props.name, undefined, {
  initialValue: props.value,
});

const inputColorClass: Record<ColorVariant, string> = {
  primary: 'input-primary',
  secondary: 'input-secondary',
  accent: 'input-accent',
  info: 'input-info',
  success: 'input-success',
  warning: 'input-warning',
  error: 'input-error',
};
</script>

<template>
  <div class="form-control w-full">
    <div v-if="label" class="label pt-0">
      <label :for="inputId" class="label-text">{{ label }}</label>
    </div>

    <div
      :class="[
        'input input-bordered flex items-center gap-2',
        { [inputColorClass[variant]]: !errorMessage },
        { 'input-error': errorMessage },
      ]"
      @click="inputRef?.focus()"
    >
      <slot name="adornment-start" />
      <input
        ref="inputRef"
        :id="inputId"
        :type="type"
        class="grow"
        :placeholder="placeholder"
        :aria-invalid="!!errorMessage"
        :aria-describedby="errorId"
        v-model="value"
      />
      <slot name="adornment-end" />
    </div>

    <div class="label h-6 pb-0">
      <span
        v-if="errorMessage"
        :id="errorId"
        role="alert"
        aria-live="assertive"
        class="label-text-alt text-error"
      >
        {{ errorMessage }}
      </span>
    </div>
  </div>
</template>
