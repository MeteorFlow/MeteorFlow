<script setup lang="ts">
useSeoMeta({
  title: "MeteorFlow",
  ogTitle: "Data Science with MeteorFlow",
  description: "This is my amazing site, let me tell you all about it.",
  ogDescription: "This is my amazing site, let me tell you all about it.",
});
</script>

<template>
  <div>
    <NuxtLayout name="landing">
      <div
        class="py-24 sm:py-32 md:py-40 relative dark:bg-gradient-to-b from-gray-950 to-gray-900"
      >
        <div
          class="mx-auto px-4 sm:px-6 lg:px-8 max-w-7xl gap-16 sm:gap-y-24 flex flex-col"
        >
          <div class="text-center relative z-[1]">
            <h1
              class="text-5xl font-bold tracking-tight text-gray-900 dark:text-white sm:text-7xl"
            >
              Streamline Your Meteorological Workflows
            </h1>
            <p
              class="mt-6 text-lg tracking-tight text-gray-600 dark:text-gray-300"
            >
              MeteorFlow is a cloud-based platform designed to streamline your
              work with weather data. Easily access, manage, analyze, and
              automate meteorological workflows, empowering you to gain deeper
              insights and make data-driven decisions faster.
            </p>
          </div>

          <div
            class="mt-10 flex flex-wrap gap-x-6 gap-y-3 justify-center"
          ></div>
        </div>
      </div>
      <div class="py-24 sm:py-32 dark:bg-gray-900"></div>
      <div class="py-24 sm:py-32 dark:bg-gray-900"></div>
      <div class="py-24 sm:py-32 dark:bg-gray-900"></div>
    </NuxtLayout>
  </div>
</template>
