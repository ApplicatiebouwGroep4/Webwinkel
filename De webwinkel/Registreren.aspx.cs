using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

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
        DateTime time = DateTime.Now;
        string datum = time.ToString("dd-M-yyyy");
        
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"INSERT INTO KLANT (voornaam, achternaam, adres, postcode, plaats, telefoonnummer, nieuwsbrief, email, wachtwoord, registratiedatum) VALUES (@voornaam, @achternaam, @adres, @postcode, @plaats, @telefoonnummer, @nieuwsbrief, @email, @wachtwoord, @registratiedatum)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@voornaam",voornaamTextBox.Text);
        cmd.Parameters.AddWithValue("@achternaam", achternaamTextBox.Text);
        cmd.Parameters.AddWithValue("@email", emailTextBox.Text);
        cmd.Parameters.AddWithValue("@wachtwoord",wachtwoordTextBox.Text);
        cmd.Parameters.AddWithValue("@adres", adresTextBox.Text);
        cmd.Parameters.AddWithValue("@postcode", postcodeTextBox.Text);
        cmd.Parameters.AddWithValue("@plaats", plaatsTextBox.Text);
        cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummerTextBox.Text);
        cmd.Parameters.AddWithValue("@nieuwsbrief", niuwesbriefCheckBox.Checked);
        cmd.Parameters.AddWithValue("@registratiedatum", datum);

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
    }
}