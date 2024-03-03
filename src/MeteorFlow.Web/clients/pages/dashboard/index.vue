<script setup lang="ts">
import Card from "../../components/Card.vue";
import { UTable } from "#components";

const InfraSettings = [
  {
    title: "Region",
    val: "Asia Pacific (Singapore)",
  },
  {
    title: "Default compute size",
    val: "0.25 CU",
  },
  {
    title: "History retention",
    val: "7 days",
  },
  {
    title: "Postgres version",
    val: "15",
  },
].map((el) => ({
  title: el.title,
  val: { value: el.val, class: "text-right" },
}));

const UsageSettings = [
  {
    title: "Storage",
    val: "31 MiB",
  },
  {
    title: "Data transfer",
    val: "0 KiB",
  },
  {
    title: "Written Data",
    val: "0 KiB",
  },
  {
    title: "Compute",
    val: "0 h",
  },
  {
    title: "Active computes",
    val: "0",
  },
  {
    title: "Branches",
    val: "1",
  },
].map((el) => ({
  title: el.title,
  val: { value: el.val, class: "text-right" },
}));
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div class="grid grid-cols-2 gap-4">
        <Card size="md" title="Infrastructure Settings" icon="i-fa6-solid-tag">
          <UTable :rows="InfraSettings" :ui="{ thead: 'collapse', divide: '' }">
            <template #val-data="{ row }">
              {{ row.val.value }}
            </template>
          </UTable>

          <template #footer>
            <div>
              Your password is saved in a secure storage vault. More about
              connecting from different languages, frameworks, and platforms.
            </div>
          </template>
        </Card>

        <Card size="md" title="Usage" icon="i-fa6-solid-tag">
          <UTable :rows="UsageSettings" :ui="{ thead: 'collapse', divide: '' }">
            <template #val-data="{ row }">
              {{ row.val.value }}
            </template>
          </UTable>
          <template #footer>
            <div>
              Metrics may be delayed by up to one hour. Read more about metrics.
            </div>
          </template>
        </Card>
      </div>
    </NuxtLayout>
  </div>
</template>
