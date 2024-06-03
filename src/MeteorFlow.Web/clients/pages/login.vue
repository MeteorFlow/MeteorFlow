<script setup lang="ts">
import { useHttps } from '~/composables/useHttps';

const session = useUserSession();

useSeoMeta({
  title: "Login",
});



const fields = [
  {
    name: "name",
    type: "text",
    label: "User Name",
    placeholder: "Enter your user name",
  },
  {
    name: "password",
    label: "Password",
    type: "password",
    placeholder: "Enter your password",
  },
];

const validate = (state: any) => {
  const errors = [];
  if (!state.email)
    errors.push({ path: "email", message: "Email is required" });
  if (!state.password)
    errors.push({ path: "password", message: "Password is required" });
  return errors;
};

const providers = [
  {
    label: "Continue with GitHub",
    icon: "i-simple-icons-github",
    color: "white" as const,
    click: handleGitHubAuth,
  },
];

async function onSubmit(data: any) {
  const { data: response, error } = await useHttps<string>('/auth/login', {
    method: 'POST',
    body: data,
    default: () => "",
  });

  if (!error.value) {
    // Handle successful login
    session.setSession(response.value, { userName: data.name });
    console.log('Login successful');
    navigateTo('/dashboard');
  } else {
    // Handle login error
    console.error('Login failed');
  }
}

async function handleGitHubAuth() {
  const { data: response, error } = useHttps('/auth/github-callback', {
    method: 'GET',
    default: () => null,
  });

  if (!error.value) {
    // Handle GitHub auth success
    console.log('GitHub auth successful');
  } else {
    // Handle GitHub auth error
    console.error('GitHub auth failed');
  }
}

</script>

<!-- eslint-disable vue/multiline-html-element-content-newline -->
<!-- eslint-disable vue/singleline-html-element-content-newline -->
<template>
  <NuxtLayout name="auth">
    <UCard class="max-w-sm w-full bg-white/75 dark:bg-white/5 backdrop-blur">
      <AuthForm
        :fields="fields"
        :validate="validate"
        :providers="providers"
        title="Welcome back"
        icon="i-heroicons-lock-closed"
      
        :ui="{ base: 'text-center', footer: 'text-center' }"
        :submit-button="{ trailingIcon: 'i-heroicons-arrow-right-20-solid' }"
        @submit="onSubmit"
      >
        <template #description>
          Don't have an account?
          <NuxtLink to="/signup" class="text-primary font-medium"
            >Sign up</NuxtLink
          >.
        </template>

        <template #password-hint>
          <NuxtLink to="/" class="text-primary font-medium"
            >Forgot password?</NuxtLink
          >
        </template>

        <template #footer>
          By signing in, you agree to our
          <NuxtLink to="/" class="text-primary font-medium"
            >Terms of Service</NuxtLink
          >.
        </template>
      </AuthForm>
    </UCard>
  </NuxtLayout>
</template>
