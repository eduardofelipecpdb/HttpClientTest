using System;
using System.Net.Http;
using System.Threading.Tasks;
using HttpClientTest.Interfaces;
using Newtonsoft.Json;
using HttpClientTest.Models;

namespace HttpClientTest.Services
{
    public class GitHubService : IGitHubService
    {
        private const string Url = "https://api.github.com/repos";
        private readonly HttpClient _client;

        public GitHubService(HttpClient client)
        {
            _client = client;
        }

        public async Task<Root> GetRepoInfo(RepoInfo informacaoRepositorio)
        {
            _client.DefaultRequestHeaders.Add("User-Agent", "request");
            var httpResponse = _client.GetAsync($"{Url}/{informacaoRepositorio.OwnerName}/{informacaoRepositorio.RepoName}").Result;

            if (!httpResponse.IsSuccessStatusCode)
            {
                throw new Exception("Cannot update todo task");
            }

            Root RepoInfoResult = JsonConvert.DeserializeObject<Root>(await httpResponse.Content.ReadAsStringAsync());
            return RepoInfoResult;
        }
    }
}