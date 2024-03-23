<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleUnderline = () => {
  props.editor?.chain().focus().toggleUnderline().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().toggleUnderline().run()
);
</script>
<template>
  <UButton
    @click="toggleUnderline"
    class="underline text-md"
    :disabled="disabled"
    label="U"
  />
</template>
