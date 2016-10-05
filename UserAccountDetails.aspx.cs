using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class UserAccountDetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//database file path       
        ClsDataLayer myDataLayer = new ClsDataLayer(tempPath);
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(Server.MapPath("~/App_Code/"));
        string UserName = Convert.ToString(Session["UserName"]);
        try
        {
            if (!IsPostBack)
            {
                DsUserAccountInfo dsFindUserName;
                dsFindUserName = myDataLayer.FindUserName(Convert.ToString(Session["UserName"]));//fill fields with associated user information
                BindApplicationGridView(Convert.ToString(Session["UserName"]));//bind application gridview to the user
                btnAddApplication.Visible = true;
                if (dsFindUserName.tblUserAccountInformation.Rows.Count > 0)
                {
                    //fill all fields with retrieved data
                    txtUserName.Text = dsFindUserName.tblUserAccountInformation[0].UserName;
                    txtPassword.Text = dsFindUserName.tblUserAccountInformation[0].Password;
                    txtCity.Text = dsFindUserName.tblUserAccountInformation[0].City;
                    txtState.Text = dsFindUserName.tblUserAccountInformation[0].State;
                    txtFavorite.Text = dsFindUserName.tblUserAccountInformation[0].FavoriteLanguage;
                    txtLeastFavorite.Text = dsFindUserName.tblUserAccountInformation[0].LeastFavoriteLanguage;
                    //txtDateofLastApp.Text = (Convert.ToString(myBusinessLayer.NumDays(UserName, tempPath))) + " days";
                }
                txtDateofLastApp.Text = (Convert.ToString(myBusinessLayer.NumDays(UserName, tempPath))) + " days";
                lblProgramName.Visible = false;
                txtProgramName.Visible = false;
                lblDateCompletion.Visible = false;
                //txtDateCompletion.Visible = false;
                lblLanguage.Visible = false;
                txtLanguage.Visible = false;
                btnSaveApp.Visible = false;
                calDateCompleted.Visible = false;
            }
        }
        catch (Exception error)
        {
            string message = "Something went wrong. ";
            Master.lblsubtitle.Text = message + error.Message;//combine predefined and web error
            lblProgramName.Visible = false;
            txtProgramName.Visible = false;
            lblDateCompletion.Visible = false;
            //txtDateCompletion.Visible = false;
            lblLanguage.Visible = false;
            txtLanguage.Visible = false;
            btnSaveApp.Visible = false;
            calDateCompleted.Visible = false;
        }
    }

    protected void btnFindUser_Click(object sender, EventArgs e)
    {
        DsUserAccountInfo dsFindUserNameBtn;
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//database file path
        ClsDataLayer dataLayerObj = new ClsDataLayer(tempPath);

        try
        {
            dsFindUserNameBtn = dataLayerObj.FindUserName(txtFindUser.Text.ToString());//find user based on Username

            if (dsFindUserNameBtn.tblUserAccountInformation.Rows.Count > 0)
            {
                //fill all fields with retrieved data
                txtUserName.Text = dsFindUserNameBtn.tblUserAccountInformation[0].UserName;
                txtPassword.Text = dsFindUserNameBtn.tblUserAccountInformation[0].Password;
                txtCity.Text = dsFindUserNameBtn.tblUserAccountInformation[0].City;
                txtState.Text = dsFindUserNameBtn.tblUserAccountInformation[0].State;
                txtFavorite.Text = dsFindUserNameBtn.tblUserAccountInformation[0].FavoriteLanguage;
                txtLeastFavorite.Text = dsFindUserNameBtn.tblUserAccountInformation[0].LeastFavoriteLanguage;
                txtDateofLastApp.Text = dsFindUserNameBtn.tblUserAccountInformation[0].DateofLastProgram;
                BindApplicationGridView(txtUserName.Text);
                txtFindUser.Text = null;
            }
        }

        catch (Exception error)
        {
            string message = "Something went wrong. ";
            Master.lblsubtitle.Text = message + error.Message;//combine predefined and web error
        }

    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        string message;
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//database file path
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);

        try
        {

            //try to update customer with all new and unchanged data values 
            message = myBusinessLayer.UpdateUser(txtUserName.Text, txtCity.Text, txtState.Text,
                txtFavorite.Text, txtLeastFavorite.Text, txtDateofLastApp.Text);
            Master.lblsubtitle.Text = message;

        }
        catch (Exception error)
        {

            message = "Error updating customer, please check form data. ";

            Master.lblsubtitle.Text = message + error.Message;//combine predefined and web error
        }
    }

    protected void btnDeleteAccount_Click(object sender, EventArgs e)
    {
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//database file path
        ClsDataLayer myDataLayer = new ClsDataLayer(tempPath);

        try
        {

            //try to delete customer with all new and unchanged data values 
            myDataLayer.DeleteAddict(txtUserName.Text.ToString());

            Master.lblsubtitle.Text = "User Deleted Successfully";
            txtUserName.Text = null;
            txtPassword.Text = null;
            txtCity.Text = null;
            txtState.Text = null;
            txtFavorite.Text = null;
            txtLeastFavorite.Text = null;
            txtDateofLastApp.Text = null;


        }
        catch (Exception error)
        {

            string message = "Error updating customer, please check form data. ";

            Master.lblsubtitle.Text = message + error.Message;//combine predefined and web error
        }
    }

    private dsCompletedApplications BindApplicationGridView(string userName)
    {
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//path to db file

        //ClsDataLayer myDataLayer = new ClsDataLayer(tempPath);//create instance of clsdatalayer
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);//create instance of clsbusiness layer

        dsCompletedApplications completedApps = myBusinessLayer.getApps(userName);////create dataset of all apps by user
        gvCompletedApps.DataSource = completedApps.tblCompletedApplications;//create source for gridvies

        gvCompletedApps.DataBind();//bind the gridview to gvCompletedApps
        return completedApps;//return completedApps
    }

    public void btnExportData_Click(object sender, EventArgs e)
    {
        try
        {
            string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");//create string path to write file
            string xmlPath = Server.MapPath("~/App_Data/");
            clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);//create instance of clsbusinesslayer
            dsCompletedApplications appListing = myBusinessLayer.getApps(Convert.ToString(Session["UserName"]));//create dataset from getApps method sending Session UserName

            Cache.Insert("ApplicationDataSet", appListing);//insert dataset into cache
            myBusinessLayer.WriteApplicationXMLFile(Cache, xmlPath);//send cached dataset to businesslayer
        }
        catch (Exception error)
        {
            Master.lblsubtitle.Text = error.ToString();//notify user of error
        }
    }
    
    public void btnLogOut_Click(object sender, EventArgs e)
    {
        //clear session variables to return to log in page
        Session["UserName"] = null;
        Session["Authenticate"] = false;
        Response.Redirect("LogIn.aspx");//redirect back to log in page
    }

    public void AddApps_Click(object sender, EventArgs e)
    {
        //make application data fields visible for 
        lblProgramName.Visible = true;
        txtProgramName.Visible = true;
        lblDateCompletion.Visible = true;
        //txtDateCompletion.Visible = true;
        lblLanguage.Visible = true;
        txtLanguage.Visible = true;
        btnSaveApp.Visible = true;
        btnAddApplication.Visible = false;
        calDateCompleted.Visible = true;

    }

    public void SaveApp_Click(object sender, EventArgs e)
    {
        try
        {
            string message = "isNotValid";

            string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");
            clsBusinessLayer mybusinesslayer = new clsBusinessLayer(tempPath);
            DateTime date = calDateCompleted.SelectedDate;
            //call send inputs to clsDataLayer
            message = mybusinesslayer.SaveApp(date, txtLanguage.Text, txtProgramName.Text, Convert.ToString(Session["UserName"]));
            if (message == "isValid")
            {
                //if application was saved notify user
                Master.lblsubtitle.Text = "Application successfully saved";
            }


            //clear input fields for next entry
            txtProgramName.Text = null;
            //txtDateCompletion.Text = null;
            txtLanguage.Text = null;
            BindApplicationGridView(Convert.ToString(Session["UserName"]));
        }
        catch (Exception error)
        {
            Master.lblsubtitle.Text = error.ToString();
        }
    }

    protected void GV_OnRowEditing(object sender, GridViewEditEventArgs e)
    {
        gvCompletedApps.EditIndex = e.NewEditIndex;//show update/cancel buttons

        BindApplicationGridView(Convert.ToString(Session["UserName"]));
    }

    protected void GV_RowCancellingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        //cancel all changes and return to itemtemplate view on gridview
        try
        {
            gvCompletedApps.EditIndex = -1;
            //bind the gridview to the username 
            BindApplicationGridView(Convert.ToString(Session["UserName"]));
        }
        catch (Exception error)
        {
            Master.lblsubtitle.Text = error.ToString();
        }
    }

    protected void GV_RowUpdateEdit(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");
            clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);
            //assign all gridview textboxes from the row to variables           
            string strProgramID = gvCompletedApps.DataKeys[e.RowIndex].Value.ToString();          
            string strDateCompleted = ((TextBox)gvCompletedApps.Rows[e.RowIndex].FindControl("txtgvDateCompleted")).Text;
            string strLanguage = ((TextBox)gvCompletedApps.Rows[e.RowIndex].FindControl("txtgvLanguage")).Text;
            string strProgramName = ((TextBox)gvCompletedApps.Rows[e.RowIndex].FindControl("txtgvProgramName")).Text;
            string userName = Convert.ToString(Session["UserName"]);
            //update completedapplication table
            string message = myBusinessLayer.UpdateApps(strProgramID, strDateCompleted, strLanguage, strProgramName, Convert.ToString(Session["UserName"]));
            //if successfull notify user 
            Master.lblsubtitle.Text = message.ToString();
            BindApplicationGridView(userName);//bind application to the username
            //gvCompletedApps.EditIndex = -1;
        }
        catch (Exception error)
        {
            Master.lblsubtitle.Text = error.ToString();
        }
    }

    protected void GV_OnRowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        { 
        
        string tempPath = Server.MapPath("~/Programaholicsaccdb.accdb");
        clsBusinessLayer myBusinessLayer = new clsBusinessLayer(tempPath);
        //get row of changed fields
        GridViewRow row = (GridViewRow)gvCompletedApps.Rows[e.RowIndex];
            //assign retunred value
         int intProgramID = Convert.ToInt32(((Label)row.FindControl("lblProgramID")).Text);
            //notify user is successfully deleted
            Master.lblsubtitle.Text = myBusinessLayer.DeleteApps(intProgramID);

        BindApplicationGridView(Convert.ToString(Session["UserName"]));//Bind gridview to the username
        }
    catch (Exception error)
        {
            Master.lblsubtitle.Text = error.ToString();
        }
    }
}