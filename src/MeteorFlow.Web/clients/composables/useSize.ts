import { SizeDefinition, type Size } from "~/models"
export const useSize = (size: Size) => {
  const widthFraction = SizeDefinition.indexOf(size) + 1;
  
  if (size === 'full') {
    return 'w-full';
  } else {
    return `w-${widthFraction}/6`;
  }
};