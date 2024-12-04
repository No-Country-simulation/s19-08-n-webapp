<template>
    <div>
        <button :type="type">
            {{ label }}
        </button>
    </div>
</template>

<script>
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

<style></style>