using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebLibrary
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                
                if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello" + Session["username"].ToString();

                    LinkButton6.Visible = true;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = false;
                    LinkButton2.Visible = false;

                    LinkButton3.Visible = true;
                    LinkButton7.Visible = true;
                    LinkButton7.Text = "Hello Admin";

                    LinkButton6.Visible = false;
                    LinkButton11.Visible = true;
                    LinkButton12.Visible = true;
                    LinkButton8.Visible = true;
                    LinkButton9.Visible = true;
                    LinkButton10.Visible = true;
                }
                else
                {
                    LinkButton1.Visible = true;
                    LinkButton2.Visible = true;

                    LinkButton3.Visible = false;
                    LinkButton7.Visible = false;

                    LinkButton6.Visible = true;
                    LinkButton11.Visible = false;
                    LinkButton12.Visible = false;
                    LinkButton8.Visible = false;
                    LinkButton9.Visible = false;
                    LinkButton10.Visible = false;
                }
            }
            catch
            {

            }

        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Session["username"] = "";
            Session["role"] = "";
            Session["status"] = "";
            Session["full_name"] = "";

            LinkButton1.Visible = true;
            LinkButton2.Visible = true;

            LinkButton3.Visible = false;
            LinkButton7.Visible = false;

            LinkButton6.Visible = true;
            LinkButton11.Visible = false;
            LinkButton12.Visible = false;
            LinkButton8.Visible = false;
            LinkButton9.Visible = false;
            LinkButton10.Visible = false;
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            Response.Redirect("authormenangmentpage.aspx");
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookissuingpage.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignuppage.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("ViewBooks.aspx");

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("loginpage.aspx");
        }

        protected void LinkButton12_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminpublishermenangment.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("bookinventory.aspx");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("usermenangment.aspx");
        }
    }
}