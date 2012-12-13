using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


public partial class Manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["Name"] == null)
        {
            Response.Redirect("Default.aspx");
        }
    }
    protected void fbit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.FileName == "" || FileUpload1.FileName == null)
            return;
        string File_N = FileUpload1.FileName.ToString();
        string[] File_Path = File_N.Split('\\');
        File_N = File_Path[File_Path.Length - 1];
        string webDir = Server.MapPath("Play/.") + "\\music\\";
        if (!Directory.Exists(webDir))
            Directory.CreateDirectory(webDir);
        FileUpload1.SaveAs(webDir + File_N);
        DataDataContext Mdata = new DataDataContext();
        var yy = new Music();
        yy.Name = name.Text;
        yy.Who = who.Text;
        yy.Url = "/Play/music/" + File_N;
        yy.Date = DateTime.Now;
        Mdata.Music.InsertOnSubmit(yy);
        Mdata.SubmitChanges();
        GridView1.DataBind();
        name.Text = "";
        who.Text = "";   
    }
    protected void Cancel_Click(object sender, EventArgs e)
    {
        name.Text = "";
        who.Text = "";        
    }
}