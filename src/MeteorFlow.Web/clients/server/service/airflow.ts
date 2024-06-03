const API_URL = 'http://your-airflow-url/api/v1';

const airflowService = {
  async getDAGs() {
    return await $fetch(`${API_URL}/dags`);
  },

  async getDAGRuns(dagId: string) {
    return await $fetch(`${API_URL}/dags/${dagId}/dagRuns`);
  },
};

export default airflowService;