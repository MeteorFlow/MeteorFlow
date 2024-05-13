<script setup lang="ts">
// Interface for link data
interface Link {
  label: string;
  to?: string; // Optional link target
  target?: string; // Optional link target attribute (e.g., "_blank")
  children?: Link[]; // Optional child links for sub-menus
}

const props = defineProps<{
  links: Link[];
}>();
</script>

<template>
  <div class="container mx-auto py-4">
    <div class="flex flex-row justify-between">
      <slot name="left" class="justify-self-start" />
      <ul v-for="column in props.links" :key="column.label">
        <li class="text-lg font-bold mb-2">{{ column.label }}</li>
        <ul v-if="column.children">
          <li v-for="child in column.children" :key="child.label">
            <a
              :href="child.to"
              target="{{ child.target || '_self' }}"
              class="text-gray-700 hover:text-blue-500"
            >
              {{ child.label }}
            </a>
          </li>
        </ul>
      </ul>
      <slot name="right" />
    </div>
  </div>

  <footer class="container mx-auto py-4 border-t border-gray-600">
    <div class="flex justify-between items-center">
      <div>
        <slot name="footer-left"></slot>
      </div>
      <div>
        <slot name="footer-right"></slot>
      </div>
    </div>
  </footer>
</template>
