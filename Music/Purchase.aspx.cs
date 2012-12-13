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


public partial class purchase : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("Default.aspx");
        }        
        Label8.Text = Session["Name"] + "您好," + "欢迎光临";
        Label9.Text = Session["UserID"] + " ";
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = null;
        if (TextBox3.Text == "" && TextBox4.Text == "")
        {
            cmd = new SqlCommand("SELECT * FROM Music", cn);
        }
        if (TextBox3.Text != "" && CheckBox3.Checked == true && TextBox4.Text == "")
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
        Label7.Text = "歌曲数" + ds.Tables[0].Rows.Count.ToString();
        GridView1.DataSourceID = "";
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }    
    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("INSERT INTO Purchase(UserID) VALUES(@UserID)", cn);
        cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = int.Parse(Label9.Text.Trim());
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        cmd = new SqlCommand("SELECT * FROM Purchase", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cn.Open();
        da.Fill(ds);
        cn.Close();
        int max = int.Parse(ds.Tables[0].Rows.Count.ToString().Trim()) - 1;
        int tPurcID = int.Parse(ds.Tables[0].Rows[max][0].ToString().Trim());
        CheckBox MychBox;        
        foreach (GridViewRow G in GridView1.Rows)
        {
            MychBox = (CheckBox)G.FindControl("CheckBox4");
            if (MychBox.Checked)
            {
                cmd = new SqlCommand("INSERT INTO PurchaseItems(PurcID,ID,Buy) VALUES(@PurcID,@ID,@Buy)", cn);
                cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = tPurcID;
                cmd.Parameters.Add("@ID", SqlDbType.Int).Value =GridView1.DataKeys[G.RowIndex].Value;
                cmd.Parameters.Add("@Buy", SqlDbType.NVarChar, 10).Value = "否";
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }              
            
        }       
        
        //Mstr = Mstr.Substring(0, 1);         
        Response.Redirect("Pay.aspx");                  
           
                      
                           
    }
    //public bool InsertPurc()
    //{
    //    SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
    //    SqlCommand cmd = new SqlCommand("INSERT INTO Purchase(UserID) VALUES(@UserID)", cn);
    //    cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = int.Parse(Label9.Text.Trim());
    //    cn.Open();
    //    cmd.ExecuteNonQuery();
    //    cn.Close();
    //    return true;
    //}
}
