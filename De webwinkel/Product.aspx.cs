using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.Configuration;

public partial class Product : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Genereer_Productdetails();
        Genereer_Aanbiedingen();
    }

    protected void Genereer_Productdetails()
    {
        string stringquery = SQL_Injection_Security(Request.QueryString["productID"]);
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;

        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"SELECT [productnaam], [productomschrijving], [productcategorie], [productprijs], [productplaatje], [voorraad] FROM [PRODUCT] WHERE [productID] = @productID;";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("productID", stringquery);

        OleDbConnection databaseConnectie = null;
        try
        {
            databaseConnectie = new OleDbConnection(ConnectionString);
        }
        catch
        {
            lbl_titel.Text = "Er kon geen verbinding gemaakt worden met de database.";
        }

        cmd.Connection = databaseConnectie;
        databaseConnectie.Open();
        OleDbDataReader dr = cmd.ExecuteReader();

        if (!dr.Read())
        {
            return;
        }

        string productnaam = dr.GetString(0);
        string productomschrijving = dr.GetString(1);
        string productcategorie = dr.GetString(2);
        decimal productprijs = dr.GetDecimal(3);
        string productplaatje = dr.GetString(4);
        int voorraad = dr.GetInt32(5);

        databaseConnectie.Dispose();
        databaseConnectie.Close();

        lbl_titel.Text = productnaam;
        img_productplaatje.ImageUrl = productplaatje;
        lbl_prijs.Text = "€" + productprijs.ToString();
        lbl_omschrijving.Text = productomschrijving;
        lbl_categorie.Text = productcategorie;
        lbl_voorraad.Text = voorraad.ToString();
    }

    protected string SQL_Injection_Security(string zoekgegeven)
    {
        string zoekgegeven_secure = "";

        for (int i = 0; i < zoekgegeven.Length; i++)
        {
            if (zoekgegeven[i] != '\"')
            {
                zoekgegeven_secure += zoekgegeven[i];
            }
            else
            {
                i = zoekgegeven.Length;
            }
        }

        return (zoekgegeven_secure);
    }

    protected void Genereer_Aanbiedingen()
    {
        int productID_1, productID_2, productID_3, productID_4, productID_5;
        Random rnd = new Random();

        productID_1 = rnd.Next(1, 20);
        productID_2 = rnd.Next(1, 20);
        productID_3 = rnd.Next(1, 20);
        productID_4 = rnd.Next(1, 20);
        productID_5 = rnd.Next(1, 20);

        SqlDataSource1.SelectCommand = "SELECT [productID], [productnaam], [productplaatje], [productprijs] FROM [PRODUCT] WHERE [productID] IN (" + productID_1 + "," + productID_2 + "," + productID_3 + "," + productID_4 + "," + productID_5 + ");";
    }
    
    protected void productlink_Click(object sender, EventArgs e)
    {
        string productID = ((LinkButton)sender).CommandArgument;
        string url = string.Format("~/Product.aspx?productID={0}", productID);

        Response.Redirect(url);
    }

    protected void productplaatjeLabel_Click(object sender, ImageClickEventArgs e)
    {
        string productID = ((ImageButton)sender).CommandArgument;
        string url = string.Format("~/Product.aspx?productID={0}", productID);

        Response.Redirect(url);
    }
}
