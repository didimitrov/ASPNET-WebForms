<%@ Page Language="C#" Title="Articles Editor" AutoEventWireup="true" CodeBehind="EditArticles.aspx.cs" Inherits="News.Web.Admin.EditArticles" MasterPageFile="~/Site.Master" %>

<asp:Content runat="server" ID="ArticleEditorContent" ContentPlaceHolderID="MainContent">
    <asp:ListView 
        runat="server" 
        ID="ListViewArticleEditor" 
        ItemType="News.Models.Article"
        SelectMethod="ArticlesEditor_GetData"
        DeleteMethod="ArticlesEditor_DeleteItem"
        UpdateMethod="ArticlesEditor_UpdateItem"
        DataKeyNames="Id">
        
        <LayoutTemplate>
            <div class="row">
                <asp:LinkButton runat="server" ID="linkBtnSortByTitle" Text="Sort by title" CommandName="Sort" CommandArgument="Title" CssClass="col-md-2 btn btn-default"></asp:LinkButton>
            </div>
            
            <asp:PlaceHolder runat="server" ID="itemPlaceHolder"></asp:PlaceHolder>
            
            <div class="row">
                <asp:DataPager runat="server" ID="DataPagerCategories" PagedControlID="ListViewArticleEditor" PageSize="5">
                       <Fields>
                        <asp:NextPreviousPagerField />
                        <asp:NumericPagerField />
                    </Fields>
                </asp:DataPager>
            </div>
               <asp:LinkButton Text="Insert New Article" runat="server"  class="btn btn-info pull-right" PostBackUrl="~/Admin/CreateArticle.aspx" />
        </LayoutTemplate>
        
           <ItemTemplate>
            <div class="row">
                <h3>
                    <%# Item.Title %>
                    <asp:LinkButton Text="Edit" runat="server" ID="EditBtn" CommandName="Edit" CssClass="btn btn-info" />
                    <asp:LinkButton Text="Delete" runat="server" ID="DeleteBtn" CommandName="Delete" CssClass="btn btn-danger" OnClientClick="return confirm('Are you sure you want delete this?');"></asp:LinkButton>
                </h3>
                <p>Category: <%# Item.Category %></p>
                <p>
                    <%# Item.Content %>
                </p>
                <p>Likes count: <%# Item.Likes %></p>
                <div>
                    <i>by <%# Item.Author.ToString() %></i>
                    <i>created on: <%#: Item.DateCreated.ToString("MM/dd/yyyy hh:mm:ss tt",System.Globalization.CultureInfo.InvariantCulture) %></i>
                </div>
            </div>
        </ItemTemplate>
        
        <EditItemTemplate>
            <div class="row">
                <h3>
                    <asp:TextBox runat="server" ID="TextBoxEditTitle" Text="<%# BindItem.Title %>"></asp:TextBox>
                    <asp:LinkButton runat="server" ID="EditBtn" Text="Save" CommandName="Update" CssClass="btn btn-success"></asp:LinkButton>
                    <asp:LinkButton runat="server" ID="DeleteBtn" Text="Cancel" CommandName="Cancel" CssClass="btn btn-danger"></asp:LinkButton>
                </h3>
                <p>
                    <asp:Label runat="server" ID="LabelCategory" Text="Category:" AssociatedControlID="DropDownListCategory"></asp:Label>
                    <asp:DropDownList 
                        runat="server" 
                        ID="DropDownListCategory" 
                        DataTextField="Name" 
                        DataValueField="Id" 
                        ItemType="News.Models.Category"
                        SelectMethod="DropDownListCategoriesCreate_GetData"/>
                </p>
                <p>
                    <asp:TextBox runat="server" ID="TExtBoxEditContent" TextMode="MultiLine" Height="150px" Width="90%" Text=" <%# BindItem.Content %>" />
                </p>
                <div>
                    <i>by <%# Item.Author %></i>
                    <i>created on: <%#: Item.DateCreated.ToString("MM/dd/yyyy hh:mm:ss tt",System.Globalization.CultureInfo.InvariantCulture) %></i>
                </div>
            </div>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>

