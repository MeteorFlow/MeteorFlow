// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  srcDir: "clients/",
  modules: [
    "@nuxt/ui",
    [
      "@nuxtjs/i18n",
      {
        /* module options */
      },
    ],
    "nuxt-icon",
  ],
  ui: {
    icons: ["heroicons", "fa", "fa6-solid"],
  },
  devtools: {
    // Enable devtools (default: true)
    enabled: true,
    // VS Code Server options
    vscode: {},
    // ...other options
  },
  plugins: [{ src: "~/plugins/chart.client.ts", mode: "client" }],
});
