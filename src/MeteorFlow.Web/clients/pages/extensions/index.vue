<script setup lang="ts">
import type { ValidateFunction, Validation } from '~/models';

const people = [
  "Wade Cooper",
  "Arlene Mccoy",
  "Devon Webb",
  "Tom Cook",
  "Tanya Fox",
  "Hellen Schmidt",
  "Caroline Schultz",
  "Mason Heaney",
  "Claudie Smitham",
  "Emil Schaefer",
];

const validator = useValidation();

const ruleMin8 = async (value?: string): Promise<Validation> => value && value.length >= 8 ? true : "Minimum 8 characters"; 

const selected = ref("");
const text = ref("");
const password = ref("");
</script>

<template>
  <div>
    <NuxtLayout name="default">
      <CoreSelect
        size="md"
        searchable
        v-model="selected"
        :items="people"
        placeholder="Select people"
      />
      <CoreTextField
        title="Title"
        size="md"
        icon="i-heroicons-bell-20-solid"
        :rules="[validator.createRules().required(), ruleMin8]"
      />
      <CoreTextField
        title="Title"
        size="md"
        variant="search"
      />
      <CoreTextField
        title="Email"
        size="md"
        variant="email"
        v-model="text"
        required
      />
      <CoreTextField
        title="Password"
        size="md"
        variant="password"
        v-model="password"
        required
      />
    </NuxtLayout>
  </div>
</template>
