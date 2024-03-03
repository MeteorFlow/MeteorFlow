<script setup lang="tsx">
import { UCard } from "#components";
import type { JSX } from "vue/jsx-runtime";
import type { CardVariants, Size } from "~/models";

const props = defineProps<{
  size?: Size;
  title: string;
  icon?: string;
}>();

const slots = defineSlots<{
  default?: () => JSX.Element | JSX.Element[];
  footer?: () => JSX.Element | JSX.Element[];
}>();

const ui = {
  body: {
  },
};
</script>

<template>
  <div :class="useSize(props.size ?? 'md')">
    <UCard :ui="ui">
      <template #header>
        <div class="flex justify-start items-center space-x-4">
          <Icon v-if="props.icon" :name="props.icon" />
          <div class="text-lg">{{ props.title }}</div>
        </div>
      </template>

      <slot></slot>

      <template #footer v-if="slots.footer"> 
        <slot name="footer"></slot>
      </template>
    </UCard>
  </div>
</template>