namespace ApiService.Infrastructure
{
    using System.Net.Http;
    using System.Text;
    using System.Text.Json;
    using System.Threading.Tasks;
    using ApiService.Contracts.Queries;
    using Microsoft.Extensions.Logging;

    public class CommandServiceClient : ICommandServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly ILogger<CommandServiceClient> _logger;
        private readonly CommandServiceConfiguration _commandServiceConfiguration;

        public CommandServiceClient(
            IHttpClientFactory httpClientFactory,
            ILogger<CommandServiceClient> logger,
            CommandServiceConfiguration commandServiceConfiguration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _logger = logger;
            _commandServiceConfiguration = commandServiceConfiguration;
        }

        public async Task SendPlatformToCommand(PlatformReadQuery query)
        {
            var httpContent = new StringContent(
                JsonSerializer.Serialize(query),
                Encoding.UTF8,
                "application/json");

            var response = await _httpClient.PostAsync($"{_commandServiceConfiguration.BaseUrl}{_commandServiceConfiguration.PlatformEndpoint}", httpContent);

            if (response.IsSuccessStatusCode)
            {
                _logger.LogInformation("OK");
            }
            else
            {
                _logger.LogInformation("NOT OK");
            }
        }
    }
}