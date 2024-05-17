// https://nuxt.com/docs/api/configuration/nuxt-config
import fs from 'fs';
import * as defaults from "./clients/aspnetcore-nuxt";
export default defineNuxtConfig({
  srcDir: "clients/",
  devServer: {
    https: {
      cert: fs.readFileSync(defaults.certFilePath).toString(),
      key: fs.readFileSync(defaults.keyFilePath).toString()
    }
  },
  experimental: {
    renderJsonPayloads: false,
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
    "@nuxt/content",
    "nuxt-tiptap-editor",
    "~/modules/tiptap",
  ],
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
  colorMode: {
    preference: "light",
  },
});
