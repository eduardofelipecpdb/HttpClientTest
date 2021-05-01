using HttpClientTest.Models;
using Microsoft.AspNetCore.Mvc;
using HttpClientTest.Services;
using Microsoft.Extensions.DependencyInjection;
using HttpClientTest.Interfaces;
using Newtonsoft.Json;
//Autor: Eduardo Felipe de Souza
//Data: 30/04/2021
//Descrição: Projeto para teste de uso de HttpClient, Interfaces e Serviços no .NET Core

namespace HttpClientTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GitHubAPIController : ControllerBase
    {
        [HttpGet]
        [Route("GetBranchInformation")]
        public ActionResult<GitHubAPIController> Get([FromBody] RepoInfo repoInfo)
        {
            var services = new ServiceCollection();
            services.UseServices();
            var serviceProvider = services.BuildServiceProvider();

            var service = serviceProvider.GetRequiredService<IGitHubService>();
            var apiResult = service.GetRepoInfo(repoInfo);

            return Ok(apiResult);
        }
    }
}