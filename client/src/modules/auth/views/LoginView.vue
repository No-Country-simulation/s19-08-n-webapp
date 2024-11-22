<script setup lang="ts"></script>

<template>
  <div class="flex items-center justify-center h-screen bg-gray-100">
    <div class="card bg-base-100 shadow-xl w-full max-w-4xl flex flex-col lg:flex-row">
      <!-- Imagen -->
      <figure class="w-full lg:w-1/2">
        <img src="@/assets/logo.png" alt="Imagen de login"
          class="w-full h-64 lg:h-full object-contain lg:object-cover" />
      </figure>
      <!-- Formulario -->
      <div class="card-body w-full lg:w-1/2 flex flex-col justify-center">
        <h2 class="text-center text-2xl font-bold">Iniciar Sesión</h2>
        <form>
          <div class="form-control w-full max-w-xs mx-auto">
            <label class="label">
              <span class="label-text">Correo Electrónico</span>
            </label>
            <input type="email" placeholder="ejemplo@correo.com" class="input input-bordered w-full" />
          </div>
          <div class="form-control w-full max-w-xs mt-4 mx-auto">
            <label class="label">
              <span class="label-text">Contraseña</span>
              <span class="label-text-alt">
                <a href="#" class="link link-hover">¿Olvidaste tu contraseña?</a>
              </span>
            </label>
            <input type="password" placeholder="••••••••" class="input input-bordered w-full" />
          </div>
          <div class="form-control mt-6 mx-auto w-full max-w-xs">
            <button type="submit" class="btn btn-primary w-full">
              Iniciar Sesión
            </button>
          </div>
        </form>
        <div class="divider">O</div>
        <div class="form-control mt-2 mx-auto w-full max-w-xs">
          <button class="btn btn-outline w-full">Registrarse</button>
        </div>
      </div>
    </div>
  </div>
</template>
