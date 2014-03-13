using System.Collections.ObjectModel;
using NewForFaves.Utils;
using Nokia.Music.Types;
namespace NewForFaves.Viewmodel
{
    public class MainPageViewModel : ViewModelCommon
    {
        public ObservableCollection<Artist> TopArtists { get; private set; }
        public ObservableCollection<Artist> FavoritesArtists { get; private set; }

        public MainPageViewModel()
        {
            TopArtists = TestDataCreator.GetArtists();
            FavoritesArtists = TestDataCreator.GetArtists();
        }

    }
}
