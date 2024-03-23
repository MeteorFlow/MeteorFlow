<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleParagraph = () => {
  props.editor?.chain().focus().toggleBold().run();
};

</script>

<template>
  <UButton
    @click="toggleParagraph"
    class="text-md"
    icon="i-fa6-solid-paragraph"
  />
</template>
