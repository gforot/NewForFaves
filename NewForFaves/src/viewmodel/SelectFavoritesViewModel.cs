using System.Collections.ObjectModel;
using NewForFaves.Utils;
using Nokia.Music.Types;

namespace NewForFaves.Viewmodel
{
    public class SelectFavoritesViewModel : ViewModelCommon
    {
        public ObservableCollection<Artist> Artists { get; private set; }

        public SelectFavoritesViewModel()
        {
            Artists = TestDataCreator.GetArtists();
        }
    }
}
