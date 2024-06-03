// types.ts
export interface DAG {
  dag_id: string;
  // Add other properties as necessary
}

export interface DAGRun {
  run_id: string;
  // Add other properties as necessary
}

export interface Metrics {
  storage: string;
  dataTransfer: string;
  writtenData: string;
  compute: string;
  activeComputes: string;
  branches: string;
}