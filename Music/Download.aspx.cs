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

public partial class Download : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "download")
        {
            int rowIndex = Int32.Parse(e.CommandArgument.ToString());
            int SongID = int.Parse(GridView1.Rows[rowIndex].Cells[0].Text.Trim());
            SqlConnection cn = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=Music;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("SELECT Url,Name FROM Music WHERE ID=@ID", cn);
            cmd.Parameters.Add("@ID", SqlDbType.Int).Value = SongID;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            cn.Open();
            da.Fill(ds);
            cn.Close();
            string strPath = ds.Tables[0].Rows[0][0].ToString();
            string strName = ds.Tables[0].Rows[0][0].ToString();
            download(strPath,strName);
        }
    }
    private void download(string strName, string strPath)
    {
        string fileName = strName;//客户端保存的文件名
        string filePath = Server.MapPath(strPath);//路径 
        //以字符流的形式下载文件
        FileStream fs = new FileStream(filePath, FileMode.Open);
        byte[] bytes = new byte[(int)fs.Length];
        fs.Read(bytes, 0, bytes.Length);
        fs.Close();
        Response.ContentType = "application/octet-stream";
        //通知浏览器下载文件而不是打开
        Response.AddHeader("Content-Disposition", "attachment;  filename=" + HttpUtility.UrlEncode(fileName, System.Text.Encoding.UTF8));
        Response.BinaryWrite(bytes);
        Response.Flush();
        Response.End();
    }
}
