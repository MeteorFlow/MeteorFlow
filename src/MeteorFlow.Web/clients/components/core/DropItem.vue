<script setup lang="ts">
const emits = defineEmits<{
  (e: "drop", event: DragEvent, destIndex?: number): void;
  (e: "drag:over", event: DragEvent): void;
  (e: "drag:leave", event: DragEvent): void;
}>();

const handleOnDragOver = (event: DragEvent) => {
  event.preventDefault();
  const target = event.target as HTMLDivElement;
  target.classList.add("dragOver");
  emits("drag:over", event);
};

const handleDragLeave = (event: DragEvent) => {
  event.preventDefault();
  const target = event.target as HTMLDivElement;
  target.classList.remove("dragOver");
  emits("drag:leave", event);
};

const onDrop = (event: DragEvent, destIndex?: number) => {
  event.preventDefault();
  destIndex = destIndex || 0;
  console.log(destIndex);
  const target = event.target as HTMLDivElement;
  target.classList.remove("dragOver");

  const { index } = JSON.parse(event.dataTransfer?.getData("value") || "");
  emits("drop", event, index);
};
</script>

<template>
  <div @dragover="handleOnDragOver" @dragleave="handleDragLeave" @drop="onDrop">
    <slot></slot>
  </div>
</template>
