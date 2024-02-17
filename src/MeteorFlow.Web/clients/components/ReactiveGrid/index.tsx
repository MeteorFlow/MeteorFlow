import type { Layout } from "~/models/Layout";
import GridItem from "./GridItem.vue";

const ReactiveGrid = defineComponent({
  props: {
    rowHeight: {
      type: Number,
      default: 30
    },
    draggable: {
      type: Boolean,
      default: false
    },
    resizable: {
      type: Boolean,
      default: false
    },
    layout: {
      type: Array as PropType<Layout[]>,
      default: [] as Layout[]
    }
  },
  setup(props, ctx) {
    return () => (
      <client-only>
        <grid-layout>
          <GridItem></GridItem>
        </grid-layout>
      </client-only>
    );
  }
})