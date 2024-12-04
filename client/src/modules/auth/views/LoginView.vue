<template>
  <div class="card bg-white w-96 shadow-xl">
    <figure class="px-10 pt-10">

      <img src="@/assets/logo.png" alt="Imagen de login" />
    </figure>

    <div class="card-body items-center text-center">
      <h2 class="card-title ">Iniciar Sesión</h2>
      <Input type="correo" placeholder="correo" />
      <Input type="contraseña" placeholder="contraseña" />
      <div class="card-actions">


        <router-link to="/auth/register">
          <Button label="Iniciar sesión" class="btn btn-outline btn-info" />
        </router-link>
        <Button label="Registrarse" class="btn btn-outline btn-info" />

      </div>
    </div>

  </div>
</template>

<script>
import Button from '@/modules/home/components/Button.vue';
import Input from '../../home/components/AuthForm.vue';


export default {
  name: "Login",
  components: { Input, Button },
};
</script>
