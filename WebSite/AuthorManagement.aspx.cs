using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AuthorManagement : System.Web.UI.Page
{
    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        AuthorGridView.DataBind();
    }

    protected void AddAuthorButton_Click(object sender, EventArgs e)
    {
        if (checkAuthorExist())
        {
            Response.Write("<script>alert('Author ID already created.');</script>");
        }
        else
        {
            signUpNewAuthor();   
        }
    }

    protected void UpdateAuthorButton_Click(object sender, EventArgs e)
    {
        if (checkAuthorExist())
        {
            updateAuthor();
        }
        else
        {
            Response.Write("<script>alert(\"Author haven\'t create.\");</script>");
        }
    }

    protected void DeleteAuthorButton_Click(object sender, EventArgs e)
    {
        if (checkAuthorExist())
        {
            deleteAuthor();
        }
        else
        {
            Response.Write("<script>alert(\"Author haven't create or ID goes wrong.\");</script>");
        }
    }

    protected void SearchAuthorIDButton_Click(object sender, EventArgs e)
    {
        getAuthorByID();
    }

    void getAuthorByID()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT author_name FROM author_master_table WHERE author_id = '" + AuthorIDTextBox.Text.Trim() + "';", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);

            if (dt.Rows.Count >= 1)
            {
                AuthorNameTextBox.Text = dt.Rows[0][0].ToString();
            }
            else
            {
                Response.Write("<script>alert('Invalid author ID.');</script>");
            }
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    bool checkAuthorExist()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT author_id FROM author_master_table WHERE author_id = '" + AuthorIDTextBox.Text.Trim() + "'", conn);
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
            sqlCmd.Parameters.AddWithValue("@author_id", AuthorIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Author has exist!');</script>");
            clearForm();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        return false;
    }

    void signUpNewAuthor()
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
                "INSERT INTO author_master_table"
                + "(author_id, author_name)"
                + "VALUES(@author_id, @author_name)", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@author_id", AuthorIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.Parameters.AddWithValue("@author_name", AuthorNameTextBox.Text.Trim());
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Add author successful!');</script>");
            clearForm();
            AuthorGridView.DataBind(); //Grid auto refresh after insert data
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void deleteAuthor()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //DELETE 語法 
            SqlCommand sqlCmd = new SqlCommand("DELETE FROM author_master_table WHERE author_id = @author_id", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@author_id", AuthorIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Author delete successful!');</script>");
            clearForm();
            AuthorGridView.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void updateAuthor()
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
                "UPDATE author_master_table SET "
                + "author_name = @author_name WHERE author_id = '" + AuthorIDTextBox.Text.Trim() + "'", conn);

            //接收TextBox值
            sqlCmd.Parameters.AddWithValue("@author_name", AuthorNameTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Author update successful!');</script>");
            clearForm();
            AuthorGridView.DataBind();
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
    }

    void clearForm()
    {
        AuthorIDTextBox.Text = "";
        AuthorNameTextBox.Text = "";
    }
}