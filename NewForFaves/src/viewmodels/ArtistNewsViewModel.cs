using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using NewForFaves.Tiles;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class ArtistNewsViewModel : ViewModelCommon
    {
        public RelayCommand PlayMixCommand { get; private set; }

        public Artist SelectedArtist
        {
            get
            {
                return AppHelper.SelectedArtist;
            }
        }

        public ObservableCollection<ArtistNews> ArtistNewses { get; set; }


        public ArtistNewsViewModel()
        {
            PlayMixCommand = new RelayCommand(PlayMix);

            MessengerInstance.Register<Message>(this, OnMessageReceived);
            ArtistNewses = new ObservableCollection<ArtistNews>();
        }

        private void PlayMix()
        {
            int numberOfNews = ((ArtistNewses == null) || (ArtistNewses.Count == 0)) ? 0 : ArtistNewses[0].Products.Count;
            TilesManager.UpdateTiles(SelectedArtist, numberOfNews);

            //PlayMixTask launcher = new PlayMixTask();
            //launcher.ArtistName = SelectedArtist.Name;
            SelectedArtist.PlayMix();
        }

        private async void OnMessageReceived(Message message)
        {

            switch (message.Key)
            {
                case Message.InitNews:
                    ArtistNewses.Clear();

                    ArtistNews artistNews = new ArtistNews(SelectedArtist);

                    IEnumerable<Product> prs = await MixRadioApi.GetInstance().SearchNewsForArtist(SelectedArtist);
                    foreach (Product pr in prs)
                    {
                        artistNews.AddProduct(pr);
                    }
                    ArtistNewses.Add(artistNews);
                    break;
            }
        }

    }
}
