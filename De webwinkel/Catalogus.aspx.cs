using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

public partial class Producten : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string zoekgegeven;

        //Probeert eerst de zoekfunctie te lezen.
        if(Request.QueryString["search"] != null)
        {
            //leest de querystring en stuurt de gemaakte sqlquery naar de SqlDataSource van de listview.
            zoekgegeven = Request.QueryString["search"];
            SqlDataSource1.SelectCommand = "SELECT [productID], [productnaam], [productplaatje], [productprijs] FROM [PRODUCT] WHERE [productomschrijving] LIKE \"%" + zoekgegeven + "%\";";
            listview_Catalogus.DataBind();
            
            lbl_informatie.Text = "U heeft gezocht op: \"" + zoekgegeven + "\"";
        }
        
        //Als de zoekfunctie leeg is probeert hij de categorie te lezen.
        else
        {
            if(Request.QueryString["categorie"] != null)
            {
                //leest de querystring en stuurt de gemaakte sqlquery naar de SqlDataSource van de listview.
                zoekgegeven = Request.QueryString["categorie"];
                SqlDataSource1.SelectCommand = "SELECT [productID], [productnaam], [productplaatje], [productprijs] FROM [PRODUCT] WHERE [productcategorie] = \"" + zoekgegeven + "\";";
                listview_Catalogus.DataBind();
                
                lbl_informatie.Text = zoekgegeven + ", hier moet nog tekst en een plaatje komen gebaseerd op de categorie! (kunnen we uit de database wel halen denk ik)";
            }
            //Als er ook geen categorie geselecteerd is, dan laadt hij alle producten in zoals al ingesteld staat in de datasource.
            else
            {
                lbl_informatie.Text = "Lorem ipsum bla bla bla, hier komt algemeen tekst te staan.";
            }
        }
    }

    protected void productplaatjeLabel_Click(object sender, ImageClickEventArgs e)
    {
        string productID = ((ImageButton)sender).CommandArgument;
        string url = string.Format("~/Product.aspx?productID={0}", productID);

        Response.Redirect(url);
    }
}