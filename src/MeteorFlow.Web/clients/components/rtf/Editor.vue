<script setup lang="ts">
const editor = useEditor({
  content: "<p>I'm running Tiptap with Vue.js. 🎉</p>",
  extensions: [TiptapStarterKit, TiptapUnderline],
});
</script>

<template>
  <div>
    <div v-if="editor" class="flex flex-row flex-wrap space-x-2">
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
    </div>
    <TiptapEditorContent :editor="editor" class="editor-content" />
  </div>
</template>

<style>
.editor-content ul {
  list-style: circle;
  padding-left: 2em;
}

.editor-content ol {
  list-style: auto;
  padding-left: 2em;
}

.editor-content h1 {
  font-size: 1.7em;
}

.editor-content h2 {
  font-size: 1.5em;
}

.editor-content h3 {
  font-size: 1.3em;
}

.editor-content h4 {
  font-size: 1.17em;
}
</style>
