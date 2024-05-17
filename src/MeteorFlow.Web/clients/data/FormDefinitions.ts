import { FormElements } from "./FormElement";
import type { FormDefinition } from "~/models/FormDefinition";

export const FormDefinitions: Array<FormDefinition> = [
  {
    id: "e3e52499-2b22-402f-ac81-ae3cf6ef44c0",
    name: "Built-in template",
    isDefault: true,
    formBlocks: [
      {
        id: "3b732e89-af2f-4793-a234-45c9dac1f590",
        name: "title",
        displayName: "Tiêu đề",
        element: FormElements["text"],
      },
      {
        id: "a3232fd5-64e5-464a-9ae3-fcab5d906818",
        name: "emergency",
        displayName: "Khẩn cấp",
        element: FormElements["text"],
      },
      {
        id: "0d3007aa-d3e4-4562-8532-a3d17a95d4fc",
        name: "content",
        displayName: "Nội dung",
        element: FormElements["text"],
      },
      {
        id: "68f49837-8a4e-4294-9df2-091068c01795",
        name: "notificationDate",
        displayName: "Ngày gửi thông báo",
        element: FormElements["text"],
      },
    ],
  },
  {
    id: "3f71b137-1c21-4829-af0a-446d77849784",
    name: "Test template 1",
    isDefault: false,
    formBlocks: [],
  },
];
