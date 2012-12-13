using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;



public partial class Play_Play : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Response.Write(Request.QueryString["Myid"].ToString());       
    }
    public string Mlm()
    {
        //string Mname = "Lm/" + User.Identity.Name.ToString()+ ".asx";
        string Mname = "Lm/" +"music.asx";
        DataDataContext Mdata = new DataDataContext();
        string Lmstr = "<asx VERSION=\"3.0\">\n";
        string[] Mytt = Request.QueryString["Myid"].ToString().Split(new char[] { ',' });
        var m = from o in Mdata.Music where Mytt.Contains(o.ID.ToString()) select new { o.Url };
        foreach (var t in m)
        {
            Lmstr += "<entry>\n";
            Lmstr += "<REF HREF=\"../" + t.Url.ToString() + "\"/>\n";
            Lmstr += "</entry>\n";
        }
        Lmstr += "</asx>";
        string file_path = Server.MapPath(Mname);
        StreamWriter fs = new StreamWriter(file_path, false);
        fs.WriteLine(Lmstr);
        fs.Close();
        return Mname;
    }
}