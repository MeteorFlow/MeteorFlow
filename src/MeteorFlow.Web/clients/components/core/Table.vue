<script setup lang="tsx" generic="T extends Record<string, any>">
import { UTable } from "#components";
import type { TableColumn } from "~/models";

const props = defineProps<{
  rows: T[];
  columns: TableColumn[];
  hideHeader?: boolean;
}>();

const dirCols = props.columns.filter((col) => col.align || col.class);

const spreadColumn = (row: T) => {
  return {
    ...row,
    ...Object.fromEntries(
      dirCols.map((col) => [
        col.key,
        {
          value: row[col.key],
          class: `${col.class} ${col.align ? `text-${col.align}` : ""}`,
        },
      ])
    ),
  };
};

const rows = computed(() => props.rows.map(spreadColumn));
const columns = computed(() =>
  props.columns.map((col) => ({
    ...col,
    class: `${col.class} ${col.align ? `text-${col.align}` : ""}`,
  }))
);

const ui = props.hideHeader ? { thead: "collapse", divide: "" } : undefined;
</script>

<template>
  <UTable :rows="rows" :ui="ui" :columns="columns">
    <template v-for="col in props.columns" #[`${col.key}-data`]="{ row }">
      {{ typeof row[col.key] === "object" ? row[col.key].value : row[col.key] }}
    </template>
  </UTable>
</template>
