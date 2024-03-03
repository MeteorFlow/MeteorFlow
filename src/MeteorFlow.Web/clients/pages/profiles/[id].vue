<script setup lang="ts">
import Dialog from '../../components/Dialog.vue'
definePageMeta({
  layout: 'landing'
})

const isOpen = ref(false)

</script>

<template>
  <NuxtLayout name="default">
    <Dialog variants="confirm" v-model="isOpen" title="Confirm" size="lg" icon="i-heroicons-exclamation-triangle-20-solid">
      <template #activator>
        <UButton label="Open" @click="isOpen = true" />
      </template>
      Modal
    </Dialog>
  </NuxtLayout>
</template>