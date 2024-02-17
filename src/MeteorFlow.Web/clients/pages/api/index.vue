<template>
  <NuxtLayout name="default">
      <h2>Weather data for any location</h2>
      <BadgeRecommendation />
      <APISearch />
  </NuxtLayout>
</template>

<script setup lang="ts">
import APISearch from "../../components/APISearch"
</script>