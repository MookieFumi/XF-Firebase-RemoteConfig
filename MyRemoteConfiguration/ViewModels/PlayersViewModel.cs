using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using MyRemoteConfiguration.Base;
using MyRemoteConfiguration.Model;
using MyRemoteConfiguration.Services;
using MyRemoteConfiguration.Views;
using Prism.Navigation;
using Xamarin.Forms;

namespace MyRemoteConfiguration
{
    public class PlayersViewModel : ViewModelBase
    {
        private bool _showPlayerDetail;
        private ObservableCollection<Player> _players;
        private Player _selectedPlayer;
        private readonly IRemoteConfigurationService _remoteConfigurationService;

        public PlayersViewModel(INavigationService navigationService, IUserDialogs userDialogs, IRemoteConfigurationService remoteConfigurationService) : base(navigationService, userDialogs)
        {
            _remoteConfigurationService = remoteConfigurationService;

            Title = "Match info";
            RefreshCommand = new Command(async () => await Refresh());
            NavigateToPlayerCommand = new Command(async () => await NavigateToPlayer());
        }

        private async Task NavigateToPlayer()
        {
            if (!ShowPlayerDetail)
            {
                return;
            }

            var @params = new NavigationParameters
            {
                { "player", SelectedPlayer }
            };
            await NavigationService.NavigateAsync($"{nameof(PlayerPopupPage)}", @params);
        }

        public ObservableCollection<Player> Players
        {
            get => _players;
            set => SetProperty(ref _players, value);
        }

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set => SetProperty(ref _selectedPlayer, value);
        }

        public bool ShowPlayerDetail
        {
            get => _showPlayerDetail;
            set => SetProperty(ref _showPlayerDetail, value);
        }

        private async Task Refresh()
        {
            IsBusy = true;

            await _remoteConfigurationService.FetchAndActivateAsync();

            await UpdateFromRemoteConfiguration();

            IsBusy = false;
        }

        private async Task UpdateFromRemoteConfiguration()
        {
            var configuration = await _remoteConfigurationService.GetAsync<FeatureConfiguration>("Features");
            ShowPlayerDetail = configuration.ShowPlayerDetail;
        }

        public ICommand RefreshCommand { get; }
        public ICommand NavigateToPlayerCommand { get; }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            await Refresh();

