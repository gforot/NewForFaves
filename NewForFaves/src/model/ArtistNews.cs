using System;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Tiles;
using Nokia.Music.Types;


namespace NewForFaves.Model
{
    public class ArtistNews : ViewModelBase
    {
        public Artist Artist { get; private set; }
        public ObservableCollection<Product> Products { get; set; }

        public RelayCommand PlayMixCommand { get; private set; }

        public string ArtistName
        {
            get
            {
                return Artist.Name;
            }
        }

        public Uri Image
        {
            get
            {
                return Artist.Thumb100Uri;
            }
        }

        public ArtistNews(Artist artist)
        {
            Artist = artist;
            Products = new ObservableCollection<Product>();

            PlayMixCommand = new RelayCommand(PlayMix);
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void ClearProducts()
        {
            Products.Clear();
        }

        private void PlayMix()
        {
            int numberOfNews = Products == null ? 0 : Products.Count;
            TilesManager.UpdateTiles(Artist, numberOfNews);

            Artist.PlayMix();
        }

        public override string ToString()
        {
            return ArtistName;
        }
    }
}
