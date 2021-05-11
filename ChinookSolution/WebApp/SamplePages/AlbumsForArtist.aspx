<%@ Page Title="Albums for Artist" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AlbumsForArtist.aspx.cs" Inherits="WebApp.SamplePages.AlbumsForArtist" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>
        Albums for Artist
    </h1>
    <div class="row">
        <div class="offset-2">
            
            <label style="font-size:x-large; font-weight:700">Select an Artist:&nbsp;</label>
            <asp:DropDownList ID="ArtistList" runat="server" 
                DataSourceID="ArtistListODS" 
                DataTextField="DisplayField" 
                DataValueField="ValueField"
                AppendDataBoundItem="true">
                <asp:ListItem Value="0">Select Artist...</asp:ListItem>
            </asp:DropDownList>&nbsp;&nbsp;
            <asp:LinkButton ID="FetchAlbums" runat="server">FetchAlbums</asp:LinkButton>
   
    <asp:GridView ID="AlbumsofArtistList" runat="server" AutoGenerateColumns="False">
        <Columns>
            <asp:TemplateField HeaderText="ID">
                <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("AlbumId") %>'></asp:Label>
                    </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Title">
                <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("Title") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Year">
                <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("ReleaserYear") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Label">
                <ItemTemplate>
                <asp:Label runat="server" Text='<%#Eval("ReleaseLabel") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
         <EmptyDataTemplate>
                Artist has no albums on file
            </EmptyDataTemplate>
    </asp:GridView>
    <br />
    <br /><br />
            <asp:ObjectDataSource ID="ArtistListODS" runat="server" 
                OldValuesParameterFormatString="original_{0}" 
                SelectMethod="Artists_List" 
                TypeName="ChinookSystem.BLL.ArtistController"></asp:ObjectDataSource>
                 </div>
    </div>
</asp:Content>
