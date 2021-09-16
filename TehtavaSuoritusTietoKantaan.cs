using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Func2.Models;
using System.Linq;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Azure.Core;

namespace Func2
{
    public static class TehtavaSuoritusTietoKantaan
    {
        [FunctionName("TehtavaSuoritusTietoKantaan")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                {
                    Delay= TimeSpan.FromSeconds(2),
                    MaxDelay = TimeSpan.FromSeconds(16),
                    MaxRetries = 5,
                    Mode = RetryMode.Exponential
                }

            };
            var client = new SecretClient(new Uri("urlazureen"), new DefaultAzureCredential(includeInteractiveCredentials:true), options);

            KeyVaultSecret secret = client.GetSecret("t�m�onsalaista");
            string secretValue = secret.Value;
            log.LogInformation(secretValue);

            string query = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            //input = JsonConvert.DeserializeObject<TehtavaSuoritu>(requestBody);

            query = query ?? data?.name;
            string email = data.email.ToString();
            var uusiTeht�v�suoritus = new TehtavaSuoritus();
            uusiTeht�v�suoritus.SuoritusPvm = DateTime.Today;
            uusiTeht�v�suoritus.KayttajaId = HaeId(email, secretValue);
            uusiTeht�v�suoritus.TehtavaId = data.tehtavaid;
            dbKoodinenContext db = new dbKoodinenContext(secretValue);
            db.TehtavaSuoritus.Add(uusiTeht�v�suoritus);
            db.SaveChanges();

            log.LogInformation("onnistui");
            string responseMessage = "";

            return new OkObjectResult(responseMessage);
        }
        public static int HaeId(string email, string connectionstring)
        {
            var k�ytt�j� = new Kayttaja();

            dbKoodinenContext db = new dbKoodinenContext(connectionstring);
            k�ytt�j� = db.Kayttaja.Where(k => k.Email == email).First();
            return k�ytt�j�.KayttajaId;
        }
    }
}
