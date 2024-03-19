/**
 * @interface TabItem
 * @property {string} icon - Visit https://icones.js.org/ to search for icons
 */
export interface TabItem {
  label: string;
  slot: string;
  icon?: string;
  disabled?: boolean;
}

export type TabOrientation = "vertical" | "horizontal";
