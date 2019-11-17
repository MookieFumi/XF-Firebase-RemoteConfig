using Acr.UserDialogs;
using MyRemoteConfiguration.Views;
using Prism;
using Prism.Ioc;
using Prism.Plugin.Popups;
using Prism.Unity;
using Xamarin.Forms;

namespace MyRemoteConfiguration
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer) : base(initializer)
        {
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterInstance(UserDialogs.Instance);
            containerRegistry.RegisterPopupNavigationService();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<PlayersPage, PlayersViewModel>();
            containerRegistry.RegisterForNavigation<PlayerPopupPage, PlayerPopupPageViewModel>();
        }

        protected override void OnInitialized()
        {
            InitializeComponent();

            NavigationService.NavigateAsync($"NavigationPage/{nameof(PlayersPage)}");
        }
    }
}
