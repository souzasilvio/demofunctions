﻿using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM365.BackEndFunctions.Services
{
    public class StorageHelper
    {
        private readonly string connectionString;
        private readonly CloudQueue cloudQueueClientProduto;
        public readonly string filaProdutos = "produto";
        

        public enum TipoFila { Produto = 0}

        public StorageHelper()
        {
            connectionString = Environment.GetEnvironmentVariable("AzureWebJobsStorage");

            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);            
            CloudQueueClient queueClient = storageAccount.CreateCloudQueueClient();

            //prepara fila produto
            cloudQueueClientProduto = queueClient.GetQueueReference(filaProdutos);
            cloudQueueClientProduto.CreateIfNotExists();

        }

        
        public void InserirMensagem(TipoFila fila, string message)
        {
            var cloudMesage = new CloudQueueMessage(message);
            if(fila == TipoFila.Produto)
                cloudQueueClientProduto.AddMessageAsync(cloudMesage).GetAwaiter().GetResult();
            Console.WriteLine($"Mensagem inserida na fila: {message}");
        }
    }
}
