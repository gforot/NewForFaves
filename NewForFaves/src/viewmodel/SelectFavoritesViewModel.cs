using System.Collections.ObjectModel;
using Cimbalino.Phone.Toolkit.Extensions;
using Cimbalino.Phone.Toolkit.Services;
using NewForFaves.Model;
using NewForFaves.Utils;
using Nokia.Music.Types;

namespace NewForFaves.Viewmodel
{
    public class SelectFavoritesViewModel : ViewModelCommon
    {
        public ObservableCollection<Artist> Artists { get; private set; }

        public SelectFavoritesViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            if (IsInDesignMode)
            {
                Artists = TestDataCreator.GetArtists();
            }
            else
            {
                Artists = MusicClientAPI.GetInstance().Artists.ToObservableCollection();
            }
        }
    }
}
