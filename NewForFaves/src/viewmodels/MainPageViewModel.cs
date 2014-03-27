using Cimbalino.Phone.Toolkit.Services;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class MainPageViewModel : ViewModelCommon
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            MessengerInstance.Register<Message>(this, OnMessageReceived);            
        }

        private void OnMessageReceived(Message m)
        {
            switch (m.Key)
            {
                case Message.ArtistSelected:
                    NavigateToArtistNewsPage(m.AdditionalInfo as Artist);
                    break;
            }
        }
    }
}
