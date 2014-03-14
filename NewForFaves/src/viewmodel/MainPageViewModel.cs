using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Cimbalino.Phone.Toolkit.Services;
using Cimbalino.Phone.Toolkit.Extensions;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Reactive;
using NewForFaves.Model;
using NewForFaves.Model.Messages;
using NewForFaves.Utils;
using Nokia.Music.Types;

namespace NewForFaves.Viewmodel
{
    public class MainPageViewModel : ViewModelCommon
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            //creazione command
            SelectFavoritesCommand = new RelayCommand(NavigateToFavorites);

            
        }

        private void Init()
        {
            TopArtists = MusicClientAPI.GetInstance().TopArtists.ToObservableCollection();
            FavoritesArtists = TestDataCreator.GetArtists();
        }

        private void OnMessageReceived(Message message)
        {
            switch (message.Key)
            {
                case Message.InitMainViewModel:
                    Init();
                    break;
            }
        }

        public RelayCommand SelectFavoritesCommand { get; private set; }

        public ObservableCollection<Artist> TopArtists { get; private set; }
        public ObservableCollection<Artist> FavoritesArtists { get; private set; }
    }
}