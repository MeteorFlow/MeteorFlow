<script setup lang="ts">
import { FormDefinitions } from "~/data/FormDefinitions";

const route = useRoute();
const formDefinition = ref(FormDefinitions.find((form) => form.id == route.params.id));
if (formDefinition === undefined) {
  await navigateTo("/forms");
}

const onDragOver = (event: DragEvent) => {
  const target = event.target as HTMLDivElement;
  target.classList.add("dragOver");
};
const onDragLeave = (event: DragEvent) => {
  event.preventDefault();
  const target = event.target as HTMLDivElement;
  target.classList.remove("dragOver");
};
const onDrop = (event: DragEvent, destIndex: number | undefined) => {
  destIndex = destIndex || 0;
  console.log(destIndex);
  const target = event.target as HTMLDivElement;
  target.classList.remove("dragOver");

  const { index } = JSON.parse(event.dataTransfer?.getData("value") || "");

  if (formDefinition.value !== undefined) {
    const newBlockList = formDefinition.value.formBlocks;
    const element = newBlockList[index];

    newBlockList.splice(index, 1);
    newBlockList.splice(destIndex > index ? destIndex - 1 : destIndex, 0, element);

    formDefinition.value.formBlocks = newBlockList;
  }
};

const submitFormDefinition = async () => {
  await navigateTo("/forms");
};
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div class="flex justify-between">
        <h1 class="text-2xl">Form Definition Details</h1>
        <UButton icon="i-heroicons-clipboard" @click="submitFormDefinition">Save</UButton>
      </div>
      <UDivider />
      <div>
        <h2 class="text-xl">
          {{ formDefinition?.name }}
        </h2>
      </div>

      <div class="flex flex-col gap-0">
        <div v-for="[index, block] in formDefinition?.formBlocks.entries()" :key="block.id">
          <DragdropDroppableItem
            :onDragOver="onDragOver"
            :onDragLeave="onDragLeave"
            :onDrop="(event) => onDrop(event as DragEvent, index)"
            class="border-2 my-px rounded border-dashed opacity-0 flex-shrink-0 flex items-center justify-center"
          >
            <UIcon name="i-heroicons-plus" class="h-5 w-5"></UIcon>
            Drop here
          </DragdropDroppableItem>

          <DragdropDraggableItem
            :transferData="{ id: block.id, index: index }"
            :onDragStart="(event: DragEvent) => (event.target as HTMLDivElement).classList.add('itemDragged')"
            :onDragEnd="(event: DragEvent) => (event.target as HTMLDivElement).classList.remove('itemDragged')"
            class="border-2 border-transparent p-1 hover:border-2 hover:border-green-500"
          >
            <CoreFormBlockRenderer mode="editing" :block="block" />
          </DragdropDraggableItem>
        </div>

        <DragdropDroppableItem
          :onDragOver="onDragOver"
          :onDragLeave="onDragLeave"
          :onDrop="(event) => {onDrop(event as DragEvent, formDefinition?.formBlocks.length)}"
          class="border-2 my-px rounded border-dashed opacity-0 flex-shrink-0 flex items-center justify-center"
        >
          <UIcon name="i-heroicons-plus" class="h-5 w-5"></UIcon>
          Drop here
        </DragdropDroppableItem>
      </div>
    </NuxtLayout>
  </div>
</template>

<style>
.itemDragged {
  opacity: 0.3;
}

.droppableShow {
  display: block;
}

.dragOver {
  opacity: 1;
}
</style>
