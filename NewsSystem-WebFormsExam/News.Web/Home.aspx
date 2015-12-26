<%@ Page Language="C#" 
    Title="News" 
    AutoEventWireup="true" 
    CodeBehind="Home.aspx.cs"
     Inherits="News.Web.Home" 
     MasterPageFile="~/Site.Master"%>

<asp:Content ContentPlaceHolderID="MainContent" ID="HomePageContent" runat="server">
    <title><%= Title %></title>
    
    <h1>Most popular articles</h1>
    <asp:ListView ID="ListViewPopularArticles" runat="server" ItemType="News.Models.Article" SelectMethod="ListViewPopularArticles_GetData">
        <ItemTemplate>
            <div class="row">
                <h3>
                    <asp:HyperLink runat="server" 
                        NavigateUrl='<%# String.Format("~/ArticleDetails.aspx?id={0}", Item.Id) %>'
                        Text="<%# Item.Title %>">                       
                    </asp:HyperLink>
                    <small><%# Item.Category.Name %></small>
                </h3>
                <p>
                    <%#: Item.Content %>
                </p>
                <p>Likes: <%# Item.Likes.Value %></p>
                <div>
                    <i>by <%# Item.Author.UserName %></i>
                    <i>created on: <%#: Item.DateCreated.ToString("MM/dd/yyyy hh:mm:ss tt",System.Globalization.CultureInfo.InvariantCulture) %></i>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
    
    <h2>All Categories</h2>
    <asp:ListView ID="ListViewCategories"
         runat="server" 
         ItemType="News.Models.Category"
         SelectMethod="ListViewCategories_GetData"
         GroupItemCount="2">
        
       <GroupTemplate>
           <div class="row">
               <asp:PlaceHolder ID="ItemPlaceHolder" runat="server"></asp:PlaceHolder>
           </div>
       </GroupTemplate>

         <ItemTemplate>
            <div class="col-md-6">
                <h3><%# Item.Name %></h3>

                <asp:ListView ID="ArticlesList"
                     runat="server" 
                     ItemType="News.Models.Article"
                     DataSource="<%# Item.Articles %>">
                    
                     <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder runat="server" ID="itemPlaceHolder" />
                        </ul>
                    </LayoutTemplate>
                    
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink
                                NavigateUrl='<%# string.Format("~/ArticleDetails.aspx?id={0}",Item.Id) %>'
                                runat="server"
                                Text='<%# string.Format("<strong>{0}</strong> <i>by {1}</i>",Item.Title, Item.Author.UserName) %>' />
                        </li>
                    </ItemTemplate>

                    <EmptyDataTemplate>
                        No articles.
                    </EmptyDataTemplate>

                </asp:ListView>
            </div>
        </ItemTemplate>
    </asp:ListView>
</asp:Content>
