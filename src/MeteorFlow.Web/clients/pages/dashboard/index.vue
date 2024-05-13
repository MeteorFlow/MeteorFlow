<script setup lang="ts">

import type { TableColumn } from "~/models";

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
];

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
];

const headers = [
  {
    key: "title",
    label: "Title",
  },
  {
    key: "val",
    label: "Value",
    align: "right",
  },
] as TableColumn[];

const data = {
  labels: ["January", "February", "March", "April", "May", "June"],
  datasets: [
    {
      label: "Data",
      data: [65, 59, 80, 81, 56, 55],
      backgroundColor: "rgb(255, 99, 132)",
    }
  ]
}

useSeoMeta({
  title: 'Dashboard | MeteorFlow',
  ogTitle: 'Data Science with MeteorFlow',
  description: 'This is my amazing site, let me tell you all about it.',
  ogDescription: 'This is my amazing site, let me tell you all about it.',
})
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div class="grid grid-cols-2 gap-4">
        <CoreCard size="md" title="Infrastructure Settings" icon="i-fa6-solid-tag">
          <CoreTable :rows="InfraSettings" :columns="headers" hide-header />

          <template #footer>
            <div>
              Your password is saved in a secure storage vault. More about
              connecting from different languages, frameworks, and platforms.
            </div>
          </template>
        </CoreCard>

        <CoreCard size="md" title="Usage" icon="i-fa6-solid-tag">
          <CoreTable :rows="UsageSettings" :columns="headers" hide-header />
          <template #footer>
            <div>
              Metrics may be delayed by up to one hour. Read more about metrics.
            </div>
          </template>
        </CoreCard>

        <CoreCard size="md" title="Usage" icon="i-fa6-solid-tag">
          <CoreCharts variant="bar" :data="data" />
        </CoreCard>
      </div>
    </NuxtLayout>
  </div>
</template>
