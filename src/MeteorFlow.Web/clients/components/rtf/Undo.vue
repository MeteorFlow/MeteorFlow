<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleUndo = () => {
  props.editor?.chain().focus().undo().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().undo().run()
);
</script>
<template>
  <UButton
    @click="toggleUndo"
    class="underline text-md"
    :disabled="disabled"
    icon="i-fa6-solid-rotate-left"
  />
</template>
