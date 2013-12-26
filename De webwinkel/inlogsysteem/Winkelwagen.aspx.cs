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
    protected void VerwijderButton_Click(object sender, EventArgs e)
    {
        //verder winkelen wordt verwijst naar de catalogus pagina....
        Response.Redirect("~/index.aspx");
    }
    protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        DropDownList Aantal = new DropDownList();
        for (int i = 1; i < 7; i++)
        {
            Aantal.Items.Add(new ListItem(i.ToString(), i.ToString()));
        }
    }
    protected void verwijderen_Click(object sender, EventArgs e)
    {
        // een loop door alle rows in de GridView....
        foreach (GridViewRow Row in GridView1.Rows)
        {
            CheckBox checkbox = (CheckBox)Row.FindControl("verwijder");

            // check als de checkbox is aangevlinkt....
            if (checkbox.Checked)
            {
                // ophalen de productID.....
                int productID = Convert.ToInt32(GridView1.DataKeys[Row.RowIndex].Values);

                // gebruik de opgehaald value van de productID met de delete command..
                SqlDataSource.DeleteParameters["productID"].DefaultValue = productID.ToString();
                SqlDataSource.Delete();
            }
        }
    }
}