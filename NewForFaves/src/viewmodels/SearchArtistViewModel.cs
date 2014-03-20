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
        public string ArtistName { get; set; }
        public RelayCommand SearchArtistCommand { get; private set; }

        public ObservableCollection<Artist> Artists { get; private set; } 

        public SearchArtistViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            ArtistName = string.Empty;
            Artists = new ObservableCollection<Artist>();
            SearchArtistCommand = new RelayCommand(SearchArtist, CanSearchArtist);
        }

        private bool CanSearchArtist()
        {
            return true;
        }

        private void SearchArtist()
        {
            //recupero da nokia api l'elenco degli artisti
            IEnumerable<Artist> artists = MixRadioApi.GetInstance().SearchArtists(ArtistName);

            //svuoto la lista di artisti precedentemente trovata
            Artists.Clear();
            foreach (Artist artist in artists)
            {
                Artists.Add(artist);
            }
        }
    }
}
