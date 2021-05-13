using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional namespaces
using ChinookSystem.BLL;
using ChinookSystem.ViewModels;
#endregion

namespace WebApp.SamplePages
{
    public partial class AlbumsForArtist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SelectCheckForException(object sender, ObjectDataSourceStatusEventArgs e)
        {
            MessageUserControl.HandleDataBoundException(e);
        }

        protected void FetchAlbums_Click(object sender, EventArgs e)
        {if(ArtistList.SelectedIndex == 0)
            {
                MessageUserControl.ShowInfo("Artist Selection", "No Artist has been Selected");
            }
            else
            {
                RefreshList();
            }

            


        }

        protected void AlbumsofArtistList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlbumsofArtistList.PageIndex = e.NewPageIndex;
            RefreshList();
        }

        protected void RefreshList()
        {
            //error handling for class library calls
            MessageUserControl.TryRun(() =>
            {
                AlbumController sysmgr = new AlbumController();
                List<AlbumItem> info = sysmgr.Albums_GetByArtist(int.Parse(ArtistList.SelectedValue));
                AlbumsofArtistList.DataSource = info;
                AlbumsofArtistList.DataBind();
            },"Artist Albums List","View artist albums");
            
        }

        protected void ArtistListODS_Selected(object sender, ObjectDataSourceStatusEventArgs e)
        {

        }
    }
}