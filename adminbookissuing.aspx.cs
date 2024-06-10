using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LMS
{
    public partial class adminbookissuing : System.Web.UI.Page
    {
        String strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataBind();
        }

        //GO Button
        protected void Button1_Click(object sender, EventArgs e)
        {
            if (checkUserandBookExists())
            {
                filluserandbookdetails();
            }
            else
            {

            }


        }

        //Issue Button
        protected void Button2_Click(object sender, EventArgs e)
        {
            if (checkUserandBookExists())
            {
                if (checkifBookExists())
                {
                    Response.Write("<script>alert('The book is out of stock.');</script>");
                }
                else
                {
                    if (checkifIssueEntryExists())
                    {
                        Response.Write("<script>alert('Issue Entry already exists.');</script>");
                    }
                    else
                    {
                        addinIssueTable();
                    }

                }

                clearForm();
            }
            else
            {
                Response.Write("<script>alert('Check user and book IDs');</script>");
            }
        }

        //Return Button
        protected void Button4_Click(object sender, EventArgs e)
        {
            if (checkifIssueEntryExists())
            {
                returnbook();
            }
            else
            {
                Response.Write("<script>alert('Issue entry does not exist.');</script>");
            }
            clearForm();
        }

        void returnbook()
        {
            try
            {

                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("DELETE FROM book_issue_tbl WHERE book_id='" + TextBox1.Text.Trim() + "' AND member_id='" + TextBox2.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock+1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('Returned Successfully');</script>");
                con.Close();
                GridView1.DataBind();
                clearForm();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        bool checkifBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox2.Text.Trim() + "' AND current_stock > 0", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

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
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void addinIssueTable()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO book_issue_tbl(member_id, member_name, book_id, book_name, issue_date, due_date) VALUES (@member_id, @member_name, @book_id, @book_name, @issue_date, @due_date)", con);

                cmd.Parameters.AddWithValue("@member_id", TextBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@member_name", TextBox3.Text.Trim());
                cmd.Parameters.AddWithValue("@book_id", TextBox1.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", TextBox4.Text.Trim());
                cmd.Parameters.AddWithValue("@issue_date", TextBox5.Text.Trim());
                cmd.Parameters.AddWithValue("@due_date", TextBox6.Text.Trim());

                cmd.ExecuteNonQuery();

                cmd = new SqlCommand("UPDATE book_master_tbl SET current_stock = current_stock-1 WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                cmd.ExecuteNonQuery();

                con.Close();
                GridView1.DataBind();
                clearForm();

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }

        void filluserandbookdetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                TextBox3.Text = dt.Rows[0]["full_name"].ToString();


                cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                da.Fill(dt);
                TextBox4.Text = dt.Rows[0]["book_name"].ToString();


            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");

            }
        }

        bool checkifIssueEntryExists()
        {

            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id='" + TextBox2.Text.Trim() + "' AND book_id='" + TextBox1.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;



            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        bool checkUserandBookExists()
        {
            bool user = false;
            bool book = false;
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + TextBox2.Text.Trim() + "'", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();

                da.Fill(dt);
                if (dt.Rows.Count > 0)
                    user = true;

                cmd = new SqlCommand("SELECT * FROM book_master_tbl WHERE book_id='" + TextBox1.Text.Trim() + "'", con);
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();

                da.Fill(dt);

                if (dt.Rows.Count > 0)
                    book = true;

                if (user == false)
                {
                    Response.Write("<script>alert('User does not exist.');</script>");
                    clearForm();
                    return false;
                }
                else if (book == false)
                {
                    Response.Write("<script>alert('Book does not exist.');</script>");
                    clearForm();
                    return false;
                }
                else
                {
                    return true;
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }

        void clearForm()
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = null;
            TextBox4.Text = null;
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                        e.Row.BorderColor = System.Drawing.Color.PaleVioletRed;
                        
                    }

                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }



        }
    }


}