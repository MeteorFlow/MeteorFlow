import { defineEventHandler, getQuery } from 'h3';
import airflowService from '../service/airflow';

export default defineEventHandler(async (event) => {
  const query = getQuery(event);
  const { endpoint, dagId } = query;

  switch (endpoint) {
    case 'getDAGs':
      return await airflowService.getDAGs();
    case 'getDAGRuns':
      if (dagId) {
        return await airflowService.getDAGRuns(dagId as string);
      }
      return { error: 'dagId is required for getDAGRuns' };
    default:
      return { error: 'Invalid endpoint' };
  }
});