<script setup lang="ts">
import type { FormBlock } from "~/models/FormDefinition";
import { InputType } from "~/models/FormDefinition";

const props = defineProps<{
  block: FormBlock;
  mode: "editing" | "rendering";
}>();
</script>

<template>
  <div>
    <label>{{ props.block.displayName }}</label>
    <div v-if="props.block.element.schema.inputType === InputType.Text">
      <CoreTextField :disabled="props.mode === 'editing' || props.block.extraConfig?.disabled" config class="disabled:cursor-pointer"></CoreTextField>
    </div>
    <div v-else-if="props.block.element.schema.inputType === InputType.Select">
      <CoreSelect :items="['123', '456']"></CoreSelect>
    </div>
  </div>
</template>
