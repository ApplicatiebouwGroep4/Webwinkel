using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterWebwinkel : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void knop_Zoek_Click(object sender, EventArgs e)
    {
        string url = string.Format("~/Catalogus.aspx?search={0}", veld_Zoek.Text);
        Response.Redirect(url);
    }
    
}
