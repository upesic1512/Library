using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;

namespace WebLibrary
{
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {

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

                SqlCommand cmd = new SqlCommand("select * from admin_master_tbl where admin_id='" + TextBox1.Text.Trim() + "' AND password='" + TextBox2.Text.Trim() + "'", con);


                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Response.Write("<script>alert('Login Successfull');</script>");
                        Session["username"] = dr.GetValue(0).ToString();
                        Session["role"] = "admin";
                        Session["full_name"] = dr.GetValue(2).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('Invalid credentials');</script>");
                }


            }
            catch (Exception ex)
            {


                Response.Write("<script>alert (`" + ex.Message + "`);</script>");

            }
        }
    }
}