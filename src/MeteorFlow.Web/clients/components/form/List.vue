<script setup lang="ts">
import { useFormStore } from "~/stores/useFormStore";

const deletingTemplateId = ref<string | null>(null);
const isOpeningDeleteModal = ref(false);

const { formDefinitions, errorMsg, actions } = useFormStore();

onBeforeMount(async () => {
  await actions.loadForms();
});

const deleteTemplate = () => {
  if (!deletingTemplateId.value) return;
  actions
    .deleteForm(deletingTemplateId.value)
    .then(() => (isOpeningDeleteModal.value = false));
};
</script>

<template>
  <div>
    <div class="flex justify-between">
      <h1 class="text-2xl">Form Definitions</h1>
      <UButton icon="i-heroicons-plus"> Create new template </UButton>
    </div>
    <ul v-if="errorMsg == null" class="w-full flex flex-col gap-4">
      <li
        v-for="template in formDefinitions"
        :key="template.id"
        class="p-2 rounded-lg border-2 flex hover:bg-gray-50"
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
            @click="deleteTemplate"
            icon="i-heroicons-trash"
            color="red"
            variant="ghost"
          />
        </div>
      </li>
    </ul>
    <CoreDialog
      v-model="isOpeningDeleteModal"
      size="lg"
      title="Deleting a template"
      icon="i-heroicons-exclamation-triangle"
      variants="warning"
    >
      Are you sure you want to delete this ID
      <template #actions>
        <div class="flex flex-row-reverse gap-1">
          <UButton @click="" color="red" label="Delete"></UButton>
          <UButton @click="isOpeningDeleteModal = false" variant="outline"
            >Cancel</UButton
          >
        </div>
      </template>
    </CoreDialog>
  </div>
</template>
