<script setup lang="ts">
import Dialog from '../../components/Dialog.vue'

const isOpen = ref(false)

</script>

<template>
  <div>
    <NuxtLayout name="default">
      <Dialog variants="confirm" v-model="isOpen" title="Confirm" size="lg" icon="i-heroicons-exclamation-triangle">
        <template #activator>
          <UButton label="Open" @click="isOpen = true" />
        </template>
        Modal
      </Dialog>
    </NuxtLayout>
  </div>
</template>