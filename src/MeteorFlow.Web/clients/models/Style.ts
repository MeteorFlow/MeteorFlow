export const SizeDefinition = ['xs', 'sm', 'md', 'lg', 'xl', 'full'] as const
const FlexDirectionDefinition = ['row', 'column'] as const
const AlignDefinition = ['left', 'center', 'right'] as const

export type Size = typeof SizeDefinition[number]
export type FlexDirection = typeof FlexDirectionDefinition[number]
export type Align = typeof AlignDefinition[number]