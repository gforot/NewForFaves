﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using Nokia.Music.Tasks;
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

        public ObservableCollection<ArtistNews> ArtistNewsList { get; set; }

        public ObservableCollection<Product> NewsList { get; set; }


        public ArtistNewsViewModel()
        {
            PlayMixCommand = new RelayCommand(PlayMix);

            MessengerInstance.Register<Message>(this, OnMessageReceived);
            NewsList = new ObservableCollection<Product>();
        }

        private void PlayMix()
        {
            //PlayMixTask launcher = new PlayMixTask();
            //launcher.ArtistName = SelectedArtist.Name;
            SelectedArtist.PlayMix();
        }

        private async void OnMessageReceived(Message message)
        {
            switch (message.Key)
            {
                case Message.InitNews:
                    NewsList.Clear();
                    IEnumerable<Product> prs = await MixRadioApi.GetInstance().SearchNewsForArtist(SelectedArtist);
                    foreach (Product pr in prs)
                    {
                        NewsList.Add(pr);
                    }
                    break;
            }
        }

    }
}
