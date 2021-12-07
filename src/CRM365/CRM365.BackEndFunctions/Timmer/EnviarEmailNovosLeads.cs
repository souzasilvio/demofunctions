using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace CRM365.BackEndFunctions.Timmer
{
    public static class EnviarEmailNovosLeads
    {
        [FunctionName("fc_EnviarEmailNovosLeads")]
        public static void Run([TimerTrigger("%EnviarEmailNovosLeads%")]TimerInfo myTimer, TraceWriter log)
        {
            log.Info($"C# Timer trigger function executed at: {DateTime.Now}");

            var produto = new Model.ProdutoDto() { Id = System.Guid.NewGuid(), Nome = $"Produto {new Random().Next()}", DataCriacao = DateTime.Now };
            string mensagem = JsonConvert.SerializeObject(produto);
            new Services.StorageHelper().InserirMensagem(Services.StorageHelper.TipoFila.Produto, mensagem);

        }
    }
}
