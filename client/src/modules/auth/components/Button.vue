<template>
    <div>
        <button :type="type" class="btn">
            {{ label }}
        </button>
    </div>
</template>

<script lang="ts">
export default {
    name: 'Button',
    props: {
        type: {
            type: String,
            default: 'button',
        },
        label: {
            type: String,
            default: 'Click me',
        },
    },
};
</script>

<style scoped></style>