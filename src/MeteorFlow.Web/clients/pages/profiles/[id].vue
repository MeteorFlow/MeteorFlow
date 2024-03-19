<script setup lang="ts">
definePageMeta({
  layout: 'landing'
})

const people = ['Wade Cooper', 'Arlene Mccoy', 'Devon Webb', 'Tom Cook', 'Tanya Fox', 'Hellen Schmidt', 'Caroline Schultz', 'Mason Heaney', 'Claudie Smitham', 'Emil Schaefer']

const selected = ref(people[0])
const isOpen = ref(false)

</script>

<template>
  <NuxtLayout name="default">
    <CoreDialog variants="confirm" v-model="isOpen" title="Confirm" size="lg" icon="i-heroicons-exclamation-triangle-20-solid">
      <template #activator>
        <UButton label="Open" @click="isOpen = true" />
      </template>
      Modal
    </CoreDialog>
    <CoreSelect v-model="selected" :items="people" multiple placeholder="Select people" />
  </NuxtLayout>
</template>