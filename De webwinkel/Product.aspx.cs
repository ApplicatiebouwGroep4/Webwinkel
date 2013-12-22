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
        //string stringquery = Request.QueryString["productID"];
        string stringquery = "1";
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString3"].ConnectionString;

        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"SELECT [productID], [productnaam], [productomschrijving], [productcategorie], [productprijs], [productplaatje] FROM [PRODUCT] WHERE [productID] = @productID;";
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

        int productID = dr.GetInt32(0);
        string productnaam = dr.GetString(1);
        string productomschrijving = dr.GetString(2);
        string productcategorie = dr.GetString(3);
        double productprijs = dr.GetInt32(4);
        string productplaatje = dr.GetString(5);

        databaseConnectie.Dispose();
        databaseConnectie.Close();

        lbl_titel.Text = productID + " " + productnaam;
        img_productplaatje.ImageUrl = productplaatje;
        lbl_prijs.Text = productprijs.ToString();
        lbl_omschrijving.Text = productomschrijving;
        lbl_categorie.Text = productcategorie;

    }
}