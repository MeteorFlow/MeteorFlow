<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleCode = () => {
  props.editor?.chain().focus().toggleCode().run();
};

const disabled = computed(
  () => !props.editor?.can().chain().focus().toggleCode().run()
);
</script>
<template>
  <UButton
    @click="toggleCode"
    class="font-bold text-md"
    :disabled="disabled"
    icon="i-fa6-solid-code"
  />
</template>
