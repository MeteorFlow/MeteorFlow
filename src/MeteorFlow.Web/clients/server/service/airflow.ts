const config = useRuntimeConfig();

const airflowService = {
  async getDAGs() {
    return await $fetch(`${config.public.airflow}/dags`);
  },

  async getDAGRuns(dagId: string) {
    return await $fetch(`${config.public.airflow}/dags/${dagId}/dagRuns`);
  },
};

export default airflowService;