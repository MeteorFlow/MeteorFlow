<script setup lang="ts">
import { useFormStore } from '~/stores/useFormStore';

const { formDefinitions, errorMsg, actions } = useFormStore();
</script>

<template>
  <div>
    <NuxtLayout>
      <FormList v-if="formDefinitions" />
    </NuxtLayout>
  </div>
</template>
