<template>
  <div class="card bg-white w-96 shadow-xl">
    <figure class="px-10 pt-10">
      <img src="@/assets/logo.png" alt="Imagen de login" />
    </figure>

    <div class="card-body items-center text-center">
      <h2 class="card-title">Iniciar Sesión</h2>
      <form @submit.prevent="handleSubmit">
        <!-- Campo de username -->
        <Input type="text" placeholder="Username" id="username" v-model="form.username" required
          autocomplete="username" />
        <!-- Campo de contraseña -->
        <Input type="password" placeholder="Contraseña" id="password" v-model="form.password" required
          autocomplete="current-password" />
        <!-- Botones -->
        <div class="card-actions">
          <button type="submit" class="btn btn-outline btn-info">Iniciar sesión</button>
          <router-link to="/auth/register">
            <button type="button" class="btn btn-outline btn-info">Registrarse</button>
          </router-link>
        </div>
      </form>
      <!-- Mensaje de error -->
      <p v-if="error" class="text-red-500">{{ error }}</p>
    </div>
  </div>
</template>

<script lang="ts">

import { defineComponent, reactive, ref } from 'vue';
import { useAuthStore } from '../stores/auth.store';
import Input from "../components/AuthForm.vue";
import Button from "../components/Button.vue";

export default defineComponent({
  name: 'LoginForm',
  components: { Input, Button },
  setup() {
    const authStore = useAuthStore();
    const form = reactive({
      username: '',
      password: '',
    });
    const error = ref('');

    const handleSubmit = async () => {
      if (!form.username || !form.password) {
        error.value = 'Por favor, complete todos los campos.';
        return;
      }

      try {
        console.log('Datos del formulario:', form); // Muestra los datos enviados
        await authStore.loginAction(form); // Llama a la acción del store
        console.log('Login exitoso');
        // Redirigir a la página principal o dashboard
      } catch (err: any) {
        error.value = err.response?.data?.message || 'Credenciales incorrectas o error del servidor';
        console.error('Error en el login:', err);
      }
    };

    return { form, handleSubmit, error };
  },
});

</script>
<style scoped>
.text-red-500 {
  color: red;
}
</style>
