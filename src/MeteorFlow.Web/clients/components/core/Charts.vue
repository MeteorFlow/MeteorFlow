<script setup lang="ts">
import { Chart } from "vue-chartjs";
import type { ChartVariants } from "~/models";
import type { ChartData, ChartOptions, Plugin, UpdateMode } from "chart.js";

const props = defineProps<{
  variant: ChartVariants;
  data: ChartData;
  tooltips?: string;
  options?: ChartOptions;
  updateMode?: UpdateMode;
  plugins?: Plugin[];
}>();
</script>

<template>
  <Chart
    :type="props.variant"
    :data="props.data"
    :options="props.options"
    :plugins="props.plugins"
    :update-mode="props.updateMode"
  />
</template>
