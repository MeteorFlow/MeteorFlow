<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleItalic = () => {
  props.editor?.chain().focus().toggleItalic().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().toggleItalic().run()
);
</script>
<template>
  <UButton
    @click="toggleItalic"
    class="italic text-md"
    :disabled="disabled"
    label="I"
  />
</template>
