using System.Collections.ObjectModel;
using Nokia.Music.Types;

namespace NewForFaves.Utils
{
    public class TestDataCreator
    {
        public static ObservableCollection<Artist> GetArtists()
        {
            return new ObservableCollection<Artist>
            {
                new Artist
                {
                    Id = "Liga",
                    Name = "Luciano Ligabue",
                    Country = "Italy"
                },
                new Artist
                {
                    Id = "Pausini",
                    Name = "Laura Pausini",
                    Country = "Italy"
                },
                new Artist
                {
                    Id = "Bruce",
                    Name = "Bruce Spreengsteen",
                    Country = "U.S.A."
                },
                new Artist
                {
                    Id = "Amy",
                    Name = "Amy Mc Donald",
                    Country = "Ireland"
                },
                new Artist
                {
                    Id = "Morgan",
                    Name = "Morgan dei Blu Vertigo",
                    Country = "Italy"
                },
            };
        }
    }
}
