using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.Api.Client.Message;
using Camunda.Api.Client.UserTask;
using Microsoft.Extensions.Logging;
using poc.Dtos;

namespace poc.Services
{
    public interface ICamundaService
    {
        Task<ProcessStateDto> Process(string processId, ProcessStateDto processStateDto);
        Task<String> SelectLicense(String processInstanceId);
        Task<List<CorrelationResult>> StartLicensingProcess(String businessKey);
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

            // Task<List<Camunda.Api.Client.UserTask.UserTaskInfo>> userTasks = _camundaClient.UserTasks.Query().List();

            // _camundaClient.UserTasks["select_license"].

            _logger.LogInformation(allTasks.ToString());

            return new ProcessStateDto()
            {
                Id = processId,
                ClientType = processStateDto.ClientType,
                Name = Guid.NewGuid().ToString(),
                OrderDecision = "dasda"
            };
        }

        public async Task<String> SelectLicense(String processInstanceId)
        {
            Task<Camunda.Api.Client.ProcessInstance.ActivityInstanceInfo> task = _camundaClient.ProcessInstances[processInstanceId].GetActivityInstance();
            //Task<Camunda.Api.Client.UserTask.UserTaskInfo> selectLicenseTask= _camundaClient.UserTasks["select_license"].Get();
            //selectLicenseTask.
            await _camundaClient.UserTasks[task.Id.ToString()].Complete(new CompleteTask());
            //CompleteTask completeTask = new CompleteTask();
            //completeTask.SetVariable("accepted", "true");
            //_camundaClient.UserTasks["select_license"].Complete(completeTask);
            //_logger.LogInformation(_camundaClient.UserTasks["select_license"].ToString());
            return "Success";
        }

        public async Task<List<CorrelationResult>> StartLicensingProcess(String businessKey)
        {
            var message = new CorrelationMessage() { MessageName = "startProcess", BusinessKey = businessKey, All = true };
            return await _camundaClient.Messages.DeliverMessage(message);
            // var task1 = _camundaClient.Messages.DeliverMessage(message);
            // task1.Wait();
            // var id = task1.Result.First().ProcessInstance.Id;
            // _logger.LogInformation(id.ToString());
            // return "ok";
            //task.First().ProcessInstance.Id;
        }
    }
}
