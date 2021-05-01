using HttpClientTest.Models;
using System.Threading.Tasks;
namespace HttpClientTest.Interfaces
{
    public interface IGitHubService
    {
         Task<Root> GetRepoInfo(RepoInfo informacaoRepositorio);
    }
}