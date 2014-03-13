using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace NewForFaves.Viewmodel
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            if (!SimpleIoc.Default.IsRegistered<IMarketplaceReviewService>())
            {
                SimpleIoc.Default.Register<IMarketplaceReviewService, MarketplaceReviewService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IApplicationManifestService>())
            {
                SimpleIoc.Default.Register<IApplicationManifestService, ApplicationManifestService>();
            }

            if (!SimpleIoc.Default.IsRegistered<IEmailComposeService>())
            {
                SimpleIoc.Default.Register<IEmailComposeService, EmailComposeService>();
            }

            if (!SimpleIoc.Default.IsRegistered<INavigationService>())
            {
                SimpleIoc.Default.Register<INavigationService, NavigationService>();
            }

            SimpleIoc.Default.Register<MainPageViewModel>();
            SimpleIoc.Default.Register<AboutPageViewModel>();
            SimpleIoc.Default.Register<SelectFavoritesViewModel>();
        }

        public AboutPageViewModel AboutPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<AboutPageViewModel>();
            }
        }

        public MainPageViewModel MainPageViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MainPageViewModel>();
            }
        }

        public SelectFavoritesViewModel SelectFavoritesViewModel
        {
            get
            {
                return ServiceLocator.Current.GetInstance<SelectFavoritesViewModel>();
            }
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
