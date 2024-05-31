import type { Definition } from "~/models/Definition";
import type { FormBlock } from "~/models/Forms";

export const useFormStore = defineStore("form", () => {
  const selectedVersionId = ref<string | null>(null);
  const errorMsg = ref<string | null>(null);
  const selectedFormBlocks = ref<FormBlock[]>([]);
  const formsBlocks = {} as Record<string, FormBlock[]>;
  const formDefinitions = ref<Definition[]>([]);

  const actions = {
    setSelectedVersionId: (id: string) => {
      selectedVersionId.value = id;
    },
    loadForms: async () => {
      if (formDefinitions.value?.length > 0) {
        return formDefinitions.value;
      }
      const { data, error } = await useAsyncData(
        "form",
        () => useNuxtApp().$https<Definition[]>("/core/definition?type=1", {
          method: "GET"
        }),
        {
          default: () => [],
        }
      );

      if (error.value) {
        errorMsg.value = error.value?.statusMessage ?? null;
        console.error(error.value);
        return null;
      }

      formDefinitions.value = data.value.map(
        (form) =>
          ({
            ...form,
            latestVersionId: form.appVersionControls[0].id,
          } as Definition)
      );

      for (const form of data.value) {
        await actions.loadFormBlocks(form.latestVersionId);
      }

      console.log("value", formsBlocks.value);

      return data.value;
    },
    loadFormBlocks: async (id?: string) => {
      if (!id) {
        return null;
      }
      const { data: blocks, error } = await useAsyncData(
        "formBlocks",
        () => useNuxtApp().$https<FormBlock[]>(`/form/block?versionId=${id}`, {
          method: "GET",
        }),
        {
          default: () => [],
        }
      );

      if (error.value) {
        errorMsg.value = error.value?.statusMessage ?? null;
        return null;
      }

      selectedFormBlocks.value = blocks.value;
      formsBlocks[id] = blocks.value
      return blocks.value;
    },
    deleteForm: async (id: string) => {
      const { error } = await useHttps(`/core/definition/${id}`, {
        method: "DELETE",
        default: () => null,
      });
      if (error) {
        errorMsg.value = error.value?.statusMessage ?? null;
        return null;
      }

      formDefinitions.value = formDefinitions.value.filter(
        (form) => form.id !== id
      );
    },
  };

  const formBlocks = computed(() => {
    console.log(selectedVersionId.value ?? "")
    return formsBlocks[selectedVersionId.value ?? ""] ?? []
  });

  const formDefinition = computed(
    () =>
      formDefinitions.value.find(
        (form) => form.id === selectedVersionId.value
      ) ?? null
  );

  onBeforeMount(async () => {
    await actions.loadForms();
  });

  watch(selectedVersionId, async () => {
    if (selectedVersionId.value) await actions.loadFormBlocks(selectedVersionId.value);
  })

  return {
    actions,
    formDefinitions,
    selectedFormBlocks,
    formDefinition,
    errorMsg,
  };
});
