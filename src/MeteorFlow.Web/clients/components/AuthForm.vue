<template>
  <div :class="formClass">
    <div :class="ui.base">
      <div v-if="icon" :class="icon" class="text-3xl"></div>
      <h2 class="text-xl font-semibold">{{ title }}</h2>

      <slot name="description"></slot>

      <div v-for="(field, index) in fields" :key="index" class="pt-4 w-full">
        <TextField
          v-model="formData[field.name]"
          :title="field.label"
          :description="field.description"
          :help="field.help"
          :required="field.required"
          :disabled="field.disabled"
          :rules="field.rules"
          :size="field.size"
          :filled="field.filled"
          :variant="field.variant"
          :icon="field.icon"
          :placeholder="field.placeholder"
          :options="field.options"
        />
      </div>

      <div v-if="$slots['password-hint']" class="block pt-4">
        <slot name="password-hint"></slot>
      </div>

      <UButton
        :type="submitButton.type"
        :class="submitButtonClass"
        :label="submitButtonText"
        :icon="submitButton.trailingIcon"
        trailing
        @click="handleSubmit"
      />

      <div v-if="providers && providers.length" class="w-full">
        <div class="relative flex py-4 items-center">
          <div class="flex-grow border-t border-gray-500"></div>
          <span class="flex-shrink mx-4 text-gray-500">or</span>
          <div class="flex-grow border-t border-gray-500"></div>
        </div>
        <div class="flex flex-col gap-2">
          <UButton
            v-for="(provider, index) in providers"
            :key="index"
            @click="provider.onClick"
            :loading="provider.loading"
            :class="providerButtonClass"
            :icon="provider.icon"
            :label="provider.label"
            :color="provider.color"
            trailing
          />
        </div>
      </div>

      <div v-if="$slots.footer" class="block pt-4">
        <slot name="footer"></slot>
      </div>
    </div>
  </div>
</template>

<script setup>
import TextField from "./core/TextField.vue";

const props = defineProps({
  fields: {
    type: Array,
    required: true,
  },
  validate: {
    type: Function,
    required: true,
  },
  providers: {
    type: Array,
    required: false,
    default: () => [],
  },
  title: {
    type: String,
    required: true,
  },
  align: {
    type: String,
    required: false,
    default: "top",
  },
  icon: {
    type: String,
    required: false,
  },
  ui: {
    type: Object,
    required: false,
    default: () => ({
      base: "",
      footer: "",
    }),
  },
  submitButton: {
    type: Object,
    required: false,
    default: () => ({
      type: "submit",
      class: "",
      trailingIcon: "",
    }),
  },
});

const emit = defineEmits(["submit"]);

const formData = reactive(
  props.fields.reduce((acc, field) => {
    acc[field.name] = field.value || "";
    return acc;
  }, {})
);

const submitButtonText = computed(() => props.submitButton.text || "Continue");

const submitButtonClass = computed(
  () =>
    props.submitButton.class ||
    "bg-primary text-white py-2 px-4 rounded flex items-center justify-center mt-4 w-full"
);

const handleSubmit = () => {
  if (props.validate(formData)) {
    emit("submit", formData);
  }
};

const formClass = computed(() => {
  switch (props.align) {
    case "top":
      return "flex flex-col items-center";
    case "center":
      return "flex flex-col items-center justify-center h-full";
    default:
      return "flex flex-col items-center";
  }
});

const providerButtonClass =
  "flex items-center justify-center bg-gray-100 text-black py-2 px-4 rounded w-full";
</script>

<style scoped>
/* Additional scoped styles if needed */
</style>
