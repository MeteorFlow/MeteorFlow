export interface Definition {
  id: string;
  name: string;
  description: string;
  baseDefinition?: Definition;
  subDefinitions?: Array<Definition>;
  appVersionControls: Array<AppVersionControl>;
  latestVersionId: string;
  icon: string;
  definitionType: DefinitionTypes;
}

export interface AppVersionControl {
  id: string;
  majorVersion: number;
  minorVersion: number;
  patchVersion: number;
  timestamp: Date;
  metadata: Record<string, string>;
}

export enum DefinitionTypes {
    None,
    Form,
    Email,
    Document,
    System,
}