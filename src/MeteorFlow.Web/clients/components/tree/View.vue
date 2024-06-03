<template>
  <div>
    <ul class="pl-4">
      <li v-for="(node, index) in treeData" :key="index" class="mt-2">
        <div @click="node.children && toggle(node)" class="cursor-pointer flex items-center">
          <span v-if="node.children" class="mr-2">{{ node.isOpen ? '-' : '+' }}</span>
          {{ node.label }}
        </div>
        <tree-view v-if="node.isOpen && node.children" :tree-data="node.children" />
      </li>
    </ul>
  </div>
</template>

<script setup>
import { defineProps, reactive } from 'vue';

const props = defineProps({
  treeData: {
    type: Array,
    required: true,
  }
});

const treeData = reactive(props.treeData);

function toggle(node) {
  node.isOpen = !node.isOpen;
}
</script>

<style scoped>
/* Add styles here if needed */
</style>
