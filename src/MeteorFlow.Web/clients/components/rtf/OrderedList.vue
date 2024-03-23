<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleOrderedList = () => {
  props.editor?.chain().focus().toggleOrderedList().run();
};

</script>
<template>
  <UButton
    @click="toggleOrderedList"
    class="font-bold text-md"
    icon="i-fa6-solid-list-ol"
  />
</template>
