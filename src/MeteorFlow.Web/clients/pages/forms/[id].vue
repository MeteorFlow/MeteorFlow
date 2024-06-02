<script setup lang="ts">
import type { FormBlock } from "~/models/Forms";
import { useFormStore } from "~/stores/useFormStore";

const store = useFormStore();
const route = useRoute();
const { state } = storeToRefs(store);

const id = computed(() => route.params.id as string);

const formDefinition = computed(
  () =>
    state.value.formDefinitions.find(
      (form) => form.latestVersionId === id.value
    ) ?? null
);

const formBlocks = computed(() => {
  return state.value.formsBlocks[id.value] ?? [];
});


const onDrop = (event: DragEvent, destIndex: number | undefined) => {
  destIndex = destIndex || 0;
  console.log(destIndex);
  const target = event.target as HTMLDivElement;
  target.classList.remove("dragOver");

  const { index } = JSON.parse(event.dataTransfer?.getData("value") || "");

  if (formDefinition) {
    const newBlockList = formBlocks.value;
    const element = newBlockList[index];

    newBlockList.splice(index, 1);
    newBlockList.splice(
      destIndex > index ? destIndex - 1 : destIndex,
      0,
      element
    );
    state.value.formsBlocks[id.value] = newBlockList; // update from store
  }
};

const addNewBlock = () => {
  // const newBlock: FormBlock = {};
  // state.value.formsBlocks[id.value] = [...formBlocks.value, newBlock];
};

const submitFormDefinition = async () => {
  await navigateTo("/forms");
};
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div class="flex justify-between">
        <h1 class="text-2xl">Editing {{ formDefinition?.name }}</h1>
        <UButton
          icon="i-heroicons-clipboard"
          class="dark:text-white bg-primary hover:bg-transparent"
          @click="submitFormDefinition"
          >Save</UButton
        >
      </div>
      <UDivider />

      <div class="flex flex-col gap-0">
        <div v-for="(block, index) in formBlocks" :key="block.id">
          <CoreDropItem
            @drop="(event) => onDrop(event as DragEvent, index)"
            class="border-2 my-px rounded border-dashed opacity-0 flex-shrink-0 flex items-center justify-center"
          >
            <UIcon name="i-heroicons-plus" class="h-5 w-5"></UIcon>
            <span>Drop here</span>
          </CoreDropItem>
          <CoreDragItem
            :transferData="{ id: block.id, index }"
            class="border-2 border-transparent p-1 hover:border-2 hover:border-primary"
          >
            <CoreFormBlockRenderer mode="editing" :block="block" />
          </CoreDragItem>
        </div>
        <div class="pl-2 pt-4">
          <UButton
            icon="i-heroicons-plus"
            class="dark:text-white bg-primary hover:bg-transparent"
            @click="addNewBlock"
          >
            Add Block
          </UButton>
        </div>
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
