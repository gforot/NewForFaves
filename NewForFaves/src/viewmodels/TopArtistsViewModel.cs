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

        public ObservableCollection<Artist> Artists { get; private set; } 

        public RelayCommand SearchTopArtistsCommand { get; private set; }

        public TopArtistsViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            SearchTopArtistsCommand = new RelayCommand(SearchTopArtists, CanSearchTopArtists);
            Artists = new ObservableCollection<Artist>();
        }

        private bool CanSearchTopArtists()
        {
            return true;
        }

        private async void SearchTopArtists()
        {
            IEnumerable<Artist> topArtists = await MixRadioApi.GetInstance().SearchTopArtists(NumberOfTopArtistsToSearch);

            Artists.Clear();
            foreach (Artist artist in topArtists)
            {
                Artists.Add(artist);
            }
        }
    }
}
