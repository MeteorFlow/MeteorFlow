
<script setup>
import { ref } from 'vue';

const treeStructure = ref([
  {
    label: 'Root',
    isOpen: true,
    children: [
      { label: 'Child 1', children: [{ label: 'Grandchild 1' }] },
      { label: 'Child 2' }
    ],
  },
]);
</script>


<template>
  <div>
    <NuxtLayout name="default">
      <TreeView :tree-data="treeStructure" />
    </NuxtLayout>
  </div>
</template>
