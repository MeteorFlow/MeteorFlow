<template>
  <CoreCard :title="template.title" size="md">
    <template #default>
      <div class="text-gray-700">{{ template.content }}</div>
    </template>
    <template #footer>
      <div class="flex flex-row justify-end">
        <UButton variant="success" class="mr-2">Edit</UButton>
        <UButton variant="danger">Delete</UButton>
      </div>
    </template>
  </CoreCard>
</template>

<script setup>

const props = defineProps({
  template: {
    type: Object,
    required: true,
  },
});
</script>
