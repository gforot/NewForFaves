using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using NewForFaves.Model.Messages;
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
        public ListResponse<Artist> Artists { get; private set; }
        public ListResponse<Artist> TopArtists { get; private set; } 

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
            _newReleases =  await _musicClient.GetNewReleasesAsync(Category.Track);
            Artists = await GetArtistsAsync();
            TopArtists = await GetTopArtistsAsync(100);

            Messenger.Default.Send(new Message(Message.InitMainViewModel));

            return _newReleases.Succeeded;
        }

        public async Task<ListResponse<Artist>> GetTopArtistsAsync(int numberOfTopArtists)
        {
            return await _musicClient.GetTopArtistsAsync(0, numberOfTopArtists);
        }

        public async Task<ListResponse<Artist>> GetArtistsAsync()
        {
            ListResponse<Artist> artists = await _musicClient.SearchArtistsAsync("luciano");
            return artists;
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
