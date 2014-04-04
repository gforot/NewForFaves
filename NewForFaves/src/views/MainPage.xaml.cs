using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Phone.Controls;
using NewForFaves.Model;
using NewForFaves.Tiles;
using NewForFaves.Utils;
using Nokia.Music.Types;


namespace NewForFaves.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            if (AppAttributes.IsFirstUsageOfApp)
            {
                TilesManager.UpdateTiles();
            }
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

        private void Pivot_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if ((e.AddedItems == null) || (e.AddedItems.Count == 0))
            {
                return;
            }
            if (e.AddedItems[0] is PivotItem)
            {
                bool isApplicationBarVisible = true;
                if ((e.AddedItems[0] as PivotItem).Name.Equals("topArtists"))
                {
                    isApplicationBarVisible = false;
                }
                SetApplicationBarVisibility(isApplicationBarVisible);
            }
        }

        private void SetApplicationBarVisibility(bool isVisible)
        {
            if (this.ApplicationBar != null)
            {
                this.ApplicationBar.IsVisible = isVisible;
            }
        }
    }
}