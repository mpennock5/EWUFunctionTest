using System.Net;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace EWU.Function
{
    public class JokeFunction
    {
        private readonly ILogger _logger;

        public JokeFunction(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<JokeFunction>();
        }

        [Function("JokeFunction")]
        public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var JokeService = new JokeService();
            var joke = JokeService.GetJoke();
            var response = req.CreateResponse(HttpStatusCode.OK);
            await response.WriteAsJsonAsync(joke);
            return response;    
            // var response = req.CreateResponse(HttpStatusCode.OK);
            // response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            // string name = req.Query["name"];

            // string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            // dynamic data = JsonConvert.DeserializeObject(requestBody);
            // name = name ?? data?.name;

            // response.WriteString(
            //     string.IsNullOrEmpty(name)
            //         ? "this HTTP triggered function executed successfully. Pass a name"
            //         : $"Hello, {name}. This HTTP triggered function worked."
            // );

            // return response;
        }
    }
}
