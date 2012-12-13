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

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");

        string sql = "";

        sql += " INSERT Users(UserName,Password)";

        sql += " VALUES(@UserName,@Password)";

        SqlCommand cmd = new SqlCommand(sql, cn);

        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 20).Value=TextBox1.Text;

        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 8).Value =TextBox2.Text;
        if (TextBox2.Text == TextBox3.Text)
        {
            try
            {
                cn.Open();

                cmd.ExecuteNonQuery();
                Response.Write("<script>alert('恭喜您注册成功！')</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('亲出错了哦！')</script>");
                Response.Write(ex.Message);
            }
        finally
            {
                cn.Close();
            }
        }
        else
        {
            Response.Write("<script>alert('密码不一致')</script>");
            cn.Close();
        }
        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TextBox1.Text = "";
        TextBox2.Text = "";
        TextBox3.Text = "";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }
}
