import { DefinitionTypes, type Definition } from "~/models/Definition";
import { InputType, type FormBlock, type FormElement } from "~/models/Forms";

export const useFormStore = defineStore("form", () => {
  const { value: state } = useState(() => ({
    seletedVersionId: null as string | null,
    selectedFormBlocks: [] as FormBlock[],
    formDefinitions: [] as Definition[],
    errorMsg: null as string | null,
    formElements: {} as Record<string, FormElement[]>,
  }));

  const formsBlocks = ref<Record<string, FormBlock[]>>({}) 

  const actions = {
    loadForms: async () => {
      const { data, error } = await useHttps<Definition[]>(
        `/core/definition/?type=1`,
        {
          method: "GET",
          default: () => [],
        }
      );

      if (error.value) {
        state.errorMsg = error.value?.statusMessage ?? null;
        console.error(error.value);
        return null;
      }

      state.formDefinitions = data.value.map(
        (form) =>
          ({
            ...form,
            latestVersionId: form.appVersionControls[0].id,
          } as Definition)
      );

      for (const form of state.formDefinitions) {
        await actions.loadFormBlocks(form.latestVersionId);
      }

      return data.value;
    },
    addForm: async (form: Definition) => {
      form.definitionType = DefinitionTypes.Form;
      const { data, error } = await useHttps<Definition>(`/core/definition`, {
        method: "POST",
        body: form,
        default: () => ({} as Definition),
      });

      if (error.value || !data.value) {
        state.errorMsg = error.value?.statusMessage ?? null;
        return null;
      }

      state.formDefinitions.push(data.value);

      return data.value;
    },
    loadFormBlocks: async (id?: string) => {
      if (!id) {
        return null;
      }

      if (formsBlocks.value[id]) {
        return formsBlocks.value[id];
      }

      const { data: blocks, error } = await useHttps<FormBlock[]>(
        `/form/block/?versionId=${id}`,
        {
          method: "GET",
          default: () => [],
        }
      );

      if (error.value) {
        state.errorMsg = error.value?.statusMessage ?? null;
        return null;
      }

      state.selectedFormBlocks = blocks.value;
      formsBlocks.value[id] = blocks.value;
      return blocks.value;
    },
    addBlock: async (block: FormBlock) => {
      const { data, error } = await useHttps<FormBlock>(`/form/block`, {
        method: "POST",
        body: block,
        default: () => ({} as FormBlock),
      });

      if (error.value || !data.value) {
        state.errorMsg = error.value?.statusMessage ?? null;
        return null;
      }

      if (formsBlocks.value[data.value.versionId]) {
        console.log("daf", {...data.value})
        formsBlocks.value[data.value.versionId].push({...data.value});
      }

      console.log("data.value", formsBlocks.value[data.value.versionId][formsBlocks.value[data.value.versionId].length - 1]);

      return formsBlocks.value[data.value.versionId];
    },
    deleteForm: async (id: string) => {
      const { error } = await useHttps(`/core/definition/${id}`, {
        method: "DELETE",
        default: () => null,
      });
      if (error) {
        state.errorMsg = error.value?.statusMessage ?? null;
        return null;
      }

      state.formDefinitions = state.formDefinitions.filter(
        (form) => form.id !== id
      );
    },
  };

  const getters = {
    get formDefinition() {
      return (
        state.formDefinitions.find(
          (form) => form.id === state.seletedVersionId
        ) ?? null
      );
    },
    defaultBlock(element: FormElement) {
      // Generate default data for form block
      if (!state.seletedVersionId) {
        return null;
      }
      const defaultBlock: FormBlock = {
        name: "Text",
        displayName: "Text Input",
        versionId: state.seletedVersionId,
        element,
        schema: {
          inputType: InputType.Undefined,
          searchable: false,
          required: false,
          readOnly: false,
          autocomplete: false
        }
      };
      return defaultBlock;
    },
  };

  onBeforeMount(async () => {
    await actions.loadForms();
  });

  watch(
    () => state.seletedVersionId,
    async () => {
      if (state.seletedVersionId)
        await actions.loadFormBlocks(state.seletedVersionId);
    },
    { immediate: true }
  );

  return {
    state,
    formsBlocks,
    actions,
    get: getters,
  };
});
