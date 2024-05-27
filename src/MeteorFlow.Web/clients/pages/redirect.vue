<template>
  <div class="h-screen flex items-center justify-center">
    <div class="text-center">
      <h1>Logging in...</h1>
    </div>
  </div>
</template>

<script setup>
import { onMounted } from 'vue';
import { useRouter } from 'vue-router';
import { useFetch } from '@vueuse/core';

const router = useRouter();

onMounted(async () => {
  const { data, error } = await useFetch('https://api.meteorflow.com/signin-github', { credentials: 'include' }).get().json();

  if (error.value) {
    console.error('Error during login:', error.value);
    // Handle error, maybe redirect to an error page or show a message
  } else {
    console.log('Login response:', data.value);
    // Handle response and store tokens or user information as needed
    router.push('/');
  }
});
</script>

<style scoped>
/* Add your styles here */
</style>
