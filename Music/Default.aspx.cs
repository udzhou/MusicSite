using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
using System.IO;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
   
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = null;
        if (TextBox3.Text == ""&&TextBox4.Text=="")
        {
            cmd = new SqlCommand("SELECT * FROM Music", cn);
        }
        if (TextBox3.Text != "" && CheckBox3.Checked == true &&TextBox4.Text=="")
        {
            cmd = new SqlCommand("SELECT * FROM Music WHERE Name LIKE @Name", cn);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = "%" + TextBox3.Text + "%";
        }
        if (TextBox3.Text != "" && CheckBox3.Checked == false && TextBox4.Text == "")
        {
            cmd = new SqlCommand("SELECT * FROM Music WHERE Name=@Name", cn);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = TextBox3.Text;
        }
        if (TextBox4.Text != "" && CheckBox3.Checked == true && TextBox3.Text == "")
        {
            cmd = new SqlCommand("SELECT * FROM Music WHERE Who LIKE @Who", cn);
            cmd.Parameters.Add("@Who", SqlDbType.NVarChar, 20).Value = "%" + TextBox4.Text + "%";
        }
        if (TextBox4.Text != "" && CheckBox3.Checked == false && TextBox3.Text == "")
        {
            cmd = new SqlCommand("SELECT * FROM Music WHERE Who=@Who", cn);
            cmd.Parameters.Add("@Who", SqlDbType.NVarChar, 20).Value = TextBox4.Text;
        }
        if (TextBox4.Text != "" && TextBox3.Text != "")
        {
            cmd = new SqlCommand("SELECT * FROM Music WHERE Who=@Who and Name=@Name", cn);
            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50).Value = TextBox3.Text;
            cmd.Parameters.Add("@Who", SqlDbType.NVarChar, 20).Value = TextBox4.Text;
        }
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();       
        cn.Open();
        da.Fill(ds);
        cn.Close();
        Label7.Text = "歌曲数"+ds.Tables[0].Rows.Count.ToString();
        GridView1.DataSourceID = "";
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {        
        if (TextBox5.Text == "udzhou" || TextBox5.Text == "shu" || TextBox5.Text == "zhou")
        {
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Admin WHERE Name=@Name AND Password=@Password", cn);

            cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 20).Value = TextBox5.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 8).Value = TextBox6.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            cn.Open();

            da.Fill(ds);

            cn.Close();
            if (ds.Tables[0].Rows.Count == 1)
            {
                Response.Cookies["Name"].Value = TextBox5.Text; //写Cookie用Response.Cookies
                Response.Cookies["Name"].Expires = DateTime.Now.AddDays(Int32.Parse(dpExpires.SelectedValue));

                if (CheckBox4.Checked)
                {
                    Response.Cookies["Password"].Value = TextBox6.Text;
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(Int32.Parse(dpExpires.SelectedValue));
                }
                else
                {
                    Response.Cookies["Password"].Value = "";
                }

                Session["Name"] = TextBox5.Text;
                Session["UserID"] = ds.Tables[0].Rows[0][0].ToString().Trim();
                Response.Redirect("Manage.aspx");
            }
            else
            {
                //Response.Write("<script>alert('登录失败')</script>");

                Literal lit = new Literal();
                lit.Text = "<script>alert('登录失败')</script>";
                Page.Controls.Add(lit);

            }
        }
        else
        {
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE UserName=@UserName AND Password=@Password", cn);

            cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value = TextBox5.Text;
            cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 8).Value = TextBox6.Text;

            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataSet ds = new DataSet();

            cn.Open();

            da.Fill(ds);

            cn.Close();
            if (ds.Tables[0].Rows.Count == 1)
            {
                Response.Cookies["Name"].Value = TextBox5.Text; //写Cookie用Response.Cookies
                Response.Cookies["Name"].Expires = DateTime.Now.AddDays(Int32.Parse(dpExpires.SelectedValue));
               
                if (CheckBox4.Checked)
                {
                    Response.Cookies["Password"].Value = TextBox6.Text;
                    Response.Cookies["Password"].Expires = DateTime.Now.AddDays(Int32.Parse(dpExpires.SelectedValue));
                }
                else
                {
                    Response.Cookies["Password"].Value = "";
                }
                Session["UserID"] = ds.Tables[0].Rows[0][0].ToString().Trim();
                Session["Name"] = TextBox5.Text;
                Response.Redirect("Purchase.aspx");                
            }
            else
            {
                //Response.Write("<script>alert('登录失败')</script>");

                Literal lit = new Literal();
                lit.Text = "<script>alert('登录失败')</script>";
                Page.Controls.Add(lit);

            }
        }
    }
    protected void Button6_Click(object sender, EventArgs e)
    {
        string fileName = "林俊杰 - 不存在的情人.mp3";
        string filePath = Server.MapPath("Play/music/林俊杰 - 不存在的情人.mp3");

        FileInfo fileInfo = new FileInfo(filePath);
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.AddHeader("Content-Transfer-Encoding", "binary");
        Response.ContentType = "application/octet-stream";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("utf-8");
        Response.WriteFile(fileInfo.FullName);
        Response.Flush();
        Response.End();
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        Response.Redirect("Register.aspx");
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "play")
        {
            int rowIndex = Int32.Parse(e.CommandArgument.ToString());
            int SongID = int.Parse(GridView1.Rows[rowIndex].Cells[0].Text.Trim());
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Url FROM Music WHERE ID=@ID", cn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SongID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cn.Open();
            da.Fill(ds);
            cn.Close();
            Label8.Text = ds.Tables[0].Rows[0][0].ToString().Substring(11);
            Literal lit = new Literal();
            lit.Text = "<script>var yinyue=document.getElementById('music'); yinyue.src='Play/music/林俊杰 - 不存在的情人.mp3';yinyue.play()</script>";
            Page.Controls.Add(lit);            
        }
    }
}
