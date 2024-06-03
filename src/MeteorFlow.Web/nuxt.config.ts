// https://nuxt.com/docs/api/configuration/nuxt-config
import fs from 'fs';
import * as defaults from "./clients/aspnetcore-nuxt";
export default defineNuxtConfig({
  srcDir: "clients/",
  devServer: process.env.NODE_ENV === 'production' ? {} : {
    https: {
      cert: fs.readFileSync(defaults.certFilePath).toString(),
      key: fs.readFileSync(defaults.keyFilePath).toString()
    }
  },
  runtimeConfig: {
    // Public keys that are exposed to the client
    public: {
      apiUrl: process.env.NODE_ENV === 'production' 
        ? 'https://api.meteor-flow.com' // Your .NET Core API base URL
        : 'https://localhost:7044',
      airflow: 'http://your-airflow-url/api/v1',
    }
  },
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
  ], "@nuxt/content", "nuxt-tiptap-editor", "~/modules/tiptap", "@nuxt/image", "@pinia/nuxt"],
  ui: {
    icons: ["heroicons", "fa", "fa6-solid", "mdi", "simple-icons"],
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
  pinia: {
    storesDirs: ['./stores/**'],
  },
  plugins: [
    { src: "~/plugins/chart.client.ts", mode: "client" },
    { src: "~/plugins/grid.client.ts", mode: "client" },
  ],
});