<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="ConfirmAccount.aspx.cs" Inherits="ConfirmAccount" %>
<%@ PreviousPageType VirtualPath="LogIn.aspx" %>
<%@ MasterType VirtualPath ="~/MasterPage.master" %>


<asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblUsername" runat="server" ></asp:Label><br />
    <asp:Label ID="lblPassword" runat="server" ></asp:Label>  <br /> 
    <asp:Label ID="lblCity" runat="server" ></asp:Label><br />
    <asp:Label ID="lblState" runat="server"></asp:Label><br />
    <asp:Label ID="lblFavoriteLanguage" runat="server" ></asp:Label><br />
    <asp:Label ID="lblLeastFavoriteLanguage" runat="server"></asp:Label><br />
    
</asp:Content>
<asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
    <asp:Button ID="btnConfirm" runat="server" Text="Confirm" OnClick="btnCreateAccount_Click"/>
</asp:Content>
