<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ArticleDetails.aspx.cs" Inherits="News.Web.ArticleDetails" MasterPageFile="~/Site.Master" %>

<asp:Content ID="ArticleDetailsContent" runat="server" ContentPlaceHolderID="MainContent">
    <asp:FormView 
        runat="server"
        ID="FormViewArticleDetails" 
        ItemType="News.Models.Article" 
        SelectMethod="FormViewArticleDetails_GetItem">
        
        <ItemTemplate>
            
              <asp:LoginView runat="server">
                <LoggedInTemplate>
                    <div>
                        <div class="like-control col-md-1">
                            <div>Likes</div>
                            <asp:UpdatePanel runat="server" >
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="LikeBtn" EventName="Click"/>
                                    <asp:AsyncPostBackTrigger ControlID="DislikeBtn" EventName="Click" />
                                </Triggers>
                                <ContentTemplate>
                                    <div>
                                        <asp:LinkButton ID="LikeBtn" runat="server" class="btn btn-default glyphicon glyphicon-chevron-up" OnClick="LikeBtn_Click" />
                                        <asp:Label Text="<%# GetLikesValue() %>" runat="server" CssClass="like-value" ID="LikesValue" />
                                        <asp:LinkButton ID="DislikeBtn" runat="server" class="btn btn-default glyphicon glyphicon-chevron-down" OnClick="DislikeBtn_Click" />
                                    </div>
                                </ContentTemplate>
                            </asp:UpdatePanel>

                        </div>
                    </div>
                </LoggedInTemplate>
            </asp:LoginView>

            <h2><%# Item.Title %> <small>Category: <%# Item.Category.Name %></small></h2>
            <p><%# Item.Content %></p>
            <p>
                <span>Author: <%# Item.Author.UserName %></span>
                <span class="pull-right"><%#: Item.DateCreated.ToString("MM/dd/yyyy hh:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture) %></span>
            </p>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>

<%--https://github.com/dnmitev/ASPNET-WebForms/blob/master/PracticalExam/App.Web/ArticleDetails.aspx.cs--%>