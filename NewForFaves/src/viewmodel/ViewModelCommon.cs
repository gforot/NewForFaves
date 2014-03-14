using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight;
using NewForFaves.Utils;

namespace NewForFaves.Viewmodel
{
    public class ViewModelCommon : ViewModelBase
    {
        protected INavigationService NavigationService;

        public ViewModelCommon(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
        }

        protected void NavigateToFavorites()
        {
            NavigationService.NavigateTo(Addresses.SelectFavoritesPageAddress);
        }
    }
}
