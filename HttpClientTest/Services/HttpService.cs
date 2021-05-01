using Microsoft.Extensions.DependencyInjection;
using HttpClientTest.Interfaces;

namespace HttpClientTest.Services
{
    public static class Bootstrapper
    {
        public static void UseServices(this IServiceCollection services)
        {
            services.AddHttpClient<IGitHubService, GitHubService>();
        }
    }
}