/*
* Tiptap Custom Extension - global import
* @author: TuanKietTran
* Inspired by https://github.com/modbender/nuxt-tiptap-editor
*/

import { addImports, defineNuxtModule } from "nuxt/kit";

const extendedMarks = [
  { name: "Underline", path: "@tiptap/extension-underline" },
];

export default defineNuxtModule({
  meta: {
    name: "tiptap-custom-extension",
    version: "0.0.1",
    configKey: "tiptap-custom",
    compatibility: {
      nuxt: "^3.0.0",
    },
  },
  // Default configuration options of the Nuxt module
  defaults: {
    prefix: "Tiptap",
    lowlight: false,
  },
  async setup(options, nuxt) {
    const transpileModules = new Set<string>([]);
    extendedMarks.forEach((obj) => {
      addImports({
        as: `${options.prefix}${obj.name}`,
        name: obj.name,
        from: obj.path,
        // _internal_install: obj.path,
      });
      transpileModules.add(obj.path);
    });
    nuxt.options.build.transpile = [
      ...nuxt.options.build.transpile,
      ...transpileModules,
    ];

    console.info("Tiptap Extension initialized! Registered: ", extendedMarks.map(x => x.name));
  },
});
