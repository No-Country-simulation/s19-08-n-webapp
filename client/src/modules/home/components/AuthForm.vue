<template>
    <div>
        <label :for="inputId" class="block text-sm font-medium text-gray-700 text-left">
            {{ placeholder }}
        </label>
        <input :id="inputId" :type="type" :placeholder="placeholder"
            class="input input-bordered input-info w-full max-w-xs" />
    </div>
</template>

<script>
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
        inputId: {
            type: String,
            default: () => `input-${Math.random().toString(36).substr(2, 9)}`,
        },
    },
};
</script>

<style scoped></style>