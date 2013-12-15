using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

public partial class Accountgegevens : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void verzendenButton_Click(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"INSERT INTO KLANT (voornaam, achternaam, emaildares, wachtwoord, adres, postcode, plaats, telefoonnummer, nieuwsbrief) VALUES (@voornaam, @achternaam, @emaildares, @wachtwoord, @adres, @postcode, @plaats, @telefoonnummer, @nieuwsbrief)";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("@voornaam",voornaamTextBox.Text);
        cmd.Parameters.AddWithValue("@achternaam", achternaamTextBox.Text);
        cmd.Parameters.AddWithValue("@emaildares", emailTextBox.Text);
        cmd.Parameters.AddWithValue("@wachtwoord",wachtwoordTextBox.Text);
        cmd.Parameters.AddWithValue("@adres", adresTextBox.Text);
        cmd.Parameters.AddWithValue("@postcode", postcodeTextBox.Text);
        cmd.Parameters.AddWithValue("@plaats", plaatsTextBox.Text);
        cmd.Parameters.AddWithValue("@telefoonnummer", telefoonnummerTextBox.Text);
        cmd.Parameters.AddWithValue("@nieuwsbrief", niuwesbriefCheckBox.Checked);

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
        }

        // de connectie met de database open maken....
        MyAccessConn.Open();
        cmd.Connection = MyAccessConn;

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