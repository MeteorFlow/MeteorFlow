import { UInput } from "#components";

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
