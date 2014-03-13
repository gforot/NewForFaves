using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NewForFaves.Utils;
using Nokia.Music;
using Nokia.Music.Types;

namespace NewForFaves.Model
{
    public class MusicClientAPI
    {
        private readonly MusicClient _musicClient;
        private readonly CountryResolver _countryResolver;

        private ListResponse<Product> _newReleases;

        #region Singleton Instance
        private static MusicClientAPI _instance;
        public static MusicClientAPI GetInstance()
        {
            return _instance ?? (_instance = new MusicClientAPI());
        }

        public static void ReleaseInstance()
        {
            _instance = null;
        }
        #endregion

        private MusicClientAPI()
        {
            if (Constants.IsNetworkAvailable)
            {
                _countryResolver = new CountryResolver(Constants.ClientId);
                _musicClient = new MusicClient(Constants.ClientId);
            }
        }

        public async Task<bool> Init()
        {
            _newReleases =  await _musicClient.GetNewReleasesAsync(Category.Album | Category.Single | Category.Track);
            return _newReleases.Succeeded;
        }

        public async Task<ListResponse<Artist>> GetTopArtistsAsync(int numberOfTopArtists)
        {
            return await _musicClient.GetTopArtistsAsync(0, numberOfTopArtists);
        }

        public async Task<ListResponse<Artist>> GetArtistsAsync()
        {
            return await _musicClient.SearchArtistsAsync("*");
        }

        public List<Product> GetNewReleasesByArtist(Artist artist)
        {
            List<Product> retValue = new List<Product>();
            foreach (Product pr in _newReleases)
            {
                foreach (Artist a in pr.Performers)
                {
                    if (a.Id == artist.Id)
                    {
                        retValue.Add(pr);
                    }
                }
            }
            return retValue;
        }

    }
}
