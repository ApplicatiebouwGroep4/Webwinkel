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
        //Deze methode vraagt gegevens aan de database en bouwt de productpagina op.
        Genereer_Productdetails();
        //Deze methode genereert een lijstje van random producten die onderaan de pagina worden getoond.
        Genereer_Aanbiedingen();
    }

    protected void Genereer_Productdetails()
    {
        //Controleert of de opgegeven stringquery geen SQL Injection bevat.
        string stringquery = SQL_Injection_Security(Request.QueryString["productID"]);
        //Leest de ConnectionString.
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;

        //Bereidt de SQL-Query voor.
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"SELECT [productnaam], [productomschrijving], [productcategorie], [productprijs], [productplaatje], [voorraad] FROM [PRODUCT] WHERE [productID] = @productID;";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("productID", stringquery);

        //Controleert of er wel verbinding met de database gemaakt kan worden. Zo niet, geeft hij een melding dat de er geen verbinding gemaakt kon worden en wordt het laden van de productpagina gestopt.
        OleDbConnection databaseConnectie = null;
        try
        {
            databaseConnectie = new OleDbConnection(ConnectionString);
        }
        catch
        {
            lbl_titel.Text = "Er kon geen verbinding gemaakt worden met de database.";
            return;
        }

        //Maakt verbinding met de database en voert de SQL-querry uit.
        cmd.Connection = databaseConnectie;
        databaseConnectie.Open();
        OleDbDataReader dr = cmd.ExecuteReader();

        //Controleert of het opgegeven productID wel bestaat door te kijken of de database wat teruggestuurd heeft. 
        //Zo niet, dan krijgt de bezoeker een melding dat het product niet gevonden kon worden en stopt de pagina met het laden van de product.
        if (!dr.Read())
        {
            lbl_titel.Text = "Helaas! Het opgegeven product kon niet gevonden worden.";
            return;
        }

        //Leest de gegevens die de database terug gestuurd heeft.
        string productnaam = dr.GetString(0);
        string productomschrijving = dr.GetString(1);
        string productcategorie = dr.GetString(2);
        decimal productprijs = dr.GetDecimal(3);
        string productplaatje = dr.GetString(4);
        int voorraad = dr.GetInt32(5);

        //Sluit de verbinding met de database.
        databaseConnectie.Dispose();
        databaseConnectie.Close();

        //Toont de gegevens die gevonden zijn in de database.
        lbl_titel.Text = productnaam;
        img_productplaatje.ImageUrl = productplaatje;
        lbl_prijs.Text = "€" + productprijs.ToString();
        lbl_omschrijving.Text = productomschrijving;
        lbl_categorie.Text = productcategorie;
        lbl_voorraad.Text = voorraad.ToString();
    }

    protected string SQL_Injection_Security(string zoekgegeven)
    {
        //Declareer lege variabel
        string zoekgegeven_secure = "";

        //Alle tekens in het zoekgegeven worden gecontroleerd en toegevoegd aan de variabel "zoekgegeven_secure. 
        //Wanneer er een " gevonden wordt stopt hij direct en returned hij de variabel "zoekgegeven_secure".
        //Hiermee worden SQL Injections voorkomen.
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
        //De gebruikte variabelen.
        int productID_1, productID_2, productID_3, productID_4, productID_5;
        Random rnd = new Random();

        //Genereert 5 productID's.
        productID_1 = rnd.Next(1, 20);
        productID_2 = rnd.Next(1, 20);
        productID_3 = rnd.Next(1, 20);
        productID_4 = rnd.Next(1, 20);
        productID_5 = rnd.Next(1, 20);

        //Geeft de 5 random gegenereerde productID's door aan de SelectCommand van de listview.
        SqlDataSource1.SelectCommand = "SELECT [productID], [productnaam], [productplaatje], [productprijs] FROM [PRODUCT] WHERE [productID] IN (" + productID_1 + "," + productID_2 + "," + productID_3 + "," + productID_4 + "," + productID_5 + ");";
    }
    
    protected void productlink_Click(object sender, EventArgs e)
    {
        //Stuurt de bezoeker door naar de bijbehorende productpagina.
        string productID = ((LinkButton)sender).CommandArgument;
        string url = string.Format("~/Product.aspx?productID={0}", productID);

        Response.Redirect(url);
    }

    protected void productplaatjeLabel_Click(object sender, ImageClickEventArgs e)
    {
        //Stuurt de bezoeker door naar de bijbehorende productpagina.
        string productID = ((ImageButton)sender).CommandArgument;
        string url = string.Format("~/Product.aspx?productID={0}", productID);

        Response.Redirect(url);
    }
}
