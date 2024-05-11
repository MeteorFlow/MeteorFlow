<script setup lang="ts">
const route = useRoute();
useSeoMeta({
  ogImage: "/headline.jpeg",
});

const landingPath = "/";

const links = [
  [
    {
      to: landingPath,
    },
  ],
  [
    {
      label: "Dashboard",
      to: "/dashboard",
    },
    {
      label: "Horizontal Navigation",
      to: "/dashboard",
    },
    {
      label: "Command Palette",
      to: "/dashboard",
    },
  ],
  [
    {
      label: "Examples",
      icon: "i-heroicons-light-bulb",
    },
    {
      label: "Help",
      icon: "i-heroicons-question-mark-circle",
    },
  ],
];

const ui = {
  base: "group relative w-full flex items-center gap-1.5 px-2.5 py-3.5",
  before: "",
  after: "",
};
</script>

<template>
  <div>
    <UHorizontalNavigation :links="links" :ui="ui">
      <template #default="{ link }">
        <div v-if="link.to === landingPath">
          <LandingLogo />
        </div>
        <span v-else class="group-hover:text-primary relative">{{
          link.label
        }}</span>
      </template>
    </UHorizontalNavigation>
    <div class="w-full flex flex-col gap-4 p-4">
      <slot></slot>
    </div>
  </div>
</template>
