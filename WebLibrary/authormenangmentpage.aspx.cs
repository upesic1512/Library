﻿using System;
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
    public partial class authormenangmentpage : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["LibraryDBConnectionString"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            GridView1.DataBind();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (check_author_exist())
            {
                Response.Write("<script>alert('Author already exist with this ID');</script>");

            }
            else
            {
                add_author();
            }

        }
        bool check_author_exist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "';", con);
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
        void add_author()
        {

            try
            {

                SqlConnection con = new SqlConnection(strcon);



                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("INSERT INTO author_master_tbl(author_id, author_name) values(@author_id, @author_name)", con);

                cmd.Parameters.AddWithValue("@author_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@author_name", TextBox2.Text.Trim());


                cmd.ExecuteNonQuery();



                con.Close();
                Response.Write("<script>alert('Author added successful');</script>");
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
            if (check_author_exist())
            {
                delete_author(); 

            }
            else
            {
                Response.Write("<script>alert('Author doesnt exist');</script>");
            }
        }
        void delete_author()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("DELETE FROM author_master_tbl WHERE author_id = '" + TextBox1.Text.Trim() + "'", con);
                 cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Author deleted successful');</script>");
                clearForm();
                GridView1.DataBind();
            }
            catch (Exception ex)
            {

                Response.Write("<script>alert (`" + ex.Message + "`);</script>");
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (check_author_exist())
            {
                update_author();

            }
            else
            {
                Response.Write("<script>alert('Author doesnt exist');</script>");
            }
        }

        void update_author()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();

                }
                SqlCommand cmd = new SqlCommand("UPDATE author_master_tbl SET author_name = '"+ TextBox2.Text.Trim()+"' WHERE author_id = '"+TextBox1.Text.Trim()+"'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                Response.Write("<script>alert('Author updated successful');</script>");
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("SELECT * from author_master_tbl where author_id='" + TextBox1.Text.Trim() + "';", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count >= 1)
                    {
                        TextBox2.Text = dt.Rows[0][1].ToString();
                    }
                    else
                    {
                        Response.Write("<script>alert('Invalid Author ID');</script>");
                    }


                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");

                }
            
        }
    }
}