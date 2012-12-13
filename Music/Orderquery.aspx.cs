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

public partial class Orderquery : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
        SqlCommand cmd = null;        
        CheckBox MychBox;
        foreach (GridViewRow G in GridView1.Rows)
        {
            MychBox = (CheckBox)G.FindControl("CheckBox1");
            if (MychBox.Checked)
            {
                cmd = new SqlCommand("UPDATE PurchaseItems SET Buy='是' WHERE PurcID=@PurcID", cn);                
                cmd.Parameters.Add("@PurcID", SqlDbType.Int).Value = GridView1.DataKeys[G.RowIndex].Value;                
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
            }

        }
        Response.Redirect("Download.aspx");
    }
}
