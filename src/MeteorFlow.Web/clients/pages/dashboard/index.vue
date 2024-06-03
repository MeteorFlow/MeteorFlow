<script setup lang="ts">
definePageMeta({
  middleware: process.client ? 'auth' : undefined
  // or middleware: 'auth'
})

import type { TableColumn } from "~/models";
import type { DAG, DAGRun, Metrics } from '~/models/airflow';


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

// Fetch DAGs
const { data: dags } = await useFetch<DAG[]>('/api/airflow', {
  params: { endpoint: 'getDAGs' }
});

// Fetch DAG Runs
const dagId = dags.value?.[0]?.dag_id;
const { data: dagRuns } = await useFetch<DAGRun[]>('/api/airflow', {
  params: { endpoint: 'getDAGRuns', dagId }
});

// Fetch Metrics
const { data: metrics } = await useFetch<Metrics>('/api/airflow', {
  params: { endpoint: 'getMetrics' }
});

const UsageSettings = ref([
  {
    title: "Storage",
    val: metrics.value?.storage || "0 MiB",
  },
  {
    title: "Data transfer",
    val: metrics.value?.dataTransfer || "0 KiB",
  },
  {
    title: "Written Data",
    val: metrics.value?.writtenData || "0 KiB",
  },
  {
    title: "Compute",
    val: metrics.value?.compute || "0 h",
  },
  {
    title: "Postgres version",
    val: "15",
  },
]);

useSeoMeta({
  title: 'Dashboard | MeteorFlow',
  ogTitle: 'Data Science with MeteorFlow',
  description: 'This is my amazing site, let me tell you all about it.',
  ogDescription: 'This is my amazing site, let me tell you all about it.',
});
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <div class="grid grid-cols-2 gap-4">
        <!-- <CoreCard
          size="md"
          title="Infrastructure Settings"
          icon="i-fa6-solid-tag"
        >
          <CoreTable :rows="InfraSettings" :columns="headers" hide-header />

          <template #footer>
            <div>
              Your password is saved in a secure storage vault. More about
              connecting from different languages, frameworks, and platforms.
            </div>
          </template>
        </CoreCard> -->
        <CoreCard size="md" title="Usage" icon="i-fa6-solid-tag">
          <CoreCharts variant="bar" :data="data" />
        </CoreCard>

        <CoreCard size="md" title="Usage" icon="i-fa6-solid-tag">
          <CoreTable :rows="UsageSettings" :columns="headers" hide-header />
          <template #footer>
            <div>
              Metrics may be delayed by up to one hour. Read more about metrics.
            </div>
          </template>
        </CoreCard>

        <CoreCard size="md" title="Airflow DAGs" icon="i-fa6-solid-tag">
          <ul>
            <li v-for="dag in dags" :key="dag.dag_id">{{ dag.dag_id }}</li>
          </ul>
        </CoreCard>

        <CoreCard size="md" title="Airflow DAG Runs" icon="i-fa6-solid-tag">
          <ul>
            <li v-for="run in dagRuns" :key="run.run_id">{{ run.run_id }}</li>
          </ul>
        </CoreCard>


      </div>
    </NuxtLayout>
  </div>
</template>
