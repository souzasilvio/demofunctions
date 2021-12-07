using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;

namespace CRM365.BackEndFunctions.Timmer
{
    public static class Processo1
    {
        [FunctionName("Processo1")]
        public static void Run([TimerTrigger("0 */5 * * * *")]TimerInfo myTimer, TraceWriter log)
        {
            string msg = $"C# Timer trigger function executed at: {DateTime.Now}";
            log.Info(msg);
            new Services.StorageHelper().InserirMensagem(Services.StorageHelper.TipoFila.Logs, msg);
        }
    }
}
