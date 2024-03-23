<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleBold = () => {
  props.editor?.chain().focus().toggleBold().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().toggleBold().run()
);
</script>
<template>
  <UButton
    @click="toggleBold"
    class="font-bold text-md"
    :disabled="disabled"
    label="B"
  />
</template>
