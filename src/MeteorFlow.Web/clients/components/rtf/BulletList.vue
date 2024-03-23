<script setup lang="ts">
import type { Editor } from "@tiptap/vue-3";
const props = defineProps<{
  editor: Editor | undefined;
}>();

const toggleBulletList = () => {
  props.editor?.chain().focus().toggleBulletList().run();
};

</script>
<template>
  <UButton
    @click="toggleBulletList"
    class="font-bold text-md"
    icon="i-fa6-solid-list-ul"
  />
</template>
