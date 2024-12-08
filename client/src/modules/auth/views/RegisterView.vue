<template>
  <div class="card bg-white w-96 shadow-xl ">
    <div class="card-body items-center text-center">
      <h2 class="card-title">Crear Cuenta</h2>
      <form @submit.prevent="handleSubmit">
        <Input v-model="form.username" type="text" placeholder="Username" id="username" />
        <Input v-model="form.email" type="email" placeholder="Email" required />
        <Input v-model="form.password" type="password" placeholder="Password" required />
        <Input v-model="form.firstName" type="text" placeholder="First Name" required />
        <Input v-model="form.lastName" type="text" placeholder="Last Name" required />

        <button type="submit" class="btn btn-outline btn-info" :disabled="isLoading">Registrarse</button>
      </form>
    </div>
  </div>
</template>

<script lang="ts">
import { defineComponent, ref } from 'vue'
import { useAuthStore } from '../stores/auth.store';
import Input from "../components/AuthForm.vue";
import Button from "../components/Button.vue";

export default defineComponent({
  name: 'Register',
  components: { Input, Button },
  setup() {
    const authStore = useAuthStore();
    const form = ref({
      username: '',
      email: '',
      password: '',
      firstName: '',
      lastName: '',
    });

    const isLoading = ref(false);

    const handleSubmit = async () => {
      isLoading.value = true;
      try {
        console.log('Datos enviados al registro:', form.value);
        await authStore.registroAction(form.value);
        console.log('Registro exitoso');
      } catch (err) {
        console.error('Error en el registro:', err);
      } finally {
        isLoading.value = false;
      }
    };

    return {
      form,
      handleSubmit,
      isLoading
    };
  },
});
</script>
