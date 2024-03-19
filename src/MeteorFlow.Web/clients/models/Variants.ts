import type { Align } from ".";

const CardVariantsDefinition = ["content", "list"] as const;
const ChartDefinition = [ "bar", "line", "scatter", "bubble", "polarArea" , "pie", "doughnut", "radar"] as const;
const DialogVariantsDefinition = ["confirm", "info", "warning", "error"] as const;
const SelectVariantsDefinition = ["default", "add"] as const;
const SortDirectionDefinition = ["asc", "desc"] as const;
const TextFieldVariantsDefinition = ["text", "search", "file", "email", "password", "number"] as const;

export type DialogVariants = typeof DialogVariantsDefinition[number];
export type CardVariants = typeof CardVariantsDefinition[number];
export type SortDirection = typeof SortDirectionDefinition[number];
export type ChartVariants = typeof ChartDefinition[number];
export type SelectVariants = typeof SelectVariantsDefinition[number];
export type TextFieldVariants = typeof TextFieldVariantsDefinition[number];

export type TableColumn = { 
  key: string, 
  label: string,
  sortable?: boolean; 
  sort?: <T>(a: T, b: T, direction: SortDirection) => number; 
  direction?: SortDirection; 
  class?: string;
  align?: Align;
}