<script setup lang="ts">
import { ref } from 'vue'
const isOpen = ref(false)


</script>

<template>
  <div>
    <NuxtLayout name="default">
      <RtfEditor />
    </NuxtLayout>
  </div>
</template>