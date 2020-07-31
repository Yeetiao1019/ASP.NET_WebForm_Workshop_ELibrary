using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserLogin : System.Web.UI.Page
{

    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void LoginButton_Click(object sender, EventArgs e)
    {

        try
        {
            SqlConnection sqlConn = new SqlConnection(strConn);
            if(sqlConn.State == ConnectionState.Closed)
            {
                sqlConn.Open();
            }
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM user_master_table WHERE user_id = '" + UserLoginTextbox.Text.Trim() + "' AND password = '" + PasswordTextbox.Text.Trim() + "'", sqlConn);
            SqlDataReader dataReader = sqlCmd.ExecuteReader();
            if (dataReader.HasRows)
            {
                while (dataReader.Read())
                {
                    //Response.Write("<script>alert('" + dataReader.GetValue(8).ToString()+ "');</script>");
                    Session["userName"] = dataReader.GetValue(8).ToString();
                    Session["fullName"] = dataReader.GetValue(0).ToString();
                    Session["role"] = "user";
                    Session["status"] = dataReader.GetValue(10).ToString();
                }
                Response.Redirect("HomePage.aspx");
            }
            else
            {
                Response.Write("<script>alert('Error credentials');</script>");
            }

        }
        catch(Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
}