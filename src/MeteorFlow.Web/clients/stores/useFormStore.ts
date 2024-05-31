import type { Definition } from "~/models/Definition";
import type { FormBlock } from "~/models/Forms";

export const useFormStore = defineStore("form", () => {
  const selectedVersionId = ref<string | null>(null);
  const errorMsg = ref<string| null>(null);
  const formsBlocks = ref<Record<string, FormBlock[]>>({});
  const formDefinitions = ref<Definition[]>([]);

  const actions = {
    setSelectedVersionId: (id: string) => {
      selectedVersionId.value = id;
    },
    loadForms: async () => {
      if (formDefinitions.value?.length > 0) {
        return formDefinitions.value;
      }
      const { data, error } = await useAsyncData('form', () => useNuxtApp().$https<Definition[]>(
        "/core/definition?type=1"
      ), {
        default: () => []
      });

      if (error.value) {
        errorMsg.value = error.value?.statusMessage ?? null;
        console.error(error.value);
        return null;
      }

      formDefinitions.value = data.value.map(form => ({ ...form, latestVersionId: form.appVersionControls[0].id} as Definition));

      console.log(formDefinitions.value);
      for (const form of data.value) {
        await actions.loadFormBlocks(form.latestVersionId);
      }

      return data.value;
    },
    loadFormBlocks: async (id?: string) => {
      if (!id) {
        return null;
      }
      const { data: blocks, error } = await useAsyncData('formBlocks', () => useNuxtApp().$https<FormBlock[]>(
        `block?versionId=${id}`,
      ), {
        default: () => []
      });

      if (error) {
        errorMsg.value = error.value?.statusMessage ?? null;
        return null;
      }


      formsBlocks.value[id] = blocks.value;
      return blocks.value;
    },
    deleteForm: async (id: string) => {
      const { error } = await useHttps(
        `/core/definition/${id}`,
        {
          method: "DELETE",
          default: () => null,
        }
      );
      if (error) {
        errorMsg.value = error.value?.statusMessage ?? null;
        return null;
      }

      formDefinitions.value = formDefinitions.value.filter(
        (form) => form.id !== id
      );
    },
  };

  const formBlocks = computed(() =>
    !selectedVersionId.value
      ? []
      : formsBlocks.value[selectedVersionId.value] ?? []
  );

  const formDefinition = computed(() =>
    formDefinitions.value.find(
      (form) => form.id === selectedVersionId.value
    ) ?? null
  );


  return {
    actions,
    formDefinitions,
    formBlocks,
    formDefinition,
    errorMsg
  };
});
