using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SignupPage : System.Web.UI.Page
{
    //Connect to MSSQL
    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    //Sign up button click event
    protected void SignUpButton_Click(object sender, EventArgs e)
    {
        if (checkUserExist())
        {
            Response.Write("<script>alert('User ID already created, try other User ID.');</script>");
        }
        else
        {
            signUpNewUser();
        }
        
    }

    bool checkUserExist()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查UserID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT user_id FROM user_master_table WHERE user_id = '" + UserIDTextBox.Text.Trim() +"';", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if(dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@full_name", FullNameTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.Parameters.AddWithValue("@dob", BirthTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@contact_number", ContactNumberTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@state", StateDropDownList.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@pincode", PinCodeTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@city", CityTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@full_address", AddressTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@user_id", UserIDTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@password", PasswordTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@account_status", "Pending");

            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Sign up successful! Go to Login.');</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        return false;
    }

    void signUpNewUser()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //INSERT INTO語法 
            SqlCommand sqlCmd = new SqlCommand(
                "INSERT INTO user_master_table"
                + "(full_name,dob,contact_number,email,state,pincode,city,full_address,user_id,password,account_status)"
                + "VALUES(@full_name,@dob,@contact_number,@email,@state,@pincode,@city,@full_address,@user_id,@password,@account_status)", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@full_name", FullNameTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.Parameters.AddWithValue("@dob", BirthTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@contact_number", ContactNumberTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@email", EmailTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@state", StateDropDownList.SelectedItem.Value);
            sqlCmd.Parameters.AddWithValue("@pincode", PinCodeTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@city", CityTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@full_address", AddressTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@user_id", UserIDTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@password", PasswordTextBox.Text.Trim());
            sqlCmd.Parameters.AddWithValue("@account_status", "Pending");

            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Sign up successful! Go to Login.');</script>");
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }
}