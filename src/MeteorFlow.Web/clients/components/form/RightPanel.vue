<script setup lang="ts">
import type { Definition } from '~/models/Definition';


defineProps<{
  definition?: Definition
}>();

const formName = ref("MyForm");
const liveValidation = ref("Default");
const size = ref("Default");
const columns = ref("Default");
const defaultColumnWidths = ref(true);
const forceLabels = ref("Default");
const floatPlaceholders = ref("Default");

const liveValidationOptions = ["Default", "On", "Off"];
const sizeOptions = ["Default", "sm", "md", "lg"];
const columnsOptions = ["Default", "Tablet", "Desktop"];
const forceLabelsOptions = ["Default", "On", "Off"];
const floatPlaceholdersOptions = ["Default", "On", "Off"];
</script>

<template>
  <div class="space-y-4 bg-gray-800 p-4 text-white">
    <!-- Properties Section -->
    <div>
      <h2 class="text-lg font-bold mb-2">Properties</h2>
      <CoreTextField
        title="Name"
        v-model="formName"
        placeholder="Enter form name"
      />


    </div>

    <!-- Validation Section -->
    <div>
      <h2 class="text-lg font-bold mb-2">Validation</h2>
      <CoreSelect
        title="Live validation"
        :items="liveValidationOptions"
        v-model="liveValidation"
      />
    </div>

    <!-- Additional Options -->
    <div>
      <h2 class="text-lg font-bold mb-2">Additional Options</h2>
      <CoreSelect
        title="Force labels"
        :items="forceLabelsOptions"
        v-model="forceLabels"
      />
      <CoreSelect
        title="Float placeholders"
        :items="floatPlaceholdersOptions"
        v-model="floatPlaceholders"
      />
    </div>
  </div>
</template>
