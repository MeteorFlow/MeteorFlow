<script setup lang="ts">
const route = useRoute();
useSeoMeta({
  ogImage: "/headline.jpeg",
});

const landingPath = "/";

const links = [
  [
    {
      to: landingPath,
    },
  ],
  [
    {
      label: "Dashboard",
      to: "/dashboard",
    },
    {
      label: "Forms",
      to: "/forms",
    },
    {
      label: "Source",
      to: "/source",
    },
  ],
  [
    {
      label: "Login",
      icon: "i-fa6-solid-user",
      to: "/login",
    },
    {
      label: "Signup",
      icon: "i-fa6-solid-user-plus",
      to: "/signup",
    }
  ],
];

const footerLinks = [
  {
    label: "Community",
    children: [
      {
        label: "Nuxters",
        to: "https://nuxters.nuxt.com",
        target: "_blank",
      },
      {
        label: "Video Courses",
        to: "https://masteringnuxt.com/nuxt3?ref=nuxt",
        target: "_blank",
      },
      {
        label: "Nuxt on GitHub",
        to: "https://github.com/nuxt",
        target: "_blank",
      },
    ],
  },
  {
    label: "Solutions",
    children: [
      {
        label: "Nuxt Content",
        to: "https://content.nuxt.com/",
        target: "_blank",
      },
      {
        label: "Nuxt DevTools",
        to: "https://devtools.nuxt.com/",
        target: "_blank",
      },
      {
        label: "Nuxt Image",
        to: "https://image.nuxt.com/",
        target: "_blank",
      },
      {
        label: "Nuxt UI",
        to: "https://ui.nuxt.com/",
        target: "_blank",
      },
    ],
  },
];

const ui = {
  base: "group relative w-full flex items-center gap-1.5 py-3.5",
  before: "",
  after: "",
};
</script>

<template>
  <div>
    <div class="container mx-auto">
      <UHorizontalNavigation :links="links" :ui="ui">
      <template #default="{ link }">
        <div v-if="link.to === landingPath">
          <LandingLogo />
        </div>
        <span v-else class="group-hover:text-primary relative">{{
          link.label
        }}</span>
      </template>
    </UHorizontalNavigation>
    </div>

    <div class="w-full flex flex-col">
      <slot></slot>
    </div>
    <LandingFooter :links="footerLinks">
      <template #right>
        <UFormGroup name="email" label="Subscribe to our newsletter" size="xl">
          <UInput type="email" :ui="{ icon: { trailing: { pointer: '' } } }">
            <template #trailing>
              <UButton
                type="submit"
                size="2xs"
                color="black"
                label="Subscribe"
              />
            </template>
          </UInput>
        </UFormGroup>
      </template>
      <template #footer-left>
        Copyright © {{ new Date().getFullYear() }}
      </template>

      <template #footer-right>
        <UButton
          icon="i-simple-icons-x"
          color="gray"
          variant="ghost"
          to="https://x.com/nuxt_js"
          target="_blank"
        />
        <UButton
          icon="i-simple-icons-discord"
          color="gray"
          variant="ghost"
          to="https://discord.com/invite/ps2h6QT"
          target="_blank"
        />
        <UButton
          icon="i-simple-icons-github"
          color="gray"
          variant="ghost"
          to="https://github.com/nuxt/nuxt"
          target="_blank"
        />
      </template>
    </LandingFooter>
  </div>
</template>
