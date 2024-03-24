<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const setHardbreak = () => {
  props.editor?.chain().focus().setHardBreak().run();
};
</script>
<template>
  <UButton
    @click="setHardbreak"
    class="font-bold text-md"
    icon="i-fa6-solid-bridge-circle-xmark"
  />
</template>
