<script setup lang="ts">
import LogOutIcon from '../icons/LogOutIcon.vue';
import ThemeController from './ThemeController.vue';
</script>

<template>
  <header class="navbar bg-base-100">
    <div class="flex-1">
      <a class="btn btn-ghost text-xl">FreeConnect</a>
    </div>
    <div class="flex-none gap-2">
      <div class="form-control">
        <input
          type="search"
          placeholder="Buscar"
          class="input input-bordered w-24 md:w-auto bg-base-200"
        />
      </div>
      <div class="dropdown dropdown-end">
        <div tabindex="0" role="button" class="btn btn-ghost btn-circle avatar">
          <div class="w-10 rounded-full">
            <img
              alt="Tailwind CSS Navbar component"
              src="https://img.daisyui.com/images/stock/photo-1534528741775-53994a69daeb.webp"
            />
          </div>
        </div>
        <ul
          tabindex="0"
          class="menu menu-md dropdown-content bg-base-100 rounded-box z-[1] mt-3 w-52 p-2 shadow-lg shadow-base-300"
        >
          <li>
            <a>Perfil</a>
          </li>
          <li>
            <div class="justify-between !cursor-auto">
              Aspecto
              <theme-controller />
            </div>
          </li>
          <li>
            <div class="justify-between">
              <span>Cerrar sesión</span>
              <log-out-icon class="w-4 h-4" />
            </div>
          </li>
        </ul>
      </div>
    </div>
  </header>
</template>
