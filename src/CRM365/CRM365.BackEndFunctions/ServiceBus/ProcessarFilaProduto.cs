using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.ServiceBus.Messaging;

namespace CRM365.BackEndFunctions.ServiceBus
{
    public static class ProcessarFilaProduto
    {
        [FunctionName("ProcessarFilaProduto")]
        public static void Run([ServiceBusTrigger("fila-produto")]string myQueueItem, TraceWriter log)
        {
            log.Info($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
        }
    }
}
