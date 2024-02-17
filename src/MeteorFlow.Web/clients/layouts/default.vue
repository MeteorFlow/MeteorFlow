<script setup lang="ts">
const route = useRoute()

const links = [{
  label: 'Profile',
  avatar: {
    src: 'https://avatars.githubusercontent.com/u/739984?v=4'
  },
  badge: 100
}, {
  label: 'Dashboard',
  icon: 'i-heroicons-chart-bar',
  to: '/dashboard'
}, {
  label: 'API',
  icon: 'i-heroicons-code-bracket',
  to: '/api'
}, {
  label: 'Integration',
  icon: 'i-fa6-solid-code-pull-request',
  to: '/integration'
}, {
  label: 'Sources',
  icon: 'i-heroicons-command-line',
  to: '/sources'
}]

const ui = {
  
}
</script>

<template>
  <div class="h-screen flex flex-row">
    <UVerticalNavigation :links="links" :ui="ui"/>
    <div class="w-full flex flex-col gap-4 p-4 border-slate-600 border-s-2">
      <slot />
    </div>
  </div>
</template>

