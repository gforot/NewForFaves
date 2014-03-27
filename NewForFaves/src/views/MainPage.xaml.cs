using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using NewForFaves.Model;
using Nokia.Music.Types;


namespace NewForFaves.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void ListBox_DoubleTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            if (e.OriginalSource is TextBlock)
            {
                object dataContext = (e.OriginalSource as TextBlock).DataContext;
                if (dataContext is Artist)
                {
                    Messenger.Default.Send(new Message(Message.ArtistSelected, dataContext as Artist));
                }
            }

            
        }
    }
}