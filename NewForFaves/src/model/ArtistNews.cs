﻿using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Nokia.Music.Types;


namespace NewForFaves.Model
{
    public class ArtistNews : ViewModelBase
    {
        public Artist Artist { get; private set; }
        public ObservableCollection<Product> Products { get; set; }

        public RelayCommand PlayMixCommand { get; private set; }

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

            PlayMixCommand = new RelayCommand(PlayMix);
        }

        public void AddProduct(Product p)
        {
            Products.Add(p);
        }

        public void ClearProducts()
        {
            Products.Clear();
        }

        private void PlayMix()
        {
            Artist.PlayMix();
        }

        public override string ToString()
        {
            return ArtistName;
        }
    }
}