<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="UserAccountDetails.aspx.cs" Inherits="UserAccountDetails" %>
<%@ PreviousPageType VirtualPath="LogIn.aspx" %>
<%@ MasterType VirtualPath ="~/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">
    <asp:Label ID="lblUserName" runat="server" Text="User Name:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtUserName" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblPassword" runat="server" Text="Password:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" ></asp:TextBox>
    <br />
    <asp:Label ID="lblCity" runat="server" Text="City:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtCity" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblState" runat="server" Text="State:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtState" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblFavoriteLanguage" runat="server" Text="Favorit Programming Language:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtFavorite" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblLeastFavorite" runat="server" Text="Least Favorite Programming Language:" Width="400px"></asp:Label>
    <asp:TextBox ID="txtLeastFavorite" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblDateofLastApp" runat="server" Text="Days Since Last Completed Application" Width="400px"></asp:Label>
    <asp:TextBox ID="txtDateofLastApp" runat="server" ></asp:TextBox>
    <br />
    <asp:GridView ID="gvCompletedApps" runat="server" Font-Size="9pt" BackColor="White" BorderColor="#E7E7FF" BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Horizontal"  DataKeyNames="ProgramID"
        OnRowEditing="GV_OnRowEditing" OnRowDeleting="GV_OnRowDeleting"
        OnRowCancelingEdit="GV_RowCancellingEdit" 
        OnRowUpdating="GV_RowUpdateEdit"
        AutoGenerateColumns="False" AllowSorting="True">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <Columns>
            <asp:CommandField ShowEditButton="True"  />
            <asp:CommandField ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="Program ID">
        <ItemTemplate>
            <asp:Label ID="lblProgramID" runat="server" Text='<%# Eval("ProgramID")%>'  ></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtgvProgramID" runat="server" Text='<%# Eval("ProgramID") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Date Completed">
        <ItemTemplate>
            <asp:Label ID="lblgvDateCompleted" runat="server" Text='<%# Eval("DateCompleted") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtgvDateCompleted" runat="server" Text='<%# Eval("DateCompleted") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
    <asp:TemplateField HeaderText="Language">
        <ItemTemplate>
            <asp:Label ID="lblgvLanguage" runat="server" Text='<%# Eval("Language") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtgvLanguage" runat="server" Text='<%# Eval("Language") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
            <asp:TemplateField HeaderText="Program Name">
        <ItemTemplate>
            <asp:Label ID="lblgvProgramName" runat="server" Text='<%# Eval("ProgramName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtgvProgramName" runat="server" Text='<%# Eval("ProgramName") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
            <asp:TemplateField HeaderText="UserName">
        <ItemTemplate>
            <asp:Label ID="lblgvUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
        </ItemTemplate>
        <EditItemTemplate>
            <asp:TextBox ID="txtgvUserName" runat="server" Text='<%# Eval("UserName") %>'></asp:TextBox>
        </EditItemTemplate>
    </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" BorderStyle="Solid" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <SortedAscendingCellStyle BackColor="#F4F4FD" />
        <SortedAscendingHeaderStyle BackColor="#5A4C9D" />
        <SortedDescendingCellStyle BackColor="#D8D8F0" />
        <SortedDescendingHeaderStyle BackColor="#3E3277" />

        
    </asp:GridView>
    <br />
    <br />
    <asp:Button ID="btnAddApplication" runat="server" Text="Add Application" OnClick="AddApps_Click"></asp:Button>
    <br />
    <br />
    </asp:Content>

    <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="server">
        <asp:Label ID ="lblProgramName" runat="server" Text="Program Name" width="155px" ></asp:Label>   
    &nbsp;
    <asp:TextBox ID="txtProgramName" runat="server" Visible="False"></asp:TextBox>
    <br />
    <asp:Label ID="lblLanguage" runat="server" Text="Language" width="155px" ></asp:Label>
    &nbsp;
    <asp:TextBox ID="txtLanguage" runat="server" ></asp:TextBox>
    <br />
    <asp:Label ID="lblDateCompletion" runat="server" Text="Date of Completion" width="155px" ></asp:Label>
    &nbsp;
    <asp:Calendar ID="calDateCompleted" runat="server"></asp:Calendar>
    <br />
    <asp:Button ID="btnSaveApp" runat="server" Text="Save Application" OnClick="SaveApp_Click" ></asp:Button>
    <br />
    <br />  
    </asp:Content>

    <asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder3" runat="server">
        <asp:Button ID="btnUpdateAccount" runat="server" Text="Update Account" OnClick="btnUpdate_Click" width="169px" ></asp:Button>
        &nbsp;
        <br /><br />
        <asp:Button ID="btnDeleteAccount" runat="server" Text="Delete Account" OnClick="btnDeleteAccount_Click" ></asp:Button><br /><br />
        <asp:Button ID="btnFindUser" runat="server" Text="Find User" OnClick="btnFindUser_Click" ></asp:Button>
        <asp:TextBox ID="txtFindUser" runat="server"></asp:TextBox><br /><br />
        <asp:Button ID="btnExport" runat="server" Text="Export Data" OnClick="btnExportData_Click"/>
        <br />
        <br />
        <asp:Button ID="btnLogOut" runat="server" Text="Log Out"  OnClick="btnLogOut_Click"/>
        <br />
    </asp:Content>
