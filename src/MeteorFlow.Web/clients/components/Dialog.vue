<script setup lang="tsx">
import { UButton } from '#components';
import type { JSX } from 'vue/jsx-runtime';
import type { DialogVariants, Size } from '~/models';

const modelValue = defineModel<boolean>()

const props = defineProps<{
  size: Size,
  title: string,
  icon: string,
  variants: DialogVariants
}>()

const emit = defineEmits([ 'update:modelValue' ])

const slots = defineSlots<{
  default: () => JSX.Element | JSX.Element[]
  activator: () => JSX.Element | JSX.Element[]
  actions: () => JSX.Element | JSX.Element[]
}>()

</script>

<template>
  <div>
    <slot name="activator"></slot>

    <UModal v-model="modelValue" prevent-close>
      <UCard :ui="{ ring: '', divide: 'divide-y divide-gray-100 dark:divide-gray-800' }">
        <template #header>
          <!-- <Placeholder class="h-8" /> -->
          <div class="flex justify-between items-center">
            <Icon :name="props.icon" />
            <div class="text-lg">{{ props.title }}</div>
            <UButton color="gray" variant="ghost" icon="i-heroicons-x-mark-20-solid" @click="emit('update:modelValue', false)"/>
          </div>
        </template>

        <slot></slot>

        <template #footer>
          <slot name="actions">
            <div class="flex justify-end space-x-2">
              <UButton v-if="$props.variants === 'confirm'" @click="emit('update:modelValue', false)">Confirm</UButton>
              <UButton @click="emit('update:modelValue', false)">Cancel</UButton>
            </div>
            </slot>
        </template>
      </UCard>
    </UModal>
  </div>
</template>

