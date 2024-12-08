<template>
    <div>
        <label :for="inputId" class="block text-sm font-medium text-gray-700 text-left">
            {{ placeholder }}
        </label>
        <input :id="inputId" :type="type" :placeholder="placeholder" :value="modelValue"
            @input="$emit('update:modelValue', $event.target.value)"
            class="input input-bordered input-info w-full max-w-xs bg-white" />
    </div>
</template>

<script lang="ts">
export default {
    name: 'Input',
    props: {
        type: {
            type: String,
            default: 'text',
        },
        placeholder: {
            type: String,
            default: '',
        },
        modelValue: {
            type: String,
            required: true,
        },
        inputId: {
            type: String,
            default: () => `input-${Math.random().toString(36).substr(2, 9)}`,
        },
    },
};
</script>

<style scoped></style>