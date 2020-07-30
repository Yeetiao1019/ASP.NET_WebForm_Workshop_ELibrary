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
}
