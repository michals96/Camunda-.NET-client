using CamundaClient;

namespace poc
{
    public class CamundaService : IHostedService
    {

        private readonly CamundaEngineClient camunda;

        public CamundaService()
        {
            camunda = new CamundaEngineClient();
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
