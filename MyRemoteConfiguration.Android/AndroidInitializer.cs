using MyRemoteConfiguration.Droid.Services;
using MyRemoteConfiguration.Services;
using Prism;
using Prism.Ioc;

namespace MyRemoteConfiguration.Droid
{
    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRemoteConfigurationService, MyRemoteConfigurationService>();
        }
    }
}