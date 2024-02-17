<template>
  <div class="flex flex-wrap gap-2">
    <UBadge class="cursor-pointer" v-for="item in items" :key="item.id" color="primary" variant="soft" @click="handleClick(item)">
      {{ item.name }}
    </UBadge>
  </div>
</template>

<script lang="ts">
import { UBadge } from '#components';
import { type Recommendation } from '~/models/Recommendation';

export default defineComponent({
  components: {
    UBadge,
  },
  props: {
    length: {
      type: Number,
      default: 10,
    },
    topic: {
      type: String,
    },
    icon: {
      type: String,
      default: 'i-fa6-solid-tag',
    },
  },
  emits: {
    click: (item: Recommendation) => true,
  },
  setup(props, {emit}) {
    const items = useState("items", () => [] as Recommendation[]);

    onBeforeMount(() => {
      items.value = Array.from({ length: props.length }).map((_, i) => ({
        id: i,
        name: `Item ${i}`,
        description: `This is item ${i}`,
        topic: props.topic,
      } as Recommendation));
    });

    const handleClick = (item: Recommendation) => {
      // Handle click logic here
      emit("click", item);
    };

    return {
      items,
      handleClick,
    };
  },
});
</script>
