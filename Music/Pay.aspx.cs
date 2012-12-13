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


public partial class Pay : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("Default.aspx");
        }
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        int tPurcID = sPurcID();
        SqlCommand cmd = new SqlCommand("SELECT PurcID '订单号',Name '歌曲名',Price '价格',Buy '是否购买' FROM PurchaseItems,Music WHERE PurcID=@PurcID AND PurchaseItems.ID=Music.ID", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = tPurcID;
        cn.Open();
        da.Fill(ds);
        cn.Close();
        //GridView1.DataSourceID = "";
        GridView1.DataSource = ds;
        GridView1.DataBind();
    }
    public int sPurcID()
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("SELECT * FROM Purchase", cn);
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        DataSet ds = new DataSet();
        cn.Open();
        da.Fill(ds);
        cn.Close();
        int max = int.Parse(ds.Tables[0].Rows.Count.ToString().Trim()) - 1;
        int tPurcID = int.Parse(ds.Tables[0].Rows[max][0].ToString().Trim());
        return tPurcID;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("Orderquery.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int tPurcID = sPurcID();
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("UPDATE PurchaseItems SET Buy='是' WHERE PurcID=@PurcID", cn);
        cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = tPurcID;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        Response.Redirect("Download.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        int tPurcID = sPurcID();
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = new SqlCommand("DELETE FROM PurchaseItems WHERE PurcID=@PurcID", cn);
        cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = tPurcID;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        cmd = new SqlCommand("DELETE FROM Purchase WHERE PurcID=@PurcID", cn);
        cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = tPurcID;
        cn.Open();
        cmd.ExecuteNonQuery();
        cn.Close();
        Response.Redirect("Purchase.aspx");
    }
}
