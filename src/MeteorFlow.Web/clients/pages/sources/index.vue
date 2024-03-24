<script setup lang="ts">
import { ref } from 'vue'
const isOpen = ref(false)

const content = ref("")

watch(content, () => {
  console.log(content.value)
})
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <RtfEditor v-model="content" />
      {{ content }}

    </NuxtLayout>
  </div>
</template>