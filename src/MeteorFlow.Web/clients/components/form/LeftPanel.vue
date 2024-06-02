<script setup lang="ts">
import { ref } from "vue";
import type { FormElement } from "~/models/Forms";

const emits = defineEmits<{
  (e: "click:add", value: FormElement): void;
}>();

const { data: formElements, error } = useHttps<FormElement[]>("/form/element", {
  method: "GET",
  default: () => [],
});

if (error.value) {
  console.error(error.value);
}

const els: FormElement[] = [
  {
    renderer: "text",
    name: "Text input",
    description: "Single line text input",
  },
  {
    renderer: "location",
    name: "Location",
    description: "Google places location input",
  },
  {
    renderer: "textarea",
    name: "Textarea",
    description: "Single line or multiline text area",
  },
  {
    renderer: "wysiwyg",
    name: "WYSIWYG editor",
    description: "Rich text editor",
  },
  {
    renderer: "checkbox",
    name: "Checkbox",
    description: "Plain checkbox input",
  },
  { renderer: "radio", name: "Radio", description: "Plain radio input" },
  { renderer: "toggle", name: "Toggle", description: "Toggle / switch button" },
  { renderer: "select", name: "Select", description: "Select input" },
  {
    renderer: "multiselect",
    name: "Multiselect",
    description: "Multiselect input",
  },
  { renderer: "tags", name: "Tags", description: "Tags input" },
  { renderer: "date", name: "Date", description: "Datepicker input" },
  {
    renderer: "datetime",
    name: "Datetime",
    description: "Date & time picker input",
  },
  { renderer: "time", name: "Time", description: "Time picker input" },
  {
    renderer: "date-range",
    name: "Date range",
    description: "Date picker that allows date range",
  },
];

// const formElements = ref(els);
</script>

<template>
  <div class="flex flex-col max-h-full">
    <div class="overflow-y-auto pb-2">
      <div class="flex flex-col gap-4">
        <CoreDragItem
          v-for="element in formElements"
          :key="element.renderer"
          :transferData="-1"
          class="border-2 border-transparent p-1 hover:border-2 hover:border-primary"
          @click="() => emits('click:add', element)"
        >
          <div
            class="flex items-start p-2 border border-gray-300 rounded-lg shadow-sm"
          >
            <div class="mr-4">
              <!-- Placeholder for the element icon -->
              <svg
                class="w-6 h-6 text-gray-500"
                fill="currentColor"
                viewBox="0 0 20 20"
                xmlns="http://www.w3.org/2000/svg"
              >
                <path
                  fill-rule="evenodd"
                  d="M10 18a8 8 0 100-16 8 8 0 000 16zm1-7V9a1 1 0 10-2 0v2a1 1 0 00.293.707l1 1A1 1 0 0012 13h-2a1 1 0 100 2h2a1 1 0 100-2h-1z"
                  clip-rule="evenodd"
                ></path>
              </svg>
            </div>
            <div>
              <div class="text-lg font-medium">{{ element.name }}</div>
              <div class="text-sm text-gray-600">{{ element.description }}</div>
            </div>
          </div>
        </CoreDragItem>
      </div>
    </div>
  </div>
</template>
