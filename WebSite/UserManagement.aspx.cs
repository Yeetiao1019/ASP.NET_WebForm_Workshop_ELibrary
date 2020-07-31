using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserManagement : System.Web.UI.Page
{
    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        UserGridView.DataBind();
    }

    protected void SearchUserIDLinkButton_Click(object sender, EventArgs e)
    {
        getUserByID();
    }

    protected void ActiveLinkButton_Click(object sender, EventArgs e)
    {
        updateUserStatusByID("Active");
    }

    protected void PendingLinkButton_Click(object sender, EventArgs e)
    {
        updateUserStatusByID("Pending");
    }

    protected void InactiveLinkButton_Click(object sender, EventArgs e)
    {
        updateUserStatusByID("Inactive");
    }

    protected void DeleteUserPermanentlyButton_Click(object sender, EventArgs e)
    {
        deleteUser();
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

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT user_id FROM user_master_table WHERE user_id = '" + UserIDTextBox.Text.Trim() + "'", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        return false;
    }

    void getUserByID()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT * FROM user_master_table WHERE user_id = '" + UserIDTextBox.Text.Trim() + "';", conn);
            SqlDataReader dataReader = sqlCmd.ExecuteReader(); //只讀取第一筆資料
            if (dataReader.HasRows)
            {
                UserIDTextBox.Text = dataReader.GetValue(8).ToString();
                FullNameTextBox.Text = dataReader.GetValue(0).ToString();
                UserStatusTextBox.Text = dataReader.GetValue(10).ToString();
                DOBTextBox.Text = dataReader.GetValue(1).ToString();
                ContactNumberTextBox.Text = dataReader.GetValue(2).ToString();
                EmailTextBox.Text = dataReader.GetValue(3).ToString();
                StateTextBox.Text = dataReader.GetValue(4).ToString();
                CityTextBox.Text = dataReader.GetValue(6).ToString();
                PinCodeTextBox.Text = dataReader.GetValue(5).ToString();
                AddressTextBox.Text = dataReader.GetValue(7).ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid user ID.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updateUserStatusByID(string userStatus)
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //Update account status to active
            SqlCommand sqlCmd = new SqlCommand("UPDATE user_master_table SET account_status = '" + userStatus + "'" + "WHERE user_id = '" + UserIDTextBox.Text.Trim() + "'", conn);
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Change user status successful!');</script>");
            UserStatusTextBox.Text = userStatus;
            UserGridView.DataBind(); //Grid auto refresh after insert data
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void deleteUser()
    {
        if (checkUserExist())
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }

                //DELETE 語法 
                SqlCommand sqlCmd = new SqlCommand("DELETE FROM user_master_table WHERE user_id = @user_id", conn);

                //接收TextBox值寫入@user_id參數
                sqlCmd.Parameters.AddWithValue("@user_id", UserIDTextBox.Text.Trim()); //Trim 移除前後空白
                sqlCmd.ExecuteNonQuery();
                conn.Close();
                Response.Write("<script>alert('User delete successful!');</script>");
                clearForm();
                UserGridView.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('Invalid User ID');</script>");
        }
    }

    void clearForm()
    {
        UserIDTextBox.Text = "";
        FullNameTextBox.Text = "";
        UserStatusTextBox.Text = "" ;
        DOBTextBox.Text = "";
        ContactNumberTextBox.Text = "";
        EmailTextBox.Text = "";
        StateTextBox.Text = "";
        CityTextBox.Text = "";
        PinCodeTextBox.Text = "";
        AddressTextBox.Text = "";
    }

}