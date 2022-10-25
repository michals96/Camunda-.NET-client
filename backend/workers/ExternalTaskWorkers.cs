using CamundaClient.Dto;
using CamundaClient.Worker;

namespace poc.workers
{
    [ExternalTaskTopic("ConfirmAndNotify")]
    public class ConfirmAndNotifyAdapter : IExternalTaskAdapter
    {
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Console.WriteLine("ConfirmAndNotifyAdapter: Confirmation sent to user!");
            Console.WriteLine("ConfirmAndNotifyAdapter: Notification sent to dispatcher!");
            Console.WriteLine("ConfirmAndNotifyAdapter: List request as NEW!");
        }
    }

    [ExternalTaskTopic("NotifySupport")]
    public class NotifySupportAdapter : IExternalTaskAdapter
    {
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Console.WriteLine("NotifySupportAdapter: Notification sent to the support team!");
        }
    }

    [ExternalTaskTopic("ChangeRequestStatus")]
    public class ChangeRequestStatusAdapter : IExternalTaskAdapter
    {
        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            Console.WriteLine("ChangeRequestStatusAdapter: Request status changed to IN_PROGRESS!");
        }
    }
}
