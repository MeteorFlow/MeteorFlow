<template>
  <div class="bg-white dark:bg-gray-800 rounded-lg shadow p-6 max-w-md ">
    <div class="flex items-center space-x-4">
      <template v-if="isIcon">
        <span :class="icon" class="text-3xl"></span> <!-- Adjust text size as needed -->
      </template>
      <template v-else>
        <UAvatar :src="icon" alt="Avatar" imgClass="object-cover" size="md" /> <!-- NuxtImg for better performance and optimization -->
      </template>
      <div>
        <h3 class="font-semibold text-lg dark:text-white">{{ title }}</h3>
        <p class="text-gray-500 dark:text-gray-400">{{ description }}</p>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { computed } from 'vue';

const props = defineProps<{
  title: string,
  description: string,
  icon: string,
}>();

const isIcon = computed(() => {
  // Check if the icon prop is an icon class, typical icon class format is "i-{library}-{style}-{name}"
  return props.icon.startsWith('i-');
});
</script>