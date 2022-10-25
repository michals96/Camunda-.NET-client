using System;
using System.Collections.Generic;
using CamundaClient.Dto;
using CamundaClient.Worker;

namespace SimpleCalculationProcess
{
    [ExternalTaskTopic("calculate")]
    [ExternalTaskVariableRequirements("x", "y")]
    class CalculationAdapter : IExternalTaskAdapter
    {

        public void Execute(ExternalTask externalTask, ref Dictionary<string, object> resultVariables)
        {
            long x = Convert.ToInt64(externalTask.Variables["x"].Value);
            long y = Convert.ToInt64(externalTask.Variables["y"].Value);
            long result = x + y;
            resultVariables.Add("result", result);
        }

    }
}
