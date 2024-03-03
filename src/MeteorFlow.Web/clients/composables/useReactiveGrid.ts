import type { Layout } from "~/models/Layout";

export const useReactiveGrid = () => {
  const { state: localStorageState, removeFromStorage } = useLocalStorage<
    Layout[]
  >("layout", []);

  const state = useState("state", () => ({
    layout: localStorageState.value,
  }));

  watch(state.value, (newValue) => {
    // You can perform any necessary actions here when layout changes
  });

  const actions = {
    setLayout(layout: Layout[]) {
      state.value.layout = layout;
    },
    addLayout(layout: Layout) {
      state.value.layout.push(layout);
    },
    removeLayout(layout: Layout) {
      const index = state.value.layout.indexOf(layout);
      if (index !== -1) {
        state.value.layout.splice(index, 1);
      }
    },
    clearLocalStorage: removeFromStorage,
  };

  return {
    state: state.value,
    actions,
  };
};
