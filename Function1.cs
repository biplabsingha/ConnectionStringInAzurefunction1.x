using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;

namespace ConnectionString_1_0
{
    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            //Get Connection String
            var connectionString = ConfigurationManager.ConnectionStrings["CRM_CONNECTION_STRING"].ConnectionString;

            //Get App Settings Value
            var setting1 = Environment.GetEnvironmentVariable("Settings1", EnvironmentVariableTarget.Process);

            return req.CreateResponse(HttpStatusCode.OK, "Connection String " + connectionString + Environment.NewLine + "App settings :" + setting1);

        }
    }
}
