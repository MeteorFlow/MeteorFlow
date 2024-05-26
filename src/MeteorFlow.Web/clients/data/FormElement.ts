import { InputType, type FormDefinition } from "~/models/FormDefinition";

export const FormElements = {
  text: {
    displayName: "Text input",
    description: "Single line text input",
    icon: "",
    schema: {
      inputType: InputType.Text,
      required: true,
      autocomplete: true,
      readOnly: false,
      searchable: true,
    },
  },
  bool: {
    displayName: "Choice input",
    description: "Plain checkout input",
    icon: "material-symbols-check-box-outline",
    schema: {
      inputType: InputType.Choice,
      required: true,
      autocomplete: true,
      readOnly: false,
      searchable: true,
    },
  }
};
