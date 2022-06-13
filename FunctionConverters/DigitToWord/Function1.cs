using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace DigitToWordHttpTrigger
{
    namespace NumberInLanguages
    {
        public static class FunctionDigitInHebrew
        {
            [FunctionName("DigitInHebrew")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
                HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string digitAsString = req.Query["digit"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                digitAsString = digitAsString ?? data?.digit;

                var isSucceed = int.TryParse(digitAsString, out int digit);

                if (!isSucceed)
                    return new OkObjectResult("Is not a digit");

                switch (digit)
                {
                    case 0: return new OkObjectResult("Efes");
                    case 1: return new OkObjectResult("Ehad");
                    case 2: return new OkObjectResult("Shatim");
                    case 3: return new OkObjectResult("Shalosh");
                    case 4: return new OkObjectResult("Arba");
                    case 5: return new OkObjectResult("Hamesh");
                    case 6: return new OkObjectResult("Shesh");
                    case 7: return new OkObjectResult("Sheva");
                    case 8: return new OkObjectResult("Shmone");
                    case 9: return new OkObjectResult("Tesha");
                }

                return new OkObjectResult("No such digit. Insert 0-9");
            }
        }

        public static class FunctionDigitInEnglish
        {
            [FunctionName("DigitInEnglish")]
            public static async Task<IActionResult> Run(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
                HttpRequest req,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");

                string digitAsString = req.Query["digit"];

                string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
                dynamic data = JsonConvert.DeserializeObject(requestBody);
                digitAsString = digitAsString ?? data?.digit;

                var isSucceed = int.TryParse(digitAsString, out int digit);

                if (!isSucceed)
                    return new OkObjectResult("Is not a digit");

                switch (digit)
                {
                    case 0: return new OkObjectResult("Zero");
                    case 1: return new OkObjectResult("One");
                    case 2: return new OkObjectResult("Two");
                    case 3: return new OkObjectResult("Three");
                    case 4: return new OkObjectResult("Four");
                    case 5: return new OkObjectResult("Five");
                    case 6: return new OkObjectResult("Six");
                    case 7: return new OkObjectResult("Seven");
                    case 8: return new OkObjectResult("Eight");
                    case 9: return new OkObjectResult("Nine");
                }

                return new OkObjectResult("No such digit. Insert 0-9");
            }
        }
    }
}