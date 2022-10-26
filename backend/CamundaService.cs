using CamundaClient;

namespace poc
{
    public class CamundaService : IHostedService
    {
        public static string CAMUNDA_URL = "http://localhost:8080/engine-rest/engine/default/";

        private readonly CamundaEngineClient camunda;

        public CamundaService()
        {
            camunda = new CamundaEngineClient(new Uri(CAMUNDA_URL), "demo", "demo");
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            camunda.StartWorkers();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            camunda.Shutdown();
            return Task.CompletedTask;
        }
    }
}
