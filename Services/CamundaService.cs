using Camunda.Api.Client;
using Camunda.Api.Client.ExternalTask;
using Camunda.Api.Client.Message;
using Camunda.Api.Client.ProcessInstance;
using Camunda.Api.Client.UserTask;
using poc.Dtos;

namespace poc.Services
{
    public interface ICamundaService
    {
        Task<ProcessStateDto> Process(string processId, ProcessStateDto processStateDto);
        Task CompleteUserTaskWithNoVariables(String processInstanceId);
        Task<String> StartLicensingProcess(String businessKey);
        String GetInstanceIdByBusinessKey(String businessKey);
        Task CompleteUserTaskWithVariables(String processInstanceId);
        String getActiveUserTaskId(String processInstanceId);
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

        public async Task CompleteUserTaskWithNoVariables(String processInstanceId)
        {
            // await SetProcessVariables(processInstanceId);
            var userTaskId = getActiveUserTaskId(processInstanceId);
            await _camundaClient.UserTasks[userTaskId].Complete(new CompleteTask()); 
        }

        public async Task CompleteUserTaskWithVariables(String processInstanceId)
        {
            var userTaskId = getActiveUserTaskId(processInstanceId);

            var completeTask = new CompleteTask();
            completeTask.SetVariable("accepted", false);
            completeTask.SetVariable("rejected", false);
            completeTask.SetVariable("moreDetails", true);

            await _camundaClient.UserTasks[userTaskId].Complete(completeTask);
        }

        private async Task SetProcessVariables(String processInstanceId)
        {
            var variables = _camundaClient.ProcessInstances[processInstanceId].Variables;
            await variables.Set("accepted", VariableValue.FromObject(true));
            await variables.Set("rejected", VariableValue.FromObject(false));
            await variables.Set("moreDetails", VariableValue.FromObject(false));
        }


        public String getActiveUserTaskId(String processInstanceId)
        {
            var taskQuery = new TaskQuery() { Active = true, ProcessInstanceId = processInstanceId };
            return _camundaClient.UserTasks.Query(taskQuery).List().Result.Last().Id;
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
    }
}

//_logger.LogInformation(task.Id);
//     TaskQuery taskQuery = new TaskQuery() { Active = true, ProcessInstanceId = processInstanceId };
// var userTaskId = _camundaClient.UserTasks.Query(taskQuery).List().Result.Last().Id;
//_logger.LogInformation(userTaskId);
//Task<Camunda.Api.Client.UserTask.UserTaskInfo> selectLicenseTask= _camundaClient.UserTasks["select_license"].Get();
//selectLicenseTask.
//CompleteTask completeTask = new CompleteTask();
//completeTask.SetVariable("accepted", "true");
//_camundaClient.UserTasks["select_license"].Complete(completeTask);
//_logger.LogInformation(_camundaClient.UserTasks["select_license"].ToString());
