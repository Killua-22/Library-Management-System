using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class adminmembermanagement : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO Button
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            
            if (checkMemberExists(dt))
            {
                TextBox2.Text = dt.Rows[0][0].ToString(); //fullname
                TextBox7.Text = dt.Rows[0][10].ToString(); //status
                TextBox8.Text = dt.Rows[0][1].ToString(); //dob
                TextBox3.Text = dt.Rows[0][2].ToString(); //contact no
                TextBox4.Text = dt.Rows[0][3].ToString(); //email
                TextBox9.Text = dt.Rows[0][4].ToString(); //state
                TextBox10.Text = dt.Rows[0][5].ToString(); //city
                TextBox11.Text = dt.Rows[0][6].ToString(); //pincode
                TextBox6.Text = dt.Rows[0][7].ToString(); //address
            }
            else
            {
                TextBox2.Text = "";//fullname
                TextBox7.Text = ""; //status
                TextBox8.Text = ""; //dob
                TextBox3.Text = "";//contact no
                TextBox4.Text = ""; //email
                TextBox9.Text = ""; //state
                TextBox10.Text = ""; //city
                TextBox11.Text = ""; //pincode
                TextBox6.Text = ""; //address
            }
 
        }

        //Online Button
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            changeMemberStatus("Active");
            if(TextBox1.Text != "") TextBox7.Text = "Active";
        }

        //Pending Button
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            changeMemberStatus("pending");
            if (TextBox1.Text != "")
                TextBox7.Text = "pending";
        }

        //Defaulter Button
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            changeMemberStatus("Deactive");
            if (TextBox1.Text != "")
                TextBox7.Text = "Deactive";
        }



        void changeMemberStatus(String status)
        {
            DataTable dt = new DataTable();
            if (checkMemberExists(dt))
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE member_master_tbl SET account_status='"+status+"' WHERE member_id='" + TextBox1.Text.Trim() + "'", con);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                    
                }
            }
        }

        bool checkMemberExists(DataTable dt)
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='"+TextBox1.Text.Trim()+"'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(dt);

                if (dt.Rows.Count > 0)
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
                Response.Write("<script>alert('"+ex.Message+"');</script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = ""; //Member ID
            TextBox2.Text = "";//fullname
            TextBox7.Text = ""; //status
            TextBox8.Text = ""; //dob
            TextBox3.Text = "";//contact no
            TextBox4.Text = ""; //email
            TextBox9.Text = ""; //state
            TextBox10.Text = ""; //city
            TextBox11.Text = ""; //pincode
            TextBox6.Text = ""; //address
        }

        // Clear Form Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            clearForm();
        }

        //Delete User
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkMemberExists(dt))
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }

                    SqlCommand cmd = new SqlCommand("DELETE FROM member_master_tbl WHERE member_id='"+TextBox1.Text.Trim()+"'", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    GridView1.DataBind();
                    clearForm();
                }catch(Exception ex)
                {
                    Response.Write("<script>alert('"+ex.Message+"');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
                clearForm();
            }
        }
    }
}