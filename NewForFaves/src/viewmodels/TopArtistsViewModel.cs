using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class TopArtistsViewModel : ViewModelCommon
    {
        #region NumberOfTopArtistsToSearch
        private const string _numberOfTopArtistsToSearchPrpName = "NumberOfTopArtistsToSearch";
        private int _numberOfTopArtistsToSearch = 5;
        public int NumberOfTopArtistsToSearch
        {
            get
            {
                return _numberOfTopArtistsToSearch;
            }
            set
            {
                _numberOfTopArtistsToSearch = value;
                RaisePropertyChanged(_numberOfTopArtistsToSearchPrpName);
            }
        }
        #endregion

        public ObservableCollection<ArtistNews> TopArtistsNews { get; private set; } 

        public RelayCommand SearchTopArtistsCommand { get; private set; }

        public TopArtistsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SearchTopArtistsCommand = new RelayCommand(SearchTopArtists, CanSearchTopArtists);
            TopArtistsNews = new ObservableCollection<ArtistNews>();
        }

        private bool CanSearchTopArtists()
        {
            return true;
        }

        private async void SearchTopArtists()
        {
            TopArtistsNews.Clear();
            IEnumerable<Artist> topArtists = await MixRadioApi.GetInstance().SearchTopArtists(NumberOfTopArtistsToSearch);

            foreach (Artist artist in topArtists)
            {
                ArtistNews artNews = new ArtistNews(artist);
                IEnumerable<Product> prds = await MixRadioApi.GetInstance().SearchNewsForArtist(artist);
                foreach (Product product in prds)
                {
                    artNews.AddProduct(product);
                }
                TopArtistsNews.Add(artNews);
            }
        }
    }
}
