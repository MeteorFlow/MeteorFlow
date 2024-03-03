<script setup lang="ts">
import { UCard } from "#components";
import type { Layout } from "~/models";

const props = defineProps<Layout>()

</script>

<template>
  <grid-item v-bind="props">
    <UCard>
      <template #header>
        <slot name="header"></slot>
      </template>
      <slot></slot>
      <template #footer>
        <slot name="footer"></slot>
      </template>
    </UCard>
  </grid-item>
</template>

