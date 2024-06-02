<script setup lang="ts">
import type { FormBlock } from "~/models/Forms";



const props = defineProps<{
  block: FormBlock;
  mode: "editing" | "rendering";
}>();

const modelValue = defineModel();

const valueBind = {
  title: props.block.displayName,
  description: props.block.name,
  require: props.block.schema.required,
  disabled: props.mode === "editing",
};
</script>

<template>
  <div>
    <component
      :is="props.block.element.renderer"
      v-bind="valueBind"
      v-model="modelValue"
    ></component>
  </div>
</template>
