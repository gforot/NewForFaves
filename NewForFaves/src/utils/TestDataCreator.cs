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
                },
                new Artist
                {
                    Id = "Pausini",
                    Name = "Laura Pausini",
                },
                new Artist
                {
                    Id = "Dalla",
                    Name = "Lucio Dalla",
                },
                new Artist
                {
                    Id = "Amoroso",
                    Name = "Alessandra Amoroso",
                },
                new Artist
                {
                    Id = "Morgan",
                    Name = "Morgan dei Blu Vertigo",
                },
            };
        }
    }
}
