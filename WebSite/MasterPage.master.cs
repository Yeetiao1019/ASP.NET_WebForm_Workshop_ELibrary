using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty((string)Session["role"]))
        {
            //Navbar LinkButton
            SignUpLinkButton.Visible = true; //User or admin not login, button is visible.
            UserLoginLinkButton.Visible = true;

            LogoutLinkButton.Visible = false; //User or admin not login, button is invisible.
            UserLinkButton.Visible = false;

            //Footer LinkButton
            AdminLoginLinkButton.Visible = true;
            AuthorManagementLinkButton.Visible = false;
            PublisherManagementLinkButton.Visible = false;
            BookInventoryLinkButton.Visible = false;
            BookIssuingLinkButton.Visible = false;
            UserManagementLinkButton.Visible = false;
        }
        else if (Session["role"].Equals("user"))
        {
            //Navbar LinkButton
            SignUpLinkButton.Visible = false; //User login, button is invisible.
            UserLoginLinkButton.Visible = false;

            LogoutLinkButton.Visible = true; //User login, button is visible.
            UserLinkButton.Visible = true;
            UserLinkButton.Text = "Hello," + Session["username"].ToString();

            //Footer LinkButton
            AdminLoginLinkButton.Visible = false;
            AuthorManagementLinkButton.Visible = false;
            PublisherManagementLinkButton.Visible = false;
            BookInventoryLinkButton.Visible = false;
            BookIssuingLinkButton.Visible = false;
            UserManagementLinkButton.Visible = false;
        }else if(Session["role"].Equals("admin"))
        {
            //Admin Login
            //Navbar LinkButton
            SignUpLinkButton.Visible = false; //Admin login, button is invisible.
            UserLoginLinkButton.Visible = false;

            LogoutLinkButton.Visible = true; //Admin login, button is visible.
            UserLinkButton.Visible = true;
            UserLinkButton.Text = "Hello, Admin";

            //Footer LinkButton
            AdminLoginLinkButton.Visible = false;
            AuthorManagementLinkButton.Visible = true;
            PublisherManagementLinkButton.Visible = true;
            BookInventoryLinkButton.Visible = true;
            BookIssuingLinkButton.Visible = true;
            UserManagementLinkButton.Visible = true;
        }
    }

    protected void AdminLoginLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminLogin.aspx");
    }

    protected void AuthorManagementLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("AuthorManagement.aspx");
    }

    protected void PublisherManagementLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("PublisherManagement.aspx");
    }

    protected void BookInventoryLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookInventory.aspx");
    }

    protected void BookIssuingLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookIssuing.aspx");
    }

    protected void UserManagementLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserManagement.aspx");
    }

    protected void ViewBooksLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("ViewBooks.aspx");
    }

    protected void UserLoginLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserLogin.aspx");
    }

    protected void SignUpLinkButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("SignUpPage.aspx");
    }

    protected void LogoutLinkButton_Click(object sender, EventArgs e)
    {
        Session["userName"] = "";
        Session["fullName"] = "";
        Session["role"] = "";
        Session["status"] = "";

        //Navbar LinkButton
        SignUpLinkButton.Visible = true; //User or admin not login, button is visible.
        UserLoginLinkButton.Visible = true;

        LogoutLinkButton.Visible = false; //User or admin not login, button is invisible.
        UserLinkButton.Visible = false;

        //Footer LinkButton
        AdminLoginLinkButton.Visible = true;
        AuthorManagementLinkButton.Visible = false;
        PublisherManagementLinkButton.Visible = false;
        BookInventoryLinkButton.Visible = false;
        BookIssuingLinkButton.Visible = false;
        UserManagementLinkButton.Visible = false;
    }
}
