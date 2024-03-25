<script setup lang="ts">
const model = defineModel<string>("", { default: "" });
const emits = defineEmits<{
  // <eventName>: <expected arguments>
  "update:modelValue": [value: string]; // named tuple syntax
}>();

const editor = useEditor({
  content: model,
  extensions: [TiptapStarterKit, TiptapUnderline],
  onUpdate({ editor }) {
    if (editor.getHTML() == "<p></p>") {
      emits("update:modelValue", "");
    } else {
      emits("update:modelValue", editor.getHTML());
    }
  },
});

const ui = {
  wrapper:
    "form-textarea relative block w-full dark:bg-gray-800 disabled:cursor-not-allowed disabled:opacity-75 focus:outline-none border-0",
  rounded: "rounded-md",
};
</script>

<template>
  <div>
    <div v-if="editor" class="flex flex-row flex-wrap space-x-2 pb-2">
      <RtfBold :editor="editor" />
      <RtfItalic :editor="editor" />
      <RtfStrike :editor="editor" />
      <RtfUnderline :editor="editor" />
      <RtfClearFormat :editor="editor" />
      <RtfHeadingList :editor="editor" />
      <RtfBulletList :editor="editor" />
      <RtfOrderedList :editor="editor" />
      <RtfUndo :editor="editor" />
      <RtfRedo :editor="editor" />
      <RtfBreak :editor="editor" />
    </div>
    <TiptapEditorContent
      :editor="editor"
      :class="['editor-content', ui.wrapper, ui.rounded]"
    />
  </div>
</template>

<style>
.ProseMirror {
  min-height: 100px;
  max-height: 100px;
  overflow: scroll;
}
.ProseMirror:focus {
  outline: none;
}

.editor-content ul {
  @apply list-disc pl-4;
}

.editor-content ol {
  @apply list-decimal pl-4;
}

.editor-content h1 {
  @apply text-2xl font-bold;
}

.editor-content h2 {
  @apply text-xl font-bold;
}

.editor-content h3 {
  @apply text-lg font-bold;
}

.editor-content h4 {
  @apply text-base font-bold;
}
</style>
