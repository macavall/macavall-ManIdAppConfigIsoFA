using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace AppConfig1
{
    public class http1
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;

        public http1(ILoggerFactory loggerFactory, IConfiguration configuration)
        {
            _logger = loggerFactory.CreateLogger<http1>();
            _configuration = configuration;
        }

        [Function("http1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequestData req)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/plain; charset=utf-8");

            string result = _configuration["TestApp:Settings:Message"] ;

            response.WriteString(result);

            return response;
        }
    }
}
