using System.Threading.Tasks;
using Firebase.RemoteConfig;
using MyRemoteConfiguration.Services;

namespace MyRemoteConfiguration.Droid.Services
{
    public class MyRemoteConfigurationService : IRemoteConfigurationService
    {
        public MyRemoteConfigurationService()
        {
            FirebaseRemoteConfigSettings configSettings = new FirebaseRemoteConfigSettings.Builder()
                .SetDeveloperModeEnabled(true)
                .Build();
            FirebaseRemoteConfig.Instance.SetConfigSettings(configSettings);
            FirebaseRemoteConfig.Instance.SetDefaults(Resource.Xml.RemoteConfigDefaults);
        }

        public async Task FetchAndActivateAsync()
        {
            await FirebaseRemoteConfig.Instance.FetchAsync(0);
            FirebaseRemoteConfig.Instance.ActivateFetched();
        }

        public async Task<TInput> GetAsync<TInput>(string key)
        {
            var settings = FirebaseRemoteConfig.Instance.GetString(key);
            return await Task.FromResult(Newtonsoft.Json.JsonConvert.DeserializeObject<TInput>(settings));
        }
    }
}