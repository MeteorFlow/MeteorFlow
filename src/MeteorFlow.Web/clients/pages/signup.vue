<script setup lang="ts">
useSeoMeta({
  title: "Sign up",
});

const fields = [
  {
    name: "userName",
    type: "text",
    label: "Name",
    placeholder: "Enter your name",
  },
  {
    name: "email",
    type: "text",
    label: "Email",
    placeholder: "Enter your email",
  },
  {
    name: "phoneNumber",
    type: "text",
    label: "Phone Number",
    placeholder: "Enter your phone number",
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
    color: "gray" as const,
    click: () => {
      console.log("Redirect to GitHub");
    },
  },
];

async function onSubmit(data: any) {
  const { data: response, error } = await useHttps<string>('/auth/register', {
    method: 'POST',
    body: data,
    default: () => "",
  });

  if (!error.value) {
    // Handle successful login
    console.log('successful');
    navigateTo('/dashboard');
  } else {
    // Handle login error
    console.error('failed');
  }
}
</script>

<template>
  <NuxtLayout name="auth">
    <UCard class="max-w-sm w-full bg-white/75 dark:bg-white/5 backdrop-blur">
      <AuthForm
        :fields="fields"
        :validate="validate"
        :providers="providers"
        title="Create an account"
        :ui="{ base: 'text-center', footer: 'text-center' }"
        :submit-button="{ label: 'Create account' }"
        @submit="onSubmit"
      >
        <template #description>
          Already have an account?
          <NuxtLink to="/login" class="text-primary font-medium">Login</NuxtLink
          >.
        </template>

        <template #footer>
          By signing up, you agree to our
          <NuxtLink to="/" class="text-primary font-medium"
            >Terms of Service</NuxtLink
          >.
        </template>
      </AuthForm>
    </UCard>
  </NuxtLayout>
</template>
