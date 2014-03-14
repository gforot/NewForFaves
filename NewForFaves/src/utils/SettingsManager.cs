using System.Collections.Generic;
using System.IO.IsolatedStorage;

namespace NewForFaves.Utils
{
    public class SettingsManager
    {
        private const string _settingKeyFavoritesArtistsId = "favoritesArtistsId";
        
        public static IEnumerable<int> ReadFavoritesArtistsIds()
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(_settingKeyFavoritesArtistsId))
            {
                return (IEnumerable<int>)settings[_settingKeyFavoritesArtistsId];
            }
            //se non sono stati ancora salvati dei favoriti carico il default
            return new int[] {};
        }

        public static void WriteFavoritesArtistsIds(IEnumerable<int> ids)
        {
            IsolatedStorageSettings settings = IsolatedStorageSettings.ApplicationSettings;
            if (settings.Contains(_settingKeyFavoritesArtistsId))
            {
                settings[_settingKeyFavoritesArtistsId] = ids;
            }
            else
            {
                settings.Add(_settingKeyFavoritesArtistsId, ids);
            }
        }
    }
}
