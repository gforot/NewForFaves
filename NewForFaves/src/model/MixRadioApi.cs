using System.Collections.Generic;
using System.Threading.Tasks;
using NewForFaves.Utils;
using Nokia.Music;
using Nokia.Music.Types;

namespace NewForFaves.Model
{
    public class MixRadioApi
    {
        private readonly MusicClient _musicClient;

        #region Singleton Instance
        private static readonly object _lockObj = new object();
        private static MixRadioApi _instance;

        public static MixRadioApi GetInstance()
        {
            lock (_lockObj)
            {
                return _instance ?? (_instance = new MixRadioApi());
            }
        }

        public static void ReleaseInstance()
        {
            _instance = null;
        }
        #endregion

        #region Constructor

        private MixRadioApi()
        {
            if (!Constants.Test)
            {
                _musicClient = new MusicClient(Constants.ClientId);
            }
        }

        #endregion

        public async Task<IEnumerable<Artist>> SearchArtists(string searchTerm)
        {
            if (Constants.Test)
            {
                return new List<Artist>
                       {
                           new Artist
                           {
                               Id = "1",
                               Name = "Luciano Ligabue"
                           },
                           new Artist
                           {
                               Id = "2",
                               Name = "Laura Pausini"
                           },
                           new Artist
                           {
                               Id = "3",
                               Name = "Neffa"
                           }
                       };
            }
            else
            {
                return await _musicClient.SearchArtistsAsync(searchTerm, 0, 100);
            }
        }

        public async Task<IEnumerable<Artist>> SearchTopArtists(int number)
        {
            if (Constants.Test)
            {
                return new List<Artist>
                   {
                       new Artist
                       {
                           Id = "1",
                           Name="Luciano Ligabue"
                       },
                       new Artist
                       {
                           Id = "2",
                           Name="Laura Pausini"
                       },
                       new Artist
                       {
                           Id = "3",
                           Name="Neffa"
                       }
                   };
            }
            return await _musicClient.GetTopArtistsAsync(0, number);
        }

        internal async Task<IEnumerable<Product>> SearchNewsForArtist(Artist artist)
        {
            if (Constants.Test)
            {
                return new List<Product>
                   {
                       new Product
                       {
                           Id = "1",
                           Name="Piccola stella senza cielo",
                           Category = Category.Track,
                       },
                       new Product
                       {
                           Id = "2",
                           Name="Laura non c'è",
                           Category = Category.Track,
                       },
                       new Product
                       {
                           Id = "3",
                           Name="Black Album",
                           Category = Category.Album,
                       },
                   };
            }
            ListResponse<Product> newTracks = await _musicClient.GetNewReleasesAsync(Category.Track, 0, 500);
            ListResponse<Product> newAlbums = await _musicClient.GetNewReleasesAsync(Category.Album, 0, 500);

            List<Product> products = new List<Product>();

            foreach (Product p in newTracks)
            {
                if (IsProductOfArtist(p, artist))
                {
                    products.Add(p);
                }
            }
            foreach (Product p in newAlbums)
            {
                if (IsProductOfArtist(p, artist))
                {
                    products.Add(p);
                }
            }
            return products;
        }

        private static bool IsProductOfArtist(Product p, Artist a)
        {
            if ((a == null) || (p == null))
            {
                return false;
            }

            foreach (Artist performer in p.Performers)
            {
                if (performer.Id.Equals(a.Id))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
