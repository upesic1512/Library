using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLibrary
{
    public partial class adminbookinventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (check_book_exist())
            {
                Response.Write("<script>alert('Book already exist with this ID');</script>");

            }
            else
            {
                add_book();
            }
        }
        
        bool check_book_exist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from book_master_tbl where member_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    con.Close();
                    return true;
                }
                else
                {
                    con.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
                return false;
            }
        }

        void add_book()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO book_master_tbl(book_id,book_name,author_name,publisher_name," +
                    "publish_date,language,edition,book_cost,no_pages,book_description,actual_stock,current_stock,book_img_url)" +
                    " values(@book_name,book_id,@author_name,@publlisher_name,@publish_date,@language,@edition,@book_cost,@no_pages,@book_description,@actual_stock,@current_stock,@book_img_url)", con);

                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@language", DropDownList1.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", TextBox6.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", TextBox7.Text.Trim());
                cmd.Parameters.AddWithValue("@no_pages", TextBox5.Text.Trim());
                //cmd.Parameters.AddWithValue("@book_description", TextBox8.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", TextBox9.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", "pending");
                cmd.Parameters.AddWithValue("@book_img_url", "pending");
                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Sign Up Successful. Go to User Login to Login');</script>");
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
            }
        }
    }
}