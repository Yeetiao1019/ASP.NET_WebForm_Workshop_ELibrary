using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class BookInventory : System.Web.UI.Page
{

    string strConn = ConfigurationManager.ConnectionStrings["conn"].ConnectionString;

    protected void Page_Load(object sender, EventArgs e)
    {
        fillAuthorPublisherValues();
        BookInventoryGridView.DataBind();
    }

    protected void SearchBookIDLinkButton_Click(object sender, EventArgs e)
    {

    }

    protected void AddBookDetailButton_Click(object sender, EventArgs e)
    {
        if (checkBookExist())
        {
            Response.Write("<script>alert('Book already exist.');</script>");
        }
        else
        {
            addNewBook();
        }
    }

    protected void UpdateBookDetailButton_Click(object sender, EventArgs e)
    {

    }

    protected void DeleteBookDetailButton_Click(object sender, EventArgs e)
    {

    }

    void fillAuthorPublisherValues()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            SqlCommand sqlCmd = new SqlCommand(@"SELECT author_name FROM author_master_table;", conn);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(sqlCmd);
            DataTable dt = new DataTable();
            dataAdapter.Fill(dt);
            AuthorNameDropDownList.DataSource = dt;
            AuthorNameDropDownList.DataValueField = "author_name";
            AuthorNameDropDownList.DataBind();

            sqlCmd = new SqlCommand("SELECT publisher_name FROM publisher_master_table;", conn);
            dataAdapter = new SqlDataAdapter(sqlCmd);
            dt = new DataTable();
            dataAdapter.Fill(dt);
            PublisherNameDropDownList.DataSource = dt;
            PublisherNameDropDownList.DataValueField = "publisher_name";
            PublisherNameDropDownList.DataBind();
        }
        catch(Exception ex)
        {

        }
    }

    bool checkBookExist()
    {
        try
        {
            SqlConnection conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
            }

            //檢查AuthorID是否已被建立
            SqlCommand sqlCmd = new SqlCommand("SELECT book_id FROM book_master_table WHERE book_id = '" + BookIDTextBox.Text.Trim() + "'", conn);
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
            sqlCmd.Parameters.AddWithValue("@author_id", BookIDTextBox.Text.Trim()); //Trim 移除前後空白
            sqlCmd.ExecuteNonQuery();
            conn.Close();
            Response.Write("<script>alert('Author has exist!');</script>");
            
        }
        catch (Exception ex)
        {
            Response.Write("<script>alert('" + ex.Message + "');</script>");
        }
        return false;
    }

    void addNewBook()
    {

    }

}