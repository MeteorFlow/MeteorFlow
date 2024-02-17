export type Position = "s" | "w" | "e" | "n" | "sw" | "nw" | "se" | "ne";
export interface Layout {
  i: string;
  x: number;
  y: number;
  w: number;
  h: number;
  minW?: number;
  minH?: number;
  maxW?: number;
  maxH?: number;
  static?: boolean;
  moved?: boolean;
  isDraggable?: boolean;
  isResizable?: boolean;
};

export type Layouts = Record<string, Layout[]>;

export type ItemCallback = (
  layout: Layout[],
  oldItem: Layout,
  newItem: Layout,
  placeholder: Layout,
  event: MouseEvent,
  element: HTMLElement
) => void;

export type DragOverEvent = MouseEvent & {
  nativeEvent: {
    layerX: number;
    layerY: number;
  } & Event;
};


