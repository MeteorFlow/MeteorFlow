<script setup lang="ts">
const links = [
  {
    label: "Profile",
    avatar: {
      src: "https://avatars.githubusercontent.com/u/739984?v=4",
    },
    badge: 100,
  },
  {
    label: "Dashboard",
    icon: "i-heroicons-chart-bar",
    to: "/dashboard",
  },
  {
    label: "API",
    icon: "i-heroicons-code-bracket",
    to: "/api",
  },
  {
    label: "Integration",
    icon: "i-fa6-solid-code-pull-request",
    to: "/integration",
  },
  {
    label: "Extensions",
    icon: "i-fa6-solid-puzzle-piece",
    to: "/extensions",
  },
  {
    label: "Settings",
    icon: "i-fa6-solid-gear",
    to: "/settings",
  },
  {
    label: "Sources",
    icon: "i-heroicons-command-line",
    to: "/sources",
  },
];

const ui = {
  wrapper: "relative px-4 w-1/6",
  padding: "px-2.5 py-1.5 ",
};
</script>

<template>
  <div class="h-screen flex flex-row">
    <UVerticalNavigation :links="links" :ui="ui" />
    <div class="w-full flex flex-col gap-4 p-4 border-slate-600 border-s-2">
      <slot></slot>
    </div>
  </div>
</template>
