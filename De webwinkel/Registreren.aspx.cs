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

public partial class Registreren : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["klantID"] != null)
        {
            Response.Redirect("~/index.aspx");
        }
    }

    protected void verzendenButton_Click(object sender, EventArgs e)
    {
        
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"INSERT INTO KLANT (voornaam, achternaam, adres, postcode, plaats, telefoonnummer, nieuwsbrief, email, wachtwoord, registratiedatum) VALUES (@voornaam, @achternaam, @adres, @postcode, @plaats, @telefoonnummer, @nieuwsbrief, @email, @wachtwoord, @registratiedatum)";
        cmd.Parameters.AddWithValue("@voornaam", voornaamTextBox.Text);
        cmd.Parameters.AddWithValue("@achternaam", achternaamTextBox.Text);
        cmd.Parameters.AddWithValue("@adres", adresTextBox.Text);
        cmd.Parameters.AddWithValue("@postcode", postcodeTextBox.Text);
        cmd.Parameters.AddWithValue("@plaats", plaatsTextBox.Text);
        cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummerTextBox.Text);
        cmd.Parameters.AddWithValue("@nieuwsbrief", niuwesbriefCheckBox.Checked);
        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
        cmd.Parameters.AddWithValue("@wachtwoord", wachtwoordTextBox.Text);
        cmd.Parameters.AddWithValue("@registratiedatum", DateTime.Now); 

        OleDbConnection MyAccessConn = null;

        // een connectie met de database maken....
        try
        {
            MyAccessConn = new OleDbConnection(ConnectionString);

        }
        
        // als de connectie met de database niet gelukt...
        catch (Exception ex)
        {
            Console.WriteLine("Error: Failed to connect to creat a database connection. \n{0}",ex.Message);
            return;
        }

        // de connectie met de database open maken....
        cmd.Connection = MyAccessConn;
        MyAccessConn.Open();

        // de transactie van de ingevulde data binnen de database met behulp van insert-Query...
        cmd.Transaction = MyAccessConn.BeginTransaction();
        int rows = cmd.ExecuteNonQuery();

        if (rows > 0)
        {
            // als de transactie gelukt wordt dat getoond...
            Console.WriteLine("Insert is success");
        }

        else
        {
            // als de transactie niet gelukt wordt dat getoond....
            Console.Write("Insert Failed");
        }

        cmd.Transaction.Commit();
        MyAccessConn.Dispose();
        MyAccessConn.Close();

        OleDbCommand chk = new OleDbCommand();
        chk.CommandType = CommandType.Text;
        chk.CommandText = @"SELECT [email] from KLANT WHERE [email]=@email";
        chk.Parameters.AddWithValue("@email", emailTextBox.Text);
        OleDbConnection check_email = null;
        try
        {
            check_email = new OleDbConnection(ConnectionString);
        }
        catch
        {
            Response.Redirect("~/Registreren.aspx");
        }

        //maak connectie met databse...
        chk.Connection = check_email;
        check_email.Open();

        OleDbDataReader dr = chk.ExecuteReader();
        
        // check of de email in de database is al bestaan...
        //check of de email niet in de database is bestaan...
        if (dr.Read())
        {
            Check_EmailLabel.Text = "Deze E-mail is in gebruik";
        }
        else
        {
            //wordt opgeslagen....
        }

        //haal de gegevens die database verstuurd...
        string email = dr.GetString(0);

        //sluit de verbinding met de database...
        check_email.Dispose();
        check_email.Close();
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
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {
        // als het wachtwoord minder of gelijk aan 6....
        if (args.Value.Length <= 6)
        {
            // het wachtwoord is valid, dan wordt het opgeslagen in de database...
            args.IsValid = true;
        }

        else
        {
            //het wachtwoord meer dan 6 dan wordt een Error bericht getoond...
            args.IsValid = false;
        }
    }
}