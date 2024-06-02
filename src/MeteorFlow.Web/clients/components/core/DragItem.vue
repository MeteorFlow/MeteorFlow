<script setup lang="ts" generic="T">
const props = defineProps<{
  transferData: T;
}>();

const emits = defineEmits<{
  // <eventName>: <expected arguments>
  "update:modelValue": [value: string]; // named tuple syntax
  "drag:start": [event: DragEvent];
  "drag:end": [event: DragEvent];
}>();

const handleDragStart = (event: DragEvent) => {
  event.dataTransfer?.setData("value", JSON.stringify(props.transferData));
  const target = event.target as HTMLDivElement;
  target.classList.add('itemDragged');
  emits("drag:start", event);
};

const handleDragEnd = (event: DragEvent) => {
  event.preventDefault();
  const target = event.target as HTMLDivElement;
  target.classList.remove('itemDragged');
  emits("drag:end", event);
}
</script>

<template>
  <div draggable="true" @dragstart="handleDragStart" @dragend="handleDragEnd"><slot></slot></div>
</template>
