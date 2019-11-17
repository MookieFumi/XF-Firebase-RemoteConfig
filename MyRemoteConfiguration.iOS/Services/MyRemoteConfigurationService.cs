using System.Threading.Tasks;
using Firebase.RemoteConfig;
using MyRemoteConfiguration.Services;

namespace MyRemoteConfiguration.iOS.Services
{
    public class MyRemoteConfigurationService : IRemoteConfigurationService
    {
        public MyRemoteConfigurationService()
        {
            RemoteConfig.SharedInstance.SetDefaults("RemoteConfigDefaults");
            RemoteConfig.SharedInstance.ConfigSettings = new RemoteConfigSettings(true);
        }

        public async Task FetchAndActivateAsync()
        {
            var status = await RemoteConfig.SharedInstance.FetchAsync(0);
            if (status == RemoteConfigFetchStatus.Success)
            {
                RemoteConfig.SharedInstance.ActivateFetched();
            }
        }

        public async Task<TInput> GetAsync<TInput>(string key)
        {
            var settings = RemoteConfig.SharedInstance[key].StringValue;
            return await Task.FromResult(Newtonsoft.Json.JsonConvert.DeserializeObject<TInput>(settings));
        }
    }
}