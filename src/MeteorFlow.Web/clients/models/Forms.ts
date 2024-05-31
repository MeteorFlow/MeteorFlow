// export interface FormDefinition {
//   id: string;
//   name: string;
//   description: string;
//   baseDefinition: FormDefinition;
//   isDefault: boolean;
//   formBlocks: Array<FormBlock>;
// }

export interface FormBlock {
  id: string;
  name: string;
  element: FormElementType;
  displayName: string;
  extraConfig?: {[k: string]: any};
}

export interface FormElementType {
  displayName: string;
  description: string;
  icon: string;
  schema: ElementSchema;
}

export interface ElementSchema {
  inputType: InputType;
  searchable: boolean;
  required: boolean;
  readOnly: boolean;
  autocomplete: boolean;
}



enum InputType {
  Undefined = 0,
  Static,
  Text,
  Select,
  Choice,
  Slider,
  Button,
  Object,
}