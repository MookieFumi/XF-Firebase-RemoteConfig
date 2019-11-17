using MyRemoteConfiguration.iOS.Services;
using MyRemoteConfiguration.Services;
using Prism;
using Prism.Ioc;

namespace MyRemoteConfiguration.iOS
{
    public class IosInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IRemoteConfigurationService, MyRemoteConfigurationService>();
        }
    }
}
