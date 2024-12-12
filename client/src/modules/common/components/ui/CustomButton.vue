<script setup lang="ts">
import type { ButtonHTMLAttributes } from 'vue';
import type { ColorVariant, SizeVariant } from '../../types';

type ButtonVariant = 'outline' | 'circle' | 'ghost' | 'square';
type LoadingVariant = 'spinner' | 'dots' | 'ring' | 'ball' | 'bars' | 'infinity';
type LoadingPosition = 'start' | 'end';
type LoadingColorVariant = ColorVariant | 'current';

interface Props extends /* @vue-ignore */ ButtonHTMLAttributes {
  size?: SizeVariant;
  color?: ColorVariant;
  variant?: ButtonVariant;
  loading?: boolean;
  loadingSize?: SizeVariant;
  loadingColor?: LoadingColorVariant;
  loadingVariant?: LoadingVariant;
  loadingPosition?: LoadingPosition;
}

withDefaults(defineProps<Props>(), {
  size: 'md',
  color: 'primary',
  variant: 'square',
  loadingSize: 'xs',
  loadingColor: 'current',
  loadingPosition: 'end',
  loadingVariant: 'spinner',
});

const btnVariants: Record<ButtonVariant, string> = {
  ghost: 'btn-ghost',
  circle: 'btn-circle',
  square: 'btn-square',
  outline: 'btn-outline',
};

const btnColors: Record<ColorVariant, string> = {
  primary: 'btn-primary',
  secondary: 'btn-secondary',
  accent: 'btn-accent',
  info: 'btn-info',
  success: 'btn-success',
  warning: 'btn-warning',
  error: 'btn-error',
};

const btnSizes: Record<SizeVariant, string> = {
  xs: 'btn-xs',
  sm: 'btn-sm',
  md: 'btn-md',
  lg: 'btn-lg',
};

const loadingVariants: Record<LoadingVariant, string> = {
  spinner: 'loading-spinner',
  dots: 'loading-dots',
  ring: 'loading-ring',
  ball: 'loading-ball',
  bars: 'loading-bars',
  infinity: 'loading-infinity',
};

const loadingSizes: Record<SizeVariant, string> = {
  xs: 'loading-xs',
  sm: 'loading-sm',
  md: 'loading-md',
  lg: 'loading-lg',
};

const loadingColors: Record<LoadingColorVariant, string> = {
  current: 'text-current',
  primary: 'text-primary',
  secondary: 'text-secondary',
  accent: 'text-accent',
  info: 'text-info',
  success: 'text-success',
  warning: 'text-warning',
  error: 'text-error',
};
</script>

<template>
  <button :class="['btn w-full', btnSizes[size], btnColors[color], btnVariants[variant]]">
    <span
      v-if="loading && loadingPosition === 'start'"
      :class="[
        'loading',
        loadingSizes[loadingSize],
        loadingColors[loadingColor],
        loadingVariants[loadingVariant],
      ]"
    />
    <slot />
    <span
      v-if="loading && loadingPosition === 'end'"
      :class="[
        'loading',
        loadingSizes[loadingSize],
        loadingColors[loadingColor],
        loadingVariants[loadingVariant],
      ]"
    />
  </button>
</template>
