<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="LogIn.aspx.cs" Inherits="LogIn" %>
<%@ MasterType VirtualPath ="~/MasterPage.master" %>


 <asp:Content ID="ContentArea1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
     <asp:Label ID="lblUserName" runat="server" Text="User Name" width="88px"></asp:Label>&nbsp;
     <asp:TextBox ID="txtUserName" runat="server" width="168px" ></asp:TextBox><br />
     <asp:Label ID="lblPassword" runat="server" Text="Password" width="88px"></asp:Label>&nbsp;
     <asp:TextBox ID="txtPassword" runat="server" width="168px" ></asp:TextBox>
     </asp:Content>
 <asp:Content ID="ContentArea2" ContentPlaceHolderID="ContentPlaceHolder2" Runat="server">
     <asp:Button ID="btnLogIn" runat="server" Text="Log In" OnClick="ValidateUser_Click" />
     &nbsp;&nbsp;&nbsp;
     <asp:Button ID="btnCreateNew" runat="server" Text="New User" 
         OnClick="btnCreateNew_Click" /><br />
     <asp:Label ID="lblNewAccountHeader" runat="server" Text="Please Complete the Form Below to Create a New Account."></asp:Label><br /><br />
     </asp:Content>
<asp:Content ID="ContentArea3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
    <asp:Label ID="lblUserNameNew" runat="server" Text="Username" width="325px"></asp:Label>
    <asp:TextBox ID="txtUserNameNew" runat="server" width="168px"></asp:TextBox><br />
    <asp:Label ID="lblPasswordNew" runat="server" Text="Password" width="325px"></asp:Label>
    <asp:TextBox ID="txtPasswordNew" runat="server" width="168px"></asp:TextBox><br />
    <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password" width="325px"></asp:Label>
     <asp:TextBox ID="txtConfirmPassword" runat="server" width="168px"></asp:TextBox>
     <br />
    <asp:Label ID="lblCityNew" runat="server" Text="City" width="325px"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server" width="168px"></asp:TextBox><br />
    <asp:Label ID="lblStateNew" runat="server" Text="State" width="325px"></asp:Label>
    <asp:TextBox ID="txtState" runat="server" Width="168px"></asp:TextBox><br />
    <asp:Label ID="lblFavoriteNew" runat="server" Text="Favorite Programming Language" width="325px"></asp:Label>
    <asp:TextBox ID="txtFavorite" runat="server" width="168px"></asp:TextBox><br />
    <asp:Label ID="lblLeastFavoriteNew" runat="server" Text="Least Favorite Programming Language" width="325px"></asp:Label>
    <asp:TextBox ID="txtLeastFavorite" runat="server" width="168px"></asp:TextBox><br />
    <%--<asp:Label ID="lblDateLastCompleted" runat="server" Text="Date of Last Completed Application" width="325px"></asp:Label>
    <asp:TextBox ID="txtDateLastCompleted" runat="server" width="168px"></asp:TextBox>--%>
    <br /><br />
    <asp:Button ID="btnCreateAccount" runat="server" Text="Create Account" PostBackUrl="~/ConfirmAccount.aspx" />
    <br />
    <asp:Button ID="btnGoBack" runat="server" 
         Text="Already Have an Acount. Go Back to Log In" PostBackUrl="~/LogIn.aspx" 
         OnClick="btnGoBack_Click" />
    <asp:GridView ID="gvUserPass" runat="server" AutoGenerateColumns="False" DataKeyNames="UserName" DataSourceID="gvUserNamePassword" >
        <Columns>
            <asp:BoundField DataField="UserName" HeaderText="UserName" ReadOnly="True" SortExpression="UserName" />
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
        </Columns>
</asp:GridView>
<asp:SqlDataSource ID="gvUserNamePassword" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString4 %>" ProviderName="<%$ ConnectionStrings:ConnectionString4.ProviderName %>" SelectCommand="SELECT [UserName], [Password] FROM [tblUserAccountInformation]"></asp:SqlDataSource>
    </asp:Content>

