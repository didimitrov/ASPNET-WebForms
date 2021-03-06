﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CreateArticle.aspx.cs" Inherits="News.Web.Admin.CreateArticle" MasterPageFile="~/Site.Master"%>

<asp:Content runat="server" ID="Content1" ContentPlaceHolderID="MainContent">
    <div id="create-article" class="row">
        <h3>
            <asp:Label runat="server" Text="Title:" AssociatedControlID="TextBoxArticleTitle"></asp:Label>
            <asp:TextBox runat="server" ID="TextBoxArticleTitle" Width="300px" Text="<%# BindItem.Title %>"></asp:TextBox>
             <asp:RequiredFieldValidator
                ErrorMessage="Title is required"
                ControlToValidate="TextBoxArticleTitle"
                runat="server"
                CssClass="label label-warning" />
        </h3>
        <p>
            <asp:Label runat="server" Text="Category: " AssociatedControlID="DropDownListArticleCategory" ></asp:Label>
            <asp:DropDownList 
                runat="server"
                ID="DropDownListArticleCategory" 
                DataTextField="Name" 
                DataValueField="Id" 
                SelectMethod="DropDownListCategoriesCreate_GetData"/>
        </p>
        <p>
            <asp:Label runat="server" ID="LabelArticleContent" Text="Content" AssociatedControlID="TextBoxArticleContent"></asp:Label>
            <asp:TextBox runat="server" 
                ID="TextBoxArticleContent" 
                TextMode="MultiLine" 
                Height="150px" Width="300px" 
                Text="<%# BindItem.Content %>"></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" 
                ErrorMessage="Article content is required"
                ControlToValidate="TextBoxArticleContent"
                CssClass="label label-warning"></asp:RequiredFieldValidator>
        </p>
        
        <div>
            <asp:LinkButton runat="server" ID="btnSave_Click" CommandName="Insert"  CssClass="btn btn-success" OnClick="SaveBtn_Click" Text="Save"></asp:LinkButton>
            <asp:HyperLink runat="server" NavigateUrl="~/Admin/EditArticles" Text="Cancel" CssClass="btn btn-danger"></asp:HyperLink>
        </div>
    </div>
</asp:Content>
