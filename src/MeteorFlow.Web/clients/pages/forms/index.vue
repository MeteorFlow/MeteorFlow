<script setup lang="ts">
import type { ULink } from "#build/components";
import { FormDefinitions } from "~/data/FormDefinitions";

const deletingTemplateId = ref<string | null>(null);
const isOpeningDeleteModal = ref(false);

const formDefinitions = ref(FormDefinitions);

const deleteTemplate = () => {
  formDefinitions.value = formDefinitions.value.filter((template) => template.id !== deletingTemplateId.value);
  isOpeningDeleteModal.value = false;
};
</script>

<template>
  <div>
    <NuxtLayout>
      <div class="flex justify-between">
        <h1 class="text-2xl">Form Definitions</h1>
        <UButton icon="i-heroicons-plus"> Create new template </UButton>
      </div>

      <ul class="w-full flex flex-col gap-4">
        <li v-for="template in formDefinitions" :key="template.id" class="p-2 rounded-lg border-2 flex hover:bg-gray-50">
          <div class="flex items-center flex-grow gap-1">
            <UButton v-if="template.isDefault" icon="i-heroicons-star-solid" color="yellow" variant="ghost" />
            <UButton v-else icon="i-heroicons-star" color="yellow" variant="ghost" />

            <ULink :to="`/forms/${template.id}`" class="flex-grow">
              {{ template.name }}
            </ULink>
          </div>
          <div>
            <UButton icon="i-heroicons-pencil-square" variant="ghost" />
            <UButton
              @click="
                deletingTemplateId = template.id;
                isOpeningDeleteModal = true;
              "
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
            <UButton @click="deleteTemplate" color="red" label="Delete"></UButton>
            <UButton @click="isOpeningDeleteModal = false" variant="outline">Cancel</UButton>
          </div>
        </template>
      </CoreDialog>
    </NuxtLayout>
  </div>
</template>
