<script setup lang="ts">
definePageMeta({
  middleware: process.client ? "auth" : undefined,
  // or middleware: 'auth'
});

import type { FormElement } from "~/models/Forms";
import { useFormStore } from "~/stores/useFormStore";

const store = useFormStore();
const { actions, get } = store;
await actions.loadForms();
await actions.loadElements();
const route = useRoute();
const { state, formsBlocks } = storeToRefs(store);

const id = computed(() => route.params.id as string);

const formDefinition = computed(
  () =>
    state.value.formDefinitions.find(
      (form) => form.latestVersionId === id.value
    ) ?? null
);

const formBlocks = computed(() => formsBlocks.value[id.value] ?? []);

watch(formBlocks, async () => {
  console.log("formBlocks", formBlocks.value);
  await actions.loadFormBlocks(id.value);
}, { immediate: true });

const onDrop = (event: DragEvent, destIndex: number | undefined) => {
  destIndex = destIndex || 0;
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
    formsBlocks.value[id.value] = newBlockList; // update from store
  }
};

const addNewBlock = (value: FormElement) => {
  state.value.seletedVersionId = id.value;
  const block = get.defaultBlock(value);

  if (!block) {
    return;
  }
  actions.addBlock(block);
};

const submitFormDefinition = async () => {
  await navigateTo("/forms");
};
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div v-if="!state.loading">
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

        <div class="grid grid-cols-3 h-full overflow-hidden gap-4">
          <div class="flex-shrink-0 overflow-auto">
            <FormLeftPanel
              @click:add="addNewBlock"
              :formElements="state.formElements"
            />
          </div>
          <div class="flex flex-col overflow-auto max-h-full">
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
                <CoreFormBlockRenderer
                  v-show="block.element"
                  mode="editing"
                  :block="block"
                />
              </CoreDragItem>
            </div>
          </div>
          <div class="flex-shrink-0 overflow-auto">
            <FormRightPanel />
          </div>
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
