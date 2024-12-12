<template>
  <div
    class="min-h-screen w-full flex items-center bg-gradient-shapes animate__animated animate__fadeIn animate__faster"
  >
    <main class="max-w-2xl w-full mx-auto p-2.5">
      <router-view />
    </main>
  </div>
</template>

<style lang="css" scoped>
.bg-gradient-shapes {
  background-size: 100% 100%;
  background-position:
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px,
    0px 0px;
  background-image: radial-gradient(18% 28% at 24% 50%, #cefaff47 0%, #073aff00 100%),
    radial-gradient(18% 28% at 18% 71%, #ffffff59 6%, #073aff00 100%),
    radial-gradient(70% 53% at 36% 76%, #00a6ffff 0%, #073aff00 100%),
    radial-gradient(42% 53% at 15% 94%, #ffffffff 7%, #073aff00 100%),
    radial-gradient(42% 53% at 34% 72%, #ffffffff 7%, #073aff00 100%),
    radial-gradient(18% 28% at 35% 87%, #ffffffff 7%, #073aff00 100%),
    radial-gradient(31% 43% at 7% 98%, #ffffffff 24%, #073aff00 100%),
    radial-gradient(21% 37% at 72% 23%, #ffca6d9c 24%, #073aff00 100%),
    radial-gradient(35% 56% at 91% 74%, #7978fdf5 9%, #073aff00 100%),
    radial-gradient(74% 86% at 67% 38%, #faa80ef5 24%, #073aff00 100%),
    linear-gradient(101deg, #4e73ffff 1%, #ff5d00ff 99%);
}
</style>
