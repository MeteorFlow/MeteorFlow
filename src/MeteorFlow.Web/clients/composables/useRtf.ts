import type { Editor, Extensions } from "@tiptap/vue-3";

export const useRtf = (extensions?: Extensions) => {
  const editor = useState("editor", () => {
    const editor = useEditor({
      content: "<p>I'm running Tiptap with Vue.js. 🎉</p>",
      extensions: [TiptapStarterKit],
    });

    return editor.value
  })

  const registerExtension = (extensions: Extensions) => {
    const baseOption = editor.value?.options;
    if (!baseOption) return
    editor?.value?.setOptions({
      ...baseOption,
      extensions: [...baseOption.extensions, ...extensions]
    })
  }

  if (extensions) {
    registerExtension(extensions)
  }

  return {
    editor: editor.value as Editor,
    registerExtension
  }
}