using System.Threading.Tasks;
using Acr.UserDialogs;
using Prism.Mvvm;
using Prism.Navigation;

namespace MyRemoteConfiguration.Base
{
    public class ViewModelBase : BindableBase, IInitializeAsync, INavigatedAware
    {
        private string _title;
        private bool _isBusy;

        protected INavigationService NavigationService { get; }
        protected IUserDialogs DialogsService { get; }

        public ViewModelBase(INavigationService navigationService, IUserDialogs userDialogs)
        {
            NavigationService = navigationService;
            DialogsService = userDialogs;
        }

        public virtual async Task InitializeAsync(INavigationParameters parameters)
        {
            await Task.Delay(0);
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
    }
}
