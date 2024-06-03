<template>
  <div>
    <NuxtLayout name="default">
      <UHeading level="2" class="mb-4">Email Template Designer</UHeading>
      <CoreCard title="Design Your Email Template" size="lg">
        <template #default>
        <form @submit.prevent="saveTemplate">
          <div class="mb-4">
            <UFormField label="Recipient">
              <UInput v-model="form.recipient" placeholder="Recipient email" required />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="From">
              <UInput v-model="form.from" placeholder="Sender email" required />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="To">
              <UInput v-model="form.to" placeholder="To email" required />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="CC">
              <UInput v-model="form.cc" placeholder="CC emails" />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="BCC">
              <UInput v-model="form.bcc" placeholder="BCC emails" />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="Placeholder">
              <UInput v-model="form.placeholder" placeholder="Placeholder text" />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="Files">
              <UInput type="file" @change="handleFileUpload" multiple />
            </UFormField>
          </div>
          <div class="mb-4">
            <UFormField label="Email Content">
              <Rte v-model:modelValue="form.content" />
            </UFormField>
          </div>
          <div class="flex justify-end">
            <UButton type="submit" variant="primary">Save Template</UButton>
          </div>
        </form>
      </template>
      </CoreCard>
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
definePageMeta({
  middleware: process.client ? 'auth' : undefined
  // or middleware: 'auth'
})

const form = ref({
  recipient: '',
  from: '',
  to: '',
  cc: '',
  bcc: '',
  placeholder: '',
  files: [] as File[],
  content: '',
})

function handleFileUpload(event: Event) {
  const target = event.target as HTMLInputElement
  if (target.files) {
    form.value.files = Array.from(target.files)
  }
}

function saveTemplate() {
  // Handle saving the template
  console.log("Template content:", form.value);
}
</script>
