<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleClearFormat = () => {
  props.editor?.chain().focus().unsetAllMarks().run();
};
</script>
<template>
  <UButton
    @click="toggleClearFormat"
    class="font-bold text-md"
    icon="i-fa6-solid-eraser"
  />
</template>
