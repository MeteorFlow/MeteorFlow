<script setup lang="ts">
const props = defineProps<{
  transferData: any;
  onDragStart: (event: DragEvent) => any;
  onDragEnd: (event: DragEvent) => any;
}>();

const handleDragStart = (event: DragEvent) => {
  props.onDragStart && props.onDragStart(event);
  event.dataTransfer?.setData("value", JSON.stringify(props.transferData));
};
</script>

<template>
  <div draggable="true" @dragstart="handleDragStart" @dragend="onDragEnd"><slot></slot></div>
</template>
