using Acr.UserDialogs;
using MyRemoteConfiguration.Base;
using MyRemoteConfiguration.Model;
using Prism.Navigation;

namespace MyRemoteConfiguration
{
    public class PlayerPopupPageViewModel : ViewModelBase
    {
        private string _name;
        private string _description;
        private string _position;
        private string _image;
        private string _nationality;
        private string _height;
        private string _weight;
        private string _born;
        private int _gamesPlayed;
        private int _minutesPlayed;
        private int _starts;
        private int _subOff;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public string Position
        {
            get => _position;
            set => SetProperty(ref _position, value);
        }

        public string Image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }

        public string Nationality
        {
            get => _nationality;
            set => SetProperty(ref _nationality, value);
        }

        public string Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }

        public string Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public string Born
        {
            get => _born;
            set => SetProperty(ref _born, value);
        }

        public int GamesPlayed
        {
            get => _gamesPlayed;
            set => SetProperty(ref _gamesPlayed, value);
        }

        public int MinutesPlayed
        {
            get => _minutesPlayed;
            set => SetProperty(ref _minutesPlayed, value);
        }

        public int Starts
        {
            get => _starts;
            set => SetProperty(ref _starts, value);
        }

        public int SubOff
        {
            get => _subOff;
            set => SetProperty(ref _subOff, value);
        }

        public PlayerPopupPageViewModel(INavigationService navigationService, IUserDialogs userDialogs) : base(navigationService, userDialogs)
        {
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var @param = parameters.GetValue<Player>("player");
            Name = param.Name;
            Description = param.Description;
            Position = param.Position;
            Image = param.Image;
            Nationality = param.Nationality;
            Height = param.Height;
            Weight = param.Weight;
            Born = param.Born;
            GamesPlayed = param.GamesPlayed;
            MinutesPlayed = param.MinutesPlayed;
            Starts = param.Starts;
            SubOff = param.SubOff;

            base.OnNavigatedTo(parameters);
        }
    }
}
