<script setup lang="ts">
const columns = [
  {
    key: "id",
    label: "#",
  },
  {
    key: "quantity",
    label: "Quantity",
  },
];

const items = [
  {
    id: 1,
    quantity: { value: 100, class: "text-right" },
  },
  {
    id: 2,
    quantity: { value: 30, class: "text-right" },
  },
  {
    id: 3,
    quantity: { value: 30, class: "text-right" },
  },
  {
    id: 4,
    quantity: { value: 5, class: "text-right" },
  },
];
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <UTable :rows="items" :columns="columns">
        <template #quantity-data="{ row }">
          {{ row.quantity.value }}
        </template>
      </UTable>
    </NuxtLayout>
  </div>
</template>
