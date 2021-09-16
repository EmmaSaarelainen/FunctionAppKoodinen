using System;
using System.Linq;
using System.Net.Mail;
using System.Text;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Func2.Models;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;


namespace func
{
    public static class ViikottainenEmailYllapitajille
    {
        //("* * 14 * * Sat")
        [FunctionName("ViikottainenEmailYllapitajille")]
        public static void Run([TimerTrigger("0 25 12 * * Fri")] TimerInfo myTimer, ILogger log)
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
            var client = new SecretClient(new Uri("urlazureen"), new DefaultAzureCredential(), options);

            KeyVaultSecret secretKoodinenEmail = client.GetSecret("tämäonsalaista");
            string secretValueKoodinenEmail = secretKoodinenEmail.Value;

            KeyVaultSecret secretSalaSana = client.GetSecret("accessdenied");
            string secretValueSalaSana = secretSalaSana.Value;

            KeyVaultSecret secretVastaanottaja = client.GetSecret("itssecret");
            string secretValueVastaanottaja = secretVastaanottaja.Value;

            MailMessage mailMessage = new MailMessage(secretValueKoodinenEmail, secretValueVastaanottaja);
            mailMessage.Subject = "Viikon palautteet";

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
            smtpClient.Credentials = new System.Net.NetworkCredential()
            {
                UserName = secretValueKoodinenEmail,
                Password = secretValueSalaSana
            };
            smtpClient.EnableSsl = true;

            var viesti = LuoViesti();

            mailMessage.BodyEncoding = System.Text.Encoding.UTF8;
            mailMessage.IsBodyHtml = true;
            mailMessage.Body = viesti;
            smtpClient.Send(mailMessage);

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }

        private static string LuoViesti()
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
            var client = new SecretClient(new Uri("urlazureen"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret("confidential");
            string secretValue = secret.Value;
            using dbKoodinenContext db = new dbKoodinenContext(secretValue);
            var alkuPvm = DateTime.Now.AddDays(-7);
            //MUUTA: Hae Datetimen perusteella, kun se on muutettu tietokantaan
            var palautteet = db.Palaute.Where(p => p.Pvm > alkuPvm).Select(p => new { p.Lahettaja, p.Teksti, p.Pvm });
            StringBuilder viesti = new StringBuilder();
            viesti.AppendLine(@"<!DOCTYPE html>
                                <html lang=""en"">
                                <head>
                                    <meta charset=""UTF-8"">
                                    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"">
                                    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
                                    <title> Document </title>
                                    <link rel=""stylesheet"" href=""https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/css/bootstrap.min.css"" integrity=""sha384-Gn5384xqQ1aoWXA+058RXPxPg6fy4IWvTNh0E263XmFcJlSAwiGgFAW/dAiS6JXm"" crossorigin=""anonymous"">
                                </head>
                                <body style=""max-width: 90%"">");
            viesti.AppendLine(@"<table>");
            foreach (var p in palautteet)
            {
                viesti.AppendLine(@$"<tr>
                                         <td><p>{p.Pvm}:    </p></td>
                                         <td><p><b>Lähettäjä: {p.Lahettaja}</b></p></td>
                                         <td><p>{p.Teksti}</p></td>
                                     </tr>");
            }
            viesti.AppendLine(@"</table>");
            viesti.AppendLine(@"</body>
                                </html>");

            return viesti.ToString();
        }
    }
}
