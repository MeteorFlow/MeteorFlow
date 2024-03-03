const DialogVariantsDefinition = ["confirm", "info", "warning", "error"] as const;
const CardVariantsDefinition = ["content", "list"] as const;

export type DialogVariants = typeof DialogVariantsDefinition[number];
export type CardVariants = typeof CardVariantsDefinition[number];