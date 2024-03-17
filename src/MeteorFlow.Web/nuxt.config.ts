// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  srcDir: "clients/",
  typescript: {
    typeCheck: true
  },
  components: {
    global: true,
    dirs: ["~/components"],
  },
  modules: [
    "@nuxt/ui",
    [
      "@nuxtjs/i18n",
      {
        /* module options */
      },
    ],
    "nuxt-icon",
    "@nuxt/content",
  ],
  ui: {
    icons: ["heroicons", "fa", "fa6-solid"],
  },
  content: {
    experimental: {
      search: true,
    },
  },
  devtools: {
    // Enable devtools (default: true)
    enabled: true,
    // VS Code Server options
    vscode: {
      reuseExistingServer: true,
    },
    // ...other options
  },
  plugins: [{ src: "~/plugins/chart.client.ts", mode: "client" }],
});
