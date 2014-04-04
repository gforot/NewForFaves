using System;
using System.Linq;
using Microsoft.Phone.Shell;
using NewForFaves.Resources;
using Nokia.Music.Types;


namespace NewForFaves.Tiles
{
    class TilesManager
    {
        public static void UpdateTiles()
        {
            ShellTile oTile = ShellTile.ActiveTiles.First();
            FlipTileData oFliptile = new FlipTileData();

            #region Front
            oFliptile.Title = AppResources.ApplicationTitle;
            oFliptile.SmallBackgroundImage = new Uri("Assets/Tiles/star_yellow_159x159.png", UriKind.Relative);
            oFliptile.BackgroundImage = new Uri("Assets/Tiles/star_yellow_336x336.png", UriKind.Relative);
            oFliptile.WideBackgroundImage = new Uri("Assets/Tiles/star_yellow_691x336.png", UriKind.Relative);
            #endregion

            #region Back
            oFliptile.BackBackgroundImage = new Uri("/Assets/Tiles/star_yellow_336x336.png", UriKind.Relative);
            oFliptile.WideBackBackgroundImage = new Uri("/Assets/Tiles/star_yellow_691x336.png", UriKind.Relative);

            oFliptile.BackTitle = AppResources.ApplicationTitle;

            oFliptile.BackContent = AppResources.BackTileMessage;
            oFliptile.WideBackContent = AppResources.BackTileWideMessage;
            #endregion

            oTile.Update(oFliptile);
        }

        public static void UpdateTiles(Artist artist, int numberOfNews)
        {
            ShellTile oTile = ShellTile.ActiveTiles.First();
            FlipTileData oFliptile = new FlipTileData();

            #region Front
            oFliptile.Title = AppResources.ApplicationTitle;
            oFliptile.SmallBackgroundImage = new Uri("Assets/Tiles/star_yellow_159x159.png", UriKind.Relative);
            oFliptile.BackgroundImage = new Uri("Assets/Tiles/star_yellow_336x336.png", UriKind.Relative);
            oFliptile.WideBackgroundImage = new Uri("Assets/Tiles/star_yellow_691x336.png", UriKind.Relative);
            #endregion

            #region Back
            oFliptile.BackBackgroundImage = new Uri("/Assets/Tiles/star_yellow_336x336.png", UriKind.Relative);
            oFliptile.WideBackBackgroundImage = new Uri("/Assets/Tiles/star_yellowo_691x336.png", UriKind.Relative);

            oFliptile.BackTitle = artist.Name;

            oFliptile.BackContent = string.Format(AppResources.BackTileWideMessageFormat, numberOfNews);
            #endregion


            oTile.Update(oFliptile);
        }
    }
}
