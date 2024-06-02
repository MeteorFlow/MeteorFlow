// export interface FormDefinition {
//   id: string;
//   name: string;
//   description: string;
//   baseDefinition: FormDefinition;
//   isDefault: boolean;
//   formBlocks: Array<FormBlock>;
// }

export interface FormBlock {
  id?: string;
  name: string;
  element: FormElement;
  displayName: string;
  extraConfig?: { [k: string]: any };
  schema: ElementSchema;
  versionId: string;
}

export interface FormElement {
  name: string;
  description: string;
  icon?: string;
  renderer: string;
}

export interface ElementSchema {
  inputType: InputType;
  searchable: boolean;
  required: boolean;
  readOnly: boolean;
  autocomplete: boolean;
}

export enum InputType {
  Undefined = 0,
  Static,
  Text,
  Select,
  Choice,
  Slider,
  Button,
  Object,
}
