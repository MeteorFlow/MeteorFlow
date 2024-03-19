<script setup lang="ts">
import { UTabs } from "#components";
import type { TabItem, TabOrientation } from "~/models";

const props = defineProps<{
  items: TabItem[];
  orientation?: TabOrientation;
  defaultIndex?: number;
}>();
</script>

<template>
  <UTabs :items="props.items" :orientation="props.orientation" :defaultIndex="props.defaultIndex">
    <!-- Adding icon to tab items-->
    <template #default="{ item, index, selected }">
      <slot :item="item" :index="index" :selected="selected">
        <div class="flex items-center gap-2 relative truncate">
          <UIcon :name="item.icon" class="w-4 h-4 flex-shrink-0" />

          <span class="truncate">{{ item.label }}</span>

          <span v-if="selected" class="absolute -right-4 w-2 h-2 rounded-full bg-primary-500 dark:bg-primary-400"></span>
        </div>
      </slot>
    </template>

    <template v-for="{ slot } in props.items" :key="slot" #[slot]>
      <slot :name="slot"></slot>
    </template>
  </UTabs>
</template>
