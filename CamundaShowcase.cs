using CamundaClient;

namespace poc
{
    public class CamundaShowcase : IHostedService
    {


        private readonly CamundaEngineClient camunda;

        public CamundaShowcase()
        {
            camunda = new CamundaEngineClient();

        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("1 d00pa");
            camunda.Startup(); // Deploys all models to Camunda and Start all found ExternalTask-Workers
            // Console.ReadLine(); // wait for ANY KEYthrow new NotImplementedException();
            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("2 d00pa");
            camunda.Shutdown();
            return Task.CompletedTask;
        }
    }
}
