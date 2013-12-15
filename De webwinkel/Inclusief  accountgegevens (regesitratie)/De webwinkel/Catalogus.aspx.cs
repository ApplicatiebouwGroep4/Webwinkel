using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Producten : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string zoekgegeven;
        //probeert eerst de zoekfunctie te lezen.
        try
        {
            zoekgegeven = Request.QueryString["search"];
            Zoek_Omschrijving(zoekgegeven);
        }
        //als de zoekfunctie leeg is probeert hij de categorie te lezen.
        catch
        {
            try
            {

            }
            //als er ook geen categorie geselecteerd is laad hij alle producten in.
            catch
            {

            }
        }
    }

    protected void Zoek_Omschrijving(string zoekgegeven)
    {
    }
}