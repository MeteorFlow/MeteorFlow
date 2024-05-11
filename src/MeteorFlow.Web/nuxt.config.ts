// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  srcDir: "clients/",
  experimental: {
    renderJsonPayloads: false,
  },
  components: {
    global: true,
    dirs: ["~/components"],
  },
  image: {
    domains: [
      'https://images.unsplash.com',
      'https://source.unsplash.com',
    ],
  },
  modules: ["@nuxt/ui", [
    "@nuxtjs/i18n",
    {
      /* module options */
    },
  ], "@nuxt/content", "nuxt-tiptap-editor", "~/modules/tiptap", "@nuxt/image"],
  ui: {
    icons: ["heroicons", "fa", "fa6-solid"],
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
  tiptap: {
    lowlight: {
      theme: "github-dark",
    },
  },
  plugins: [
    { src: "~/plugins/chart.client.ts", mode: "client" },
    { src: "~/plugins/grid.client.ts", mode: "client" },
  ],

});