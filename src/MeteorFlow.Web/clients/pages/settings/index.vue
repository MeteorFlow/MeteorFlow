<script setup lang="ts">
import { ref } from "vue";
import Tabs from "~/components/core/Tabs.vue";

const isOpen = ref(false);

const items = [
  {
    label: "Info",
    icon: "i-fa6-solid-info",
    slot: "tab1",
  },
  {
    label: "Authentication",
    icon: "i-fa6-solid-lock",
    slot: "tab2",
  },
];
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <Tabs :items="items">
        <template #tab1>
          <h1>Basic Info</h1>
          <CoreDialog variants="confirm" v-model="isOpen" title="Confirm" size="lg" icon="i-heroicons-exclamation-triangle">
            <template #activator>
              <UButton label="Open" @click="isOpen = true" />
            </template>
            Modal
          </CoreDialog>
        </template>

        <template #tab2>
          <h1>Related settings for Authentication</h1>
        </template>
      </Tabs>
    </NuxtLayout>
  </div>
</template>
