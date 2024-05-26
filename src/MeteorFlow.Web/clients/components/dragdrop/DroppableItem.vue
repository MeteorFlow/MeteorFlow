<script setup lang="ts">
const props = defineProps<{
  onDragOver: (event: DragEvent) => any;
  onDragLeave: (event: DragEvent) => any;
  onDrop: (event: DragEvent) => any;
}>();

const handleOnDragOver = (event: DragEvent) => {
  event.preventDefault();
  props.onDragOver && props.onDragOver(event);
};
</script>

<template>
  <div @dragover="handleOnDragOver" @dragleave="onDragLeave" @drop="onDrop"><slot></slot></div>
</template>
