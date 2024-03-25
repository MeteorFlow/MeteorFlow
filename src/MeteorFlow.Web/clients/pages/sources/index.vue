<script setup lang="ts">
import { ref } from "vue";

const content = ref("");

watch(content, () => {
  console.log("Content", content.value);
});
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <RtfEditor v-model="content" />
      {{ content }}
    </NuxtLayout>
  </div>
</template>
