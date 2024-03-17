import { UInput } from "#components";
import { Teleport } from "vue";

const APISearch = defineComponent({
  props: {
    topic: {
      type: String,
    }
  },
  setup(props, ctx) {
    return () => (
      <div>
        <UInput color="primary" variant="outline" placeholder="Search..." />
      </div>
    );
  },
});

export default APISearch;
