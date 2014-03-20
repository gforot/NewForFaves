using System.Collections.Generic;
using Nokia.Music.Types;


namespace NewForFaves.Model
{
    public class MixRadioApi
    {
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

        public IEnumerable<Artist> SearchArtists(string artistName)
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
    }
}
