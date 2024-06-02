<script setup lang="ts">
import { DefinitionTypes, type Definition } from "~/models/Definition";
import { useFormStore } from "~/stores/useFormStore";

const deletingTemplateId = ref<string | null>(null);
const isOpeningDeleteModal = ref(false);

const store = useFormStore();
const actions = store.actions;

const { state } = storeToRefs(store);

const selectTemplate = (id?: string) => {
  deletingTemplateId.value = id ?? null;
  isOpeningDeleteModal.value = true;
}

const deleteTemplate = () => {
  if (!deletingTemplateId.value) return;
  actions
    .deleteForm(deletingTemplateId.value)
    .then(() => (isOpeningDeleteModal.value = false));
};

const createTemplate = () => {
  const data: Definition = {
    name: "New Form",
    description: "Description",
    appVersionControls: [BaseVersion],
    definitionType: DefinitionTypes.Form,
  };
  actions.addForm(data);
};
</script>

<template>
  <div>
    <NuxtLayout>
      <div class="flex justify-between">
        <h1 class="text-2xl">Form Templates</h1>
        <UButton
          @click="createTemplate"
          icon="i-heroicons-plus"
          class="dark:text-white bg-primary hover:bg-transparent"
        >
          Create new template
        </UButton>
      </div>

      <div v-if="!state.errorMsg" class="flex flex-col gap-4">
        <div
          v-for="template in state.formDefinitions"
          :key="template.id"
          class="p-2 rounded-lg border-2 flex"
          @click="
            () => {
              state.seletedVersionId = template.latestVersionId ?? '';
            }
          "
        >
          <div class="flex items-center flex-grow gap-1">
            <UButton icon="i-heroicons-star" color="yellow" variant="ghost" />

            <ULink :to="`/forms/${template.latestVersionId}`" class="flex-grow">
              {{ template.name }}
            </ULink>
          </div>
          <div>
            <UButton icon="i-heroicons-pencil-square" variant="ghost" />
            <UButton
              @click="() => selectTemplate(template.id)"
              icon="i-heroicons-trash"
              color="red"
              variant="ghost"
            />
          </div>
        </div>
        <CoreDialog
          v-model="isOpeningDeleteModal"
          size="lg"
          title="Deleting a template"
          icon="i-heroicons-exclamation-triangle"
          variants="warning"
        >
          Are you sure you want to delete this template?
          <template #actions>
            <div class="flex flex-row-reverse gap-1">
              <UButton @click="deleteTemplate" color="red" label="Delete"></UButton>
              <UButton @click="isOpeningDeleteModal = false" variant="outline"
                >Cancel</UButton
              >
            </div>
          </template>
        </CoreDialog>
      </div>
    </NuxtLayout>
  </div>
</template>
