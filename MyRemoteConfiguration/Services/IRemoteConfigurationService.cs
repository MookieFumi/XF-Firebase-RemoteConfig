using System.Threading.Tasks;

namespace MyRemoteConfiguration.Services
{
    public interface IRemoteConfigurationService
    {
        Task FetchAndActivateAsync();
        Task<TInput> GetAsync<TInput>(string key);
    }
}
