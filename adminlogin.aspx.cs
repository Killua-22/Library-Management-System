using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class adminlogin : System.Web.UI.Page
    {
        
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);

                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("SELECT * FROM admin_login_tbl WHERE username='" + TextBox1.Text.Trim() + "' AND password= '" + TextBox2.Text.Trim() + "';", con);

                SqlDataReader da = cmd.ExecuteReader();


                if (da.HasRows)
                {
                    while (da.Read())
                    {
                        Response.Write("<script>alert('" + da.GetValue(0).ToString() + "');</script>");
                        Session["username"] = da.GetValue(0).ToString();
                        Session["fullname"] = da.GetValue(2).ToString();
                        Session["role"] = "admin";
                        //Session["status"] = da.GetValue(10).ToString();
                    }
                    Response.Redirect("homepage.aspx");
                }
                else
                {
                    Response.Write("<script>alert('No');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}