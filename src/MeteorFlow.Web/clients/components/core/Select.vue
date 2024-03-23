<script setup lang="tsx" generic="T extends {[key: string]: any}">
import type { JSX } from "vue/jsx-runtime";
import type { Size } from "~/models";

type Items = string[] | (T & { disabled?: boolean })[];

const modelValue = defineModel<string | number | T>();

const props = defineProps<{
  title?: string;
  description?: string;
  help?: string;
  required?: boolean;

  items: Items;
  size?: Size;
  placeholder?: string;
  multiple?: boolean;
  loading?: boolean;

  itemValue?: string & keyof T;
  itemTitle?: keyof T | ((val: Items[number]) => any);
  itemSearch?: (keyof T)[];

  searchable?: boolean | ((query: string) => any[] | Promise<any[]>);
}>();

const slots = defineSlots<{
  prepend?: () => JSX.Element | JSX.Element[];
  append?: () => JSX.Element | JSX.Element[];
}>();

const ui = {};
const searchablePlaceHolder = "Search...";

</script>
<template>
  <UFormGroup
    :label="props.title"
    :description="props.description"
    :help="props.help"
    :required="props.required"
  >
    <USelectMenu
      v-model="modelValue"
      :size="(props.size === 'full' ? '2xl' : props.size ?? 'md' as any)"
      :options="props.items"
      :multiple="props.multiple"
      :loading="props.loading"
      :placeholder="props.placeholder"
      :by="props.itemValue"
      :optionAttributes="props.itemTitle"
      :searchAttributes="props.itemSearch"
      clearSearchOnClose
      :searchable="props.searchable"
      :searchPlaceholder="searchablePlaceHolder"
    >
      <template #leading v-if="slots.prepend">
        <slot name="prepend"></slot>
      </template>
      <template #trailing v-if="slots.append">
        <slot name="append"></slot>
      </template>
    </USelectMenu>
  </UFormGroup>
</template>
