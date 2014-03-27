using System.Collections.ObjectModel;
using Nokia.Music.Types;


namespace NewForFaves.Model
{
    public class ArtistNews
    {
        public Artist Artist { get; private set; }
        public ObservableCollection<Product> Products { get; private set; }

        public string ArtistName
        {
            get
            {
                return Artist.Name;
            }
        }

        public ArtistNews(Artist artist)
        {
            this.Artist = artist;
            Products = new ObservableCollection<Product>();
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void ClearProducts()
        {
            Products.Clear();
        }

    }
}
