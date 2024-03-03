<template>
  <div>
    <NuxtLayout name="default">
        <h2>Weather data for any location</h2>
        <BadgeRecommendation />
        <APISearch />
    </NuxtLayout>
  </div>
</template>

<script setup lang="ts">
import APISearch from "../../components/APISearch"
</script>