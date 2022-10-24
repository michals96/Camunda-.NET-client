using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using poc.Dtos;

namespace poc.Services
{
    public interface ICamundaService
    {
        Task<ProcessStateDto> Process(string processId, ProcessStateDto processStateDto);
    }
    public class CamundaService : ICamundaService
    {
        private readonly CamundaClient _camundaClient;
        private readonly ILogger<CamundaService> _logger;

        public CamundaService(CamundaClient camundaClient, ILogger<CamundaService> logger)
        {
            _camundaClient = camundaClient;
            _logger = logger;
        }

        public async Task<ProcessStateDto> Process(string processId, ProcessStateDto processStateDto)
        {
            List<ExternalTaskInfo> allTasks = await _camundaClient.ExternalTasks.Query().List();

            Task<List<Camunda.Api.Client.UserTask.UserTaskInfo>> userTasks = _camundaClient.UserTasks.Query().List();

            _logger.LogInformation(allTasks.ToString());

            return new ProcessStateDto()
            {
                Id = processId,
                ClientType = processStateDto.ClientType,
                Name = Guid.NewGuid().ToString(),
                OrderDecision = "dasda"
            };
        }
    }
}
