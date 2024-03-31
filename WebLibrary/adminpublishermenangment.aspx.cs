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
    public partial class adminauthormenangment : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (check_publisher_exist())
            {
                Response.Write("<script>alert('Publisher already exist with this ID');</script>");

            }
            else
            {
                add_publisher();
            }
        }

        bool check_publisher_exist() {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
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

        void add_publisher()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO publisher_master_tbl(publisher_id, publisher_name) values(@publisher_id, @publisher_name)", con);

                cmd.Parameters.AddWithValue("@publisher_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@publisher_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Publisher added successful');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE publisher_master_tbl SET publisher_name= '" + TextBox2.Text.Trim() + "' WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Publisher updated successful');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("DELETE FROM publisher_master_tbl WHERE publisher_id = '" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Publisher deleted successful');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * from publisher_master_tbl where publisher_id='" + TextBox1.Text.Trim() + "';", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count >= 1)
                {
                    TextBox2.Text = dt.Rows[0][1].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Publisher ID');</script>");
                }


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }
    }
}