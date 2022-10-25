using System;
using CamundaClient;

namespace SimpleCalculationProcess
{
    class Program
    {

        private static string logo =
                "   ____                                _         ____  ____  __  __ \n" +
                "  / ___|__ _ _ __ ___  _   _ _ __   __| | __ _  | __ )|  _ \\|  \\/  |\n" +
                " | |   / _` | '_ ` _ \\| | | | '_ \\ / _` |/ _` | |  _ \\| |_) | |\\/| |\n" +
                " | |__| (_| | | | | | | |_| | | | | (_| | (_| | | |_) |  __/| |  | |\n" +
                "  \\____\\__,_|_| |_| |_|\\__,_|_| |_|\\__,_|\\__,_| |____/|_|   |_|  |_|\n";

        private static void Main(string[] args)
        {
            
            Console.WriteLine( logo + "\n\n" + "Deploying models and start External Task Workers.\n\nPRESS ANY KEY TO STOP WORKERS.\n\n");

            CamundaEngineClient camunda = new CamundaEngineClient();            
            camunda.Startup(); // Deploys all models to Camunda and Start all found ExternalTask-Workers
            Console.ReadLine(); // wait for ANY KEY
            camunda.Shutdown(); // Stop Task Workers
        }

        private static void writeTasksToConsole(CamundaEngineClient camunda)
        {
            var tasks = camunda.HumanTaskService.LoadTasks();
            foreach (var task in tasks)
            {
                Console.WriteLine(task.Name);
            }
        }

    }
}
