<script setup lang="ts">

const formId = useRoute().params.id

</script>

<template>
  <div>
    <NuxtLayout name="default">
      <FormItem :id="(formId as string)"></FormItem>
    </NuxtLayout>
  </div>
</template>

<style>
.itemDragged {
  opacity: 0.3;
}

.droppableShow {
  display: block;
}

.dragOver {
  opacity: 1;
}
</style>
