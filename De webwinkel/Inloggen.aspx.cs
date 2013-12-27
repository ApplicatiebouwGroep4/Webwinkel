using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

public partial class Inloggen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //Controleert of de bezoeker al is ingelogd. Zo ja, wordt de bezoeker naar de homepage omgeleid.
        if (Session["klantID"] != null)
        {
            Response.Redirect("~/index.aspx");
        }

        //Controleert of een eerder inlog poging mislukte door niet overeenkomende gegevens. Zo ja, toont een waarschuwing.
        if (Request.QueryString["login"] == "failed")
        {
            lbl_warning.Text = "Het opgegeven emailadres en/of wachtwoord klopt niet.";
            lbl_warning.Visible = true;
        }

        //Controleert of een eerder inlog poging mislukte doordat er geen verbinding met de database gemaakt kon worden. Zo ja, toon een waarschuwing.
        if (Request.QueryString["login"] == "connection_failed")
        {
            lbl_warning.Text = "Er kan geen verbinding gemaakt worden met de database. Probeer het later opnieuw.";
            lbl_warning.Visible = true;
        }
    }

    protected void knop_inloggen_Click(object sender, EventArgs e)
    {
        //Het declareren van de gebruikte variabelen.
        string achternaam, ConnectionString, emailadres, voornaam, wachtwoord_Database, wachtwoord_Encrypted;
        int klantID;

        //Vraagt de ConnectionString op.
        ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        
        //Leest de ingevoerde gegevens en encrypt het wachtwoord.
        emailadres = SQL_Injection_Security(veld_emailadres.Text);
        wachtwoord_Encrypted = encrypt_wachtwoord(veld_wachtwoord.Text);

        //Bereidt de SQL-Querry voor.
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"SELECT [wachtwoord], [klantID], [voornaam], [achternaam] FROM [KLANT] WHERE [email] = @email;";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("email", emailadres);

        //Test of er een verbinding met de database mogelijk is. Zo niet, wordt de bezoeker omgeleidt naar de inlogpagina met een waarschuw dat er geen verbinding gemaakt kon worden.
        OleDbConnection databaseConnectie = null;
        try
        {
            databaseConnectie = new OleDbConnection(ConnectionString);
        }
        catch
        {
            Response.Redirect("~/Inloggen.aspx?login=connection_failed");
        }

        //Maakt verbinding met de database en voert de SQL-querry uit.
        cmd.Connection = databaseConnectie;
        databaseConnectie.Open();
        OleDbDataReader dr = cmd.ExecuteReader();

        //Controleert of het opgegeven emailadres wel bestaat door te kijken of de database wat teruggestuurd heeft. 
        //Zo niet, wordt de bezoeker omgeleid naar de inlogpagina met een melding dat het emailadres/wachtwoord combinatie niet klopt.
        if (!dr.Read())
        {
            Response.Redirect("~/Inloggen.aspx?login=failed");
        }

        //Leest de gegevens die de database terug gestuurd heeft.
        wachtwoord_Database = dr.GetString(0);
        klantID = dr.GetInt32(1);
        voornaam = dr.GetString(2);
        achternaam = dr.GetString(3);

        //Sluit de verbinding met de database.
        databaseConnectie.Dispose();
        databaseConnectie.Close();

        //Controleert of het opgegeven wachtwoord overeenkomt met het wachtwoord in de database.
        if (wachtwoord_Encrypted == wachtwoord_Database)
        {
            //Zo ja, dan worden de klantID en naam opgeslagen in een session die de rest van de webwinkel weer afleest en wordt de homepage geladen.
            Session["klantID"] = klantID;
            Session["naam"] = voornaam + " " + achternaam;

            Response.Redirect("~/index.aspx");
        }
        else
        {
            //Zo niet, dan wordt de bezoeker omgeleidt naar de houdige pagina maar dan met een melding dat het emailadres/wachtwoord combinatie niet overeenkomt.
            Response.Redirect("~/Inloggen.aspx?login=failed");
        }
    }

    protected string SQL_Injection_Security(string emailadres)
    {
        //Declareer lege variabel
        string emailadres_secure = "";

        //Alle tekens in het opgegeven emailadres worden gecontroleerd en toegevoegd aan de variabel "emailadres_secure. 
        //Wanneer er een " gevonden wordt stopt hij direct en returned hij de variabel "emailadres_secure".
        //Hiermee worden SQL Injections voorkomen.
        for (int i = 0; i < emailadres.Length; i++)
        {
            if (emailadres[i] != '\"')
            {
                emailadres_secure += emailadres[i];
            }
            else
            {
                i = emailadres.Length;
            }
        }
        return (emailadres_secure);
    }
    protected void knop_registreren_Click(object sender, EventArgs e)
    {
        //Stuurt de gebruiker door naar de registratie pagina.
        Response.Redirect("~/Registreren.aspx");
    }

    protected string encrypt_wachtwoord(string wachtwoord)
    {
        //Alle tekens in het wachtwoord worden omgezet in bytes en dan weer in een array gezet genaamd teken_bytes[].
        byte[] teken_bytes = Encoding.Unicode.GetBytes(wachtwoord);
        
        //De tekens in de teken_bytes worden één voor één door een hash formule gehaald en geplaatst in de array genaamd encrypted_tekens
        byte[] encrypted_tekens = HashAlgorithm.Create("SHA1").ComputeHash(teken_bytes);
        
        //De tekens in de array genaamd encrypted_tekens worden samengevoegd in één string.
        string encrypted_wachtwoord = Convert.ToBase64String(encrypted_tekens);

        return (encrypted_wachtwoord);
    }
}