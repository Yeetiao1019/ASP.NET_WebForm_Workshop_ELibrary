using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class PublisherManagement : System.Web.UI.Page
{
    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        PublisherGridView.DataBind();
    }

    protected void SearchPublisherIDButton_Click(object sender, EventArgs e)
    {
        getPublisherByID();
    }

    protected void AddPublisherButton_Click(object sender, EventArgs e)
    {
        if (checkPublisherExist())
        {
            Response.Write("<script>alert('Publisher ID already created.');</script>");
        }
        else
        {
            signUpNewPublisher();
        }
    }

    protected void UpdatePubisherButton_Click(object sender, EventArgs e)
    {
        if (checkPublisherExist())
        {
            updatePublisher();
        }
        else
        {
            Response.Write("<script>alert(\"Publisher haven't create.\");</script>");
        }
    }

    protected void DeletePublisherButton_Click(object sender, EventArgs e)
    {
        if (checkPublisherExist())
        {
            deletePublisher();
        }
        else
        {
            Response.Write("<script>alert(\"Publisher haven't create or ID goes wrong.\");</script>");
        }
    }

    void getPublisherByID()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand(@"SELECT publisher_name FROM publisher_master_table WHERE publisher_id = @publisher_id", conn); //+ PublisherIDTextBox.Text.Trim() + "';", conn);
            sqlCmd.Parameters.AddWithValue("publisher_id", PublisherIDTextBox.Text.Trim());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            

            if (dt.Rows.Count >= 1)
            {
                PublisherNameTextBox.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid publisher ID.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    bool checkPublisherExist()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查PublisherID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT publisher_id FROM publisher_master_table WHERE publisher_id = '" + PublisherIDTextBox.Text.Trim() + "'", conn);
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

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@publiser_id", PublisherIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Publisher has exist!');</script>");
            clearTextBox();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        return false;
    }

    void signUpNewPublisher()
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
                "INSERT INTO publisher_master_table"
                + "(publisher_id, publisher_name)"
                + "VALUES(@publisher_id, @publisher_name)", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@publisher_id", PublisherIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.Parameters.AddWithValue("@publisher_name", PublisherNameTextBox.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Add publisher successful!');</script>");
            clearTextBox();
            PublisherGridView.DataBind(); //Grid auto refresh after insert data
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void deletePublisher()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //DELETE 語法 
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM publisher_master_table WHERE publisher_id = @publisher_id", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@publisher_id", PublisherIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Publisher delete successful!');</script>");
            clearTextBox();
            PublisherGridView.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updatePublisher()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //UPDATE 語法 
            SqlCommand sqlCmd = new SqlCommand(
                "UPDATE publisher_master_table SET "
                + "publisher_name = @publisher_name WHERE publisher_id = '" + PublisherIDTextBox.Text.Trim() + "'", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@publisher_name", PublisherNameTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Publisher update successful!');</script>");
            clearTextBox();
            PublisherGridView.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void clearTextBox()
    {
        PublisherIDTextBox.Text = "";
        PublisherNameTextBox.Text = "";
    }

    
}