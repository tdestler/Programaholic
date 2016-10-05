using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class LogIn : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblUserNameNew.Visible = false;
            txtUserNameNew.Visible = false;
            lblPasswordNew.Visible = false;
            txtPasswordNew.Visible = false;
            lblCityNew.Visible = false;
            txtCity.Visible = false;
            lblStateNew.Visible = false;
            txtState.Visible = false;
            lblFavoriteNew.Visible = false;
            txtFavorite.Visible = false;
            lblLeastFavoriteNew.Visible = false;
            txtLeastFavorite.Visible = false;
            
            btnCreateAccount.Visible = false;
            lblConfirmPassword.Visible = false;
            txtConfirmPassword.Visible = false;
            lblNewAccountHeader.Visible = false;
            btnGoBack.Visible = false;
        }
    }
    public string LogInUserName { get { return txtUserName.Text.ToString(); } }
    public string LogInPassword { get { return txtPassword.Text.ToString(); } }
    public string UserNameNew { get { return txtUserNameNew.Text.ToString(); } }
    public string Password { get { return txtPasswordNew.Text.ToString(); } }
    public string ConfirmPassword {  get { return txtConfirmPassword.Text.ToString(); } }
    public string City { get { return txtCity.Text.ToString(); } }
    public string State { get { return txtState.Text.ToString(); } }
    public string FavoriteLanguage { get { return txtFavorite.Text.ToString(); } }
    public string LeastFavoriteLanguage { get { return txtLeastFavorite.Text.ToString(); } }
   

    public void btnGoBack_Click(object sender, EventArgs e)//change layout visibility
    {
        lblUserName.Visible = true;
        txtUserName.Visible = true;
        lblPassword.Visible = true;
        txtPassword.Visible = true;
        btnLogIn.Visible = true;
        btnCreateNew.Visible = true;

        lblUserNameNew.Visible = false;
        txtUserNameNew.Visible = false;
        lblPasswordNew.Visible = false;
        txtPasswordNew.Visible = false;
        lblCityNew.Visible = false;
        txtCity.Visible = false;
        lblStateNew.Visible = false;
        txtState.Visible = false;
        lblFavoriteNew.Visible = false;
        txtFavorite.Visible = false;
        lblLeastFavoriteNew.Visible = false;
        txtLeastFavorite.Visible = false;
        
        btnCreateAccount.Visible = false;
        lblConfirmPassword.Visible = false;
        txtConfirmPassword.Visible = false;
        lblNewAccountHeader.Visible = false;
        btnGoBack.Visible = false;
    }

    public void ValidateUser_Click(object sender, EventArgs e)
    {
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");
    ClsDataLayer myDataLayer = new ClsDataLayer(tempPath);
        
        bool isValid = myDataLayer.ValidateUser(txtUserName.Text.ToString(), txtPassword.Text.ToString());
        if (isValid == true)
            {
            Session["UserName"] = txtUserName.Text.ToString();
            
            Response.Redirect("UserAccountDetails.aspx");
            }
        else
        {
            Master.lblsubtitle.Text = "InvalidCredentials. Please try again!";
        }
    
}

    protected void btnCreateNew_Click(object sender, EventArgs e)//change layout visibility
    {
        lblUserNameNew.Visible = true;
        txtUserNameNew.Visible = true;
        lblPasswordNew.Visible = true;
        txtPasswordNew.Visible = true;
        lblCityNew.Visible = true;
        txtCity.Visible = true;
        lblStateNew.Visible = true;
        txtState.Visible = true;
        lblFavoriteNew.Visible = true;
        txtFavorite.Visible = true;
        lblLeastFavoriteNew.Visible = true;
        txtLeastFavorite.Visible = true;
        btnCreateAccount.Visible = true;
        lblConfirmPassword.Visible = true;
        txtConfirmPassword.Visible = true;
        lblUserName.Visible = false;
        txtUserName.Visible = false;
        lblPassword.Visible = false;
        txtPassword.Visible = false;
        btnLogIn.Visible = false;
        btnCreateNew.Visible = false;
        lblNewAccountHeader.Visible = true;
        btnGoBack.Visible = true;

    }
    
    protected void ValidateNewUser_Click(object sender, EventArgs e)
    {
        string tempPath = "~/App_Code/";
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);
        string IsValidEntries = myBusinessLayer.ValidateNewUser(UserNameNew, Password, ConfirmPassword, City, State, FavoriteLanguage, LeastFavoriteLanguage)
;
        if (IsValidEntries == "isValid")
        {
          
            Response.Redirect("ConfirmAccount.aspx");
        }
        else
        {
            Master.lblsubtitle.Text = IsValidEntries.ToString();
        }
    }
}
