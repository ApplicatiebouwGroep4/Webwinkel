using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Winkelwagen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void GrdWinkelwagen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {

    }
    protected void GrdWinkelwagen_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

    }
    protected void GrdWinkelwagen_RowEditing(object sender, GridViewEditEventArgs e)
    {

    }
    protected void GrdWinkelwagen_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {

    }
    protected void BestelButton_Click(object sender, EventArgs e)
    {

    }
    protected void Verder_winkelenButton_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Catalogus.aspx");
    }
}