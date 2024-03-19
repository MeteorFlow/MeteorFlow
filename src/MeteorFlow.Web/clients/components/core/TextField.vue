<script setup lang="ts">
import type { Size, TextFieldVariants, ValidateFunction, Validation } from "~/models";

const validator = useValidation();

const modelValue = defineModel<string>();
const props = defineProps<{
  title?: string;
  description?: string;
  help?: string;
  required?: boolean;
  rules?: ValidateFunction[];

  size?: Size;
  filled?: boolean;
  variant?: TextFieldVariants;
  icon?: string;
  placeholder?: string;

  options?: string[];
}>();

const id = `text-field-${useId()}`;

const state = useState(id, () => ({
  icon: undefined as string | undefined,
  placeholder: undefined as string | undefined,
  error: false as false | string
}));

switch (props.variant) {
  case "search":
    state.value.placeholder = "Search...";
    state.value.icon = "i-heroicons-magnifying-glass-20-solid";
    break;
  case "file":
    state.value.placeholder = "File...";
    state.value.icon = "i-heroicons-document-text-20-solid";
    break;
  case "email":
    state.value.placeholder = "you@example.com";
    state.value.icon = "i-heroicons-envelope-20-solid";
    validator.apply(validator.createRules().email());
    break
  case "password":
    state.value.placeholder = "********";
    state.value.icon = "i-heroicons-lock-closed-20-solid";
    validator.apply(validator.createRules().password());
    break
  default:
    state.value.placeholder = props.placeholder;
    state.value.icon = props.icon;
    props.rules?.forEach(validator.apply)
}

watch(modelValue, async () => {
  state.value.error = await validator.hasErrors(modelValue.value);
});

</script>

<template>
  <UFormGroup
    :label="props.title"
    :description="props.description"
    :help="props.help"
    :required="props.required"
    :error="state.error"
  >
    <UInput
      v-if="!props.options"
      v-model="modelValue"
      :icon="state.icon"
      :size="(props.size === 'full' ? '2xl' : props.size ?? 'md' as any)"
      :color="props.filled ? 'gray' : 'white'"
      :trailing="false"
      :placeholder="state.placeholder"
    />
    <UInputMenu
      v-else
      v-model="modelValue"
      :size="(props.size === 'full' ? '2xl' : props.size ?? 'md' as any)"
      :color="props.filled ? 'gray' : 'white'"
      :trailing="false"
      :placeholder="state.placeholder"
      :options="props.options"
    />
  </UFormGroup>
</template>
