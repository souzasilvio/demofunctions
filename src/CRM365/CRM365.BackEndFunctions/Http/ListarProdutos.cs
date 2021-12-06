using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Attributes;
using Aliencube.AzureFunctions.Extensions.OpenApi.Core.Enums;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace CRM365.BackEndFunctions.Http
{
    public static class ListarProdutos
    {
        [FunctionName("ListarProdutos")]
        [OpenApiOperation(operationId: "ListarProdutos", tags: new[] { "Produto", "v1" }, Summary = "Listar produtos", Description = "Listar produtos.", Visibility = OpenApiVisibilityType.Important)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Model.ProdutoDto>), Summary = "Lista com os contato relacionados a conta", Description = "Lista de produtos")]

        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = "api/produto/listar")]HttpRequestMessage req)
        {
            var lista = new List<Model.ProdutoDto>();
            lista.Add(new Model.ProdutoDto() { Id = new System.Guid(), Nome = "Produto 1"});
            lista.Add(new Model.ProdutoDto() { Id = new System.Guid(), Nome = "Produto 2" });

            return req.CreateResponse(HttpStatusCode.OK, lista);
        }
    }
}
