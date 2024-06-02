<script setup lang="ts">
useSeoMeta({
  title: "MeteorFlow",
  ogTitle: "Data Science with MeteorFlow",
  description: "This is my amazing site, let me tell you all about it.",
  ogDescription: "This is my amazing site, let me tell you all about it.",
});

const img = useImage();
const heroBackground = img("/particles.png");
</script>

<template>
  <div>
    <NuxtLayout name="landing">
      <!-- Hero Section -->
      <div
        class="py-24 sm:py-32 md:py-40 relative dark:bg-gradient-to-b from-gray-950 to-gray-900 object-contain bg-blend-darken"
      >
        <LandingAnimate />
        <div
          class="mx-auto px-4 sm:px-6 lg:px-8 max-w-7xl flex flex-col gap-16 sm:gap-y-24 py-20"
        >
          <div class="text-center relative z-[1]">

            <h1
              class="text-5xl font-bold tracking-tight text-gray-900 dark:text-white sm:text-7xl"
            >
              Streamline Your Meteorological Workflows
            </h1>
            <p
              class="mt-6 text-lg tracking-tight text-gray-600 dark:text-gray-300"
            >
              MeteorFlow is a cloud-based platform designed to streamline your
              work with weather data. <br />
              Easily access, manage, analyze, and automate meteorological
              workflows, empowering you to gain deeper insights and make
              data-driven decisions faster.
            </p>
          </div>
        </div>
      </div>

      <!-- Feature Callouts Section -->
      <div class="py-24 sm:py-32 md:py-40 dark:bg-gray-900">
        <div class="container mx-auto px-4 sm:px-6 lg:px-8">
          <h2
            class="text-center text-3xl font-bold text-white sm:text-4xl mb-10"
          >
            Powerful Features
          </h2>
          <div class="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
            <LandingCard
              title="Real-time Data"
              description="Access up-to-the-minute weather data from a global network."
              icon="i-fa6-solid-satellite-dish"
            />
            <LandingCard
              title="Advanced Analytics"
              description="Utilize powerful tools to analyze and predict weather patterns."
              icon="i-fa6-solid-chart-line"
            />
            <LandingCard
              title="Automation Tools"
              description="Automate data collection and processing with our robust tools."
              icon="i-fa6-solid-robot"
            />
            <LandingCard
              title="Scalable Infrastructure"
              description="Easily scale your operations to handle increasing data volumes."
              icon="i-fa6-solid-cloud-arrow-up"
            />
            <LandingCard
              title="Secure Storage"
              description="Your data is protected with top-tier security measures."
              icon="i-fa6-solid-lock"
            />
            <LandingCard
              title="Community Support"
              description="Join a growing community of meteorological experts and enthusiasts."
              icon="i-fa6-solid-users"
            />
          </div>
        </div>
      </div>

      <!-- Testimonials Section -->
      <div class="py-24 sm:py-32 dark:bg-gray-900">
        <div class="container mx-auto text-center px-6">
          <h2 class="text-3xl font-bold text-white">What Our Users Say</h2>
          <div class="flex flex-wrap justify-center gap-8 mt-8">
            <LandingCard
              title="Jane Doe"
              description="MeteorFlow revolutionized how we interact with climate data."
              icon="/images/jane_doe.png"
            />
            <LandingCard
              title="John Smith"
              description="The analytics tools are incredibly powerful and easy to use."
              icon="/images/john_smith.jpg"
            />
          </div>
        </div>
      </div>

      <!-- Call to Action Section -->
      <div class="py-24 sm:py-32 dark:bg-gray-900">
        <div class="container mx-auto text-center px-6">
          <h2 class="text-3xl font-bold text-white sm:text-4xl">
            Ready to Transform Your Meteorological Practice?
          </h2>
          <p class="mt-4 text-gray-400">
            Join the MeteorFlow community and start your journey today.
          </p>
          <UButton
            class="mt-8 px-8 py-3 bg-primary dark:text-white rounded-lg shadow hover:bg-transparent"
            @click="() => navigateTo('/signup')"
          >
            Get Started
          </UButton>
        </div>
      </div>
    </NuxtLayout>
  </div>
</template>
