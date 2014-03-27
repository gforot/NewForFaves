using System.Collections.Generic;
using System.Collections.ObjectModel;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class SearchArtistViewModel : ViewModelCommon
    {
        private const string _artistNamePrpName = "ArtistName";
        private string _artistName;
        public string ArtistName { get
        {
            return _artistName;
        }
            set
            {
                _artistName = value;
                RaisePropertyChanged(_artistNamePrpName);
                SearchArtistCommand.RaiseCanExecuteChanged();
            } 
        }
        public RelayCommand SearchArtistCommand { get; private set; }

        public ObservableCollection<Artist> Artists { get; private set; } 

        public SearchArtistViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SearchArtistCommand = new RelayCommand(SearchArtist, CanSearchArtist);
            _artistName = string.Empty;
            Artists = new ObservableCollection<Artist>();
        }

        private bool CanSearchArtist()
        {
            return !string.IsNullOrEmpty(ArtistName);
        }

        private async void SearchArtist()
        {
            //recupero da nokia api l'elenco degli artisti
            IEnumerable<Artist> artists = await MixRadioApi.GetInstance().SearchArtists(ArtistName);

            //svuoto la lista di artisti precedentemente trovata
            Artists.Clear();
            foreach (Artist artist in artists)
            {
                Artists.Add(artist);
            }
        }
    }
}
