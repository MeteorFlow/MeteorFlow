export type Validation = true | string

export type ValidateFunction = (value?: string) => Promise<Validation>