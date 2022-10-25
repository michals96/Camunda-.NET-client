using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.Api.Client.Message;
using Camunda.Api.Client.ProcessInstance;
using Camunda.Api.Client.UserTask;
using Microsoft.Extensions.Logging;
using poc.Dtos;

namespace poc.Services
{
    public interface ICamundaService
    {
        Task<ProcessStateDto> Process(string processId, ProcessStateDto processStateDto);
        Task SelectLicense(String processInstanceId);
        Task<String> StartLicensingProcess(String businessKey);
        String GetInstanceIdByBusinessKey(String businessKey);
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

        public async Task SelectLicense(String processInstanceId)
        {
            ActivityInstanceInfo task = await _camundaClient.ProcessInstances[processInstanceId].GetActivityInstance();
            _logger.LogInformation(task.Id);
            TaskQuery taskQuery = new TaskQuery() { Active = true, ProcessInstanceId = processInstanceId };
            var userTaskId = _camundaClient.UserTasks.Query(taskQuery).List().Result.Last().Id;
            _logger.LogInformation(userTaskId);
            //Task<Camunda.Api.Client.UserTask.UserTaskInfo> selectLicenseTask= _camundaClient.UserTasks["select_license"].Get();
            //selectLicenseTask.
            await _camundaClient.UserTasks[userTaskId].Complete(new CompleteTask());
            //CompleteTask completeTask = new CompleteTask();
            //completeTask.SetVariable("accepted", "true");
            //_camundaClient.UserTasks["select_license"].Complete(completeTask);
            //_logger.LogInformation(_camundaClient.UserTasks["select_license"].ToString());
            
        }

        public async Task<String> StartLicensingProcess(String businessKey)
        {
            
            var message = new CorrelationMessage() { MessageName = "startProcess", BusinessKey = businessKey, All = true };
            await _camundaClient.Messages.DeliverMessage(message);
            return "Success";
        }

        public String GetInstanceIdByBusinessKey(String businessKey)
        {
            var query = new ProcessInstanceQuery() { BusinessKey = businessKey, Active = true };
            var processInstanceId = _camundaClient.ProcessInstances.Query(query).List().Result.Last().Id;
            return processInstanceId.ToString();
        }

        public String GetInstanceIdInstanceID(String Id)
        {
            var query = new ProcessInstanceQuery() { ProcessInstanceIds = new List<string>() { Id }, Active = true };
            var processInstanceId = _camundaClient.ProcessInstances.Query(query).List().Result.Last().Id;
            _camundaClient.ProcessInstances[processInstanceId].GetActivityInstance();
            return processInstanceId.ToString();
        }
    }
}