            base.OnNavigatedTo(parameters);
        }

        public override async Task InitializeAsync(INavigationParameters parameters)
        {
            Players = new ObservableCollection<Player>
            {
                new Player
                {
                    Name = "Oblak",
                    Position ="Goalkeeper",
                    Description="Fast, reliable and safe in the air game.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8214/destacado_920x920/BUSTOS_OBLAK.png?1565972286",
                    Nationality="Slovenian",
                    Height = "188",
                    Weight ="87",
                    Born = "07/01/1993",
                    GamesPlayed=13,
                    MinutesPlayed=1146,
                    Starts=13,
                    SubOff=1
                },
                new Player
                {
                    Name = "Lodi",
                    Position= "Defender",
                    Description="Versatile and fast full-back with capacity to run down the wing. Strong shooting skills",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/9286/destacado_920x920/BUSTOS_LODI.png?1565973129",
                    Nationality="Brazilian",
                    Height = "173",
                    Weight ="68",
                    Born = "08/04/1998",
                    GamesPlayed=11,
                    MinutesPlayed=847,
                    Starts=10,
                    SubOff=2
                },
                new Player
                {
                    Name = "Gimenez",
                    Position= "Defender",
                    Description="Aggressive, committed and fast over short distances. Despite his youth, he's a powerfully physical player destined to be a great centre back.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8215/destacado_920x920/BUSTOS_GIMENEZ.png?1565972334",
                    Nationality="Uruguayan",
                    Height = "185",
                    Weight ="80",
                    Born = "20/01/1995",
                    GamesPlayed=8,
                    MinutesPlayed=720,
                    Starts=8,
                    SubOff=0
                },
                new Player
                {
                    Name = "Felipe",
                    Position= "Defender",
                    Description="Fast defender with good passing skills. Very strong in the air, making him a threat on both sides of the pitch",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/9284/destacado_920x920/BUSTOS_FELIPE.png?1565973062",
                    Nationality="Brazilian",
                    Height = "190",
                    Weight ="83",
                    Born = "16/05/1989",
                    GamesPlayed=8,
                    MinutesPlayed=631,
                    Starts=7,
                    SubOff=0
                },
                new Player
                {
                    Name = "Trippier",
                    Position= "Defender",
                    Description = "Offensive and versatile full-back who con play in midfield and has a fantastic right foot",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/9290/destacado_920x920/BUSTOS_TRIPPIER.png?1565973188",
                    Nationality = "English",
                    Height = "173",
                    Weight = "71",
                    Born = "19/09/1990",
                    GamesPlayed = 10,
                    MinutesPlayed = 855,
                    Starts = 10,
                    SubOff = 1
                },
                new Player
                {
                    Name = "Thomas",
                    Position = "Midfielder",
                    Description="Physical midfielder with a good touch of the ball. He joins the attack with ease.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8224/destacado_920x920/BUSTOS_THOMAS.png?1565972593",
                    Nationality="Ghanaian",
                    Height = "185",
                    Weight ="77",
                    Born = "13/06/1993",
                    GamesPlayed=12,
                    MinutesPlayed=807,
                    Starts=9,
                    SubOff=3
                },
                new Player
                {
                    Name = "Koke",
                    Position = "Midfielder",
                    Description="Koke has earned a place in the first team with hard work and talent. He has a great final pass and is no longer seen as someone with a promising future, but a benchmark of the farm team as an emblem of the team.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8212/destacado_920x920/BUSTOS_KOKE.png?1565972254",
                    Nationality="Spaniard",
                    Height = "176",
                    Weight ="74",
                    Born = "08/01/1992",
                    GamesPlayed=13,
                    MinutesPlayed=1075,
                    Starts=12,
                    SubOff=1
                },
                new Player
                {
                    Name = "Vitolo",
                    Position = "Midfielder",
                    Description="A winger who likes to dribble, assist and score goals. His hard work to help defend makes him a team player.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8232/destacado_920x920/BUSTOS_VITOLO.png?1565972653",
                    Nationality="Spaniard",
                    Height = "185",
                    Weight ="79",
                    Born = "02/01/1989",
                    GamesPlayed=9,
                    MinutesPlayed=402,
                    Starts=4,
                    SubOff=3
                },
                new Player
                {
                    Name = "Saul",
                    Position = "Midfielder",
                    Description = "Very energetic midfielder capable of clearing the ball in his area and finish shooting at the opponents' box. Versatility, effort and breed define this home-grown player.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8218/destacado_920x920/BUSTOS_SAUL.png?1565972378",
                    Nationality="Spaniard",
                    Height = "186",
                    Weight ="77",
                    Born = "21/11/1994",
                    GamesPlayed=13,
                    MinutesPlayed=1170,
                    Starts=13,
                    SubOff=0
                },
                new Player
                {
                    Name = "Joao Felix",
                    Position = "Forward",
                    Description = "Versatile striker who can play in every attacking position. Skilful, good dribbler and strong on the ball. A young player with outstanding potential.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/9285/destacado_920x920/BUSTOS_JOAO.png?1565973096",
                    Nationality="Portuguese",
                    Height = "181",
                    Weight ="70",
                    Born = "10/11/1999",
                    GamesPlayed=9,
                    MinutesPlayed=660,
                    Starts=9,
                    SubOff=7
                },
                new Player
                {
                    Name = "Morata",
                    Position = "Forward",
                    Description="Proven goalscorer in the world's most competitive leagues.",
                    Image = "https://img-estaticos.atleticodemadrid.com/system/fotos/8240/destacado_920x920/BUSTOS_MORATA.png?1565972794",
                    Nationality="Spaniard",
                    Height = "189",
                    Weight ="84",
                    Born = "23/10/1992",
                    GamesPlayed=10,
                    MinutesPlayed=616,
                    Starts=7,
                    SubOff=4
                }
            };

            await base.InitializeAsync(parameters);
        }
    }
}
