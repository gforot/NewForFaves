using Cimbalino.Phone.Toolkit.Services;
using GalaSoft.MvvmLight.Command;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Viewmodels
{
    public class MainPageViewModel : ViewModelCommon
    {
        public RelayCommand SelectedPivotItemChangedCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            MessengerInstance.Register<Message>(this, OnMessageReceived);

            SelectedPivotItemChangedCommand = new RelayCommand(SelectedPivotItemChanged);
        }

        private void SelectedPivotItemChanged()
        {
            
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
