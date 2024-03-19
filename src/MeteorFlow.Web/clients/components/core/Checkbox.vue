<script setup lang="ts">
import type { Size, ValidateFunction } from "~/models";
const model = defineModel<boolean>();
const props = defineProps<{
  title?: string;
  description?: string;
  help?: string;
  required?: boolean;
  disabled?: boolean;
}>();

const id = `checkbox-${useId()}`;

const state = useState(id, () => ({
  icon: undefined as string | undefined,
  placeholder: undefined as string | undefined,
  error: false as false | string,
}));
</script>
<template>
  <UCheckbox
    :label="props.title"
    :description="props.description"
    :help="props.help"
    v-model="model"
    :required="props.required"
    :disabled="props.disabled"
  />
</template>
