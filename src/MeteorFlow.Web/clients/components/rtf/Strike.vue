<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleStrike = () => {
  props.editor?.chain().focus().toggleStrike().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().toggleStrike().run()
);
</script>
<template>
    <UButton
      @click="toggleStrike"
      class="line-through text-md"
      :disabled="disabled"
      label="S"
    />
</template>
