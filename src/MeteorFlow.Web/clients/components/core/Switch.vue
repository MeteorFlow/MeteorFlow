<script setup lang="ts">
import type { Size } from '~/models';

const model = defineModel<boolean>()
const props = defineProps<{
  title?: string;
  description?: string;
  help?: string;
  required?: boolean;
  disabled?: boolean;
  size?: Size;
  icon?: string;
  iconOff?: string;
}>();
</script>

<template>
    <UFormGroup
    :label="props.title"
    :description="props.description"
    :help="props.help"
    :required="props.required"
  >
    <UToggle
      :on-icon="props.icon"
      :off-icon="props.iconOff ?? props.icon"
      v-model="model"
      :size="(props.size ?? 'md' as any)"
    />
  </UFormGroup>
</template>