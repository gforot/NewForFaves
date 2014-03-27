using System;
using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class ViewModelCommon : ViewModelBase
    {
        private readonly INavigationService _navigationService;

        public RelayCommand AboutCommand { get; private set; }

        public ViewModelCommon(INavigationService navigationService)
            : this()
        {
            _navigationService = navigationService;
        }

        protected ViewModelCommon()
        {
            AboutCommand = new RelayCommand(About);
        }

        private void About()
        {
            NavigateToAboutPage();
        }

        private void NavigateToAboutPage()
        {
            NavigateToPage(Addresses.AboutPageAddress);
        }

        protected void NavigateToArtistNewsPage(Artist artist)
        {
            AppHelper.SelectedArtist = artist;
            NavigateToPage(Addresses.ArtistNewsAddress);
        }

        private void NavigateToPage(string relativeUri)
        {
            if (_navigationService != null)
            {
                _navigationService.NavigateTo(new Uri(relativeUri, UriKind.Relative));
            }
        }
    }
}
