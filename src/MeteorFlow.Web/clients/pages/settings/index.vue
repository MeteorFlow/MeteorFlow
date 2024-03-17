<script setup lang="ts">
import { ref } from 'vue';

const isOpen = ref(false)

</script>

<template>
  <div>
    <NuxtLayout name="default">
      <CoreDialog variants="confirm" v-model="isOpen" title="Confirm" size="lg" icon="i-heroicons-exclamation-triangle">
        <template #activator>
          <UButton label="Open" @click="isOpen = true" />
        </template>
        Modal
      </CoreDialog>
    </NuxtLayout>
  </div>
</template>