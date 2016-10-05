using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;

public partial class ConfirmAccount : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (PreviousPage.IsCrossPagePostBack)

            {
                lblUsername.Text = PreviousPage.UserNameNew.ToString();
                lblPassword.Text = PreviousPage.Password.ToString();
                lblCity.Text = PreviousPage.City.ToString();
                lblState.Text = PreviousPage.State.ToString();
                lblFavoriteLanguage.Text = PreviousPage.FavoriteLanguage.ToString();
                lblLeastFavoriteLanguage.Text = PreviousPage.LeastFavoriteLanguage.ToString();
                
            }
            
        }
        catch (Exception error)//notify programmer of error during debug
        {
           
            
                Master.lblsubtitle.Text = error.ToString();
            
        }   
    }
    protected void btnCreateAccount_Click(object sender, EventArgs e)
    {
        

            string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");
            clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);
            string message = myBusinessLayer.CreateUser(lblUsername.Text.ToString(), lblPassword.Text.ToString(), lblCity.Text.ToString(), lblState.Text.ToString(), lblFavoriteLanguage.Text.ToString(), lblLeastFavoriteLanguage.Text.ToString());

            
            if (message == "isValid")
            {
            Session["UserName"] = lblUsername.Text.ToString();
                Response.Redirect("UserAccountDetails.aspx");
            }
        
            else
        {
            Master.lblsubtitle.Text = message.ToString();
        }
        

    }


}