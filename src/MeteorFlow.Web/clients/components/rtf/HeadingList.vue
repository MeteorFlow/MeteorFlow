<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
import type { Level } from "@tiptap/extension-heading";
const items = ["Paragraph", 1, 2, 3, 4] as (Level | "Paragraph")[];

const props = defineProps<{
  editor: Editor | undefined;
  initial?: Level | "Paragraph";
}>();

const state = useState(() => props.initial ?? "Paragraph");

watch(state, () => {
  if (state.value === "Paragraph") {
    props.editor?.chain().focus().setParagraph().run();
  } else {
    props.editor?.chain().focus().setHeading({ level: state.value }).run();
  }
});


</script>
<template>
  <CoreSelect v-model="state" :items="(items as string[])" />
</template>
