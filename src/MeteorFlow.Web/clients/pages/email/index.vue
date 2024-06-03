<template>
  <div>
    <NuxtLayout name="default">
      <div class="flex justify-between items-center py-4">
        <h2 class="text-2xl font-semibold">Inbox</h2>
        <UButton class="px-4 py-2 rounded dark:text-white">Create New Template</UButton>
      </div>
      <div class="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-4">
        <EmailCard
          v-for="template in templates"
          :key="template.id"
          :template="template"
        />
      </div>
    </NuxtLayout>
  </div>
</template>

<script setup>
definePageMeta({
  middleware: process.client ? 'auth' : undefined
  // or middleware: 'auth'
})

const templates = ref([
  { id: 1, title: "Welcome Email", content: "Hello, welcome to our service!" },
  { id: 2, title: "Weekly Update", content: "Here is your weekly update." },
  // Add more templates as needed
]);
</script>
