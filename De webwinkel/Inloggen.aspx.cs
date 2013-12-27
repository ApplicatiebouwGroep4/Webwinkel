using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.Configuration;

public partial class Inloggen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["klantID"] != null)
        {
            Response.Redirect("~/index.aspx");
        }

        if (Request.QueryString["login"] == "failed")
        {
            lbl_warning.Visible = true;
        }

        if (Request.QueryString["login"] == "connection_failed")
        {
            lbl_warning.Text = "Er kan geen verbinding gemaakt worden met de database. Probeer het later opnieuw.";
            lbl_warning.Visible = true;
        }
    }

    protected void knop_inloggen_Click(object sender, EventArgs e)
    {
        if (veld_emailadres.Text == "" || veld_wachtwoord.Text == "")
        {
            Response.Redirect("~/Inloggen.aspx?login=failed");
        }

        string achternaam, ConnectionString, emailadres, voornaam, wachtwoord_Ingevoerd, wachtwoord_Database;
        int klantID;

        ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        emailadres = SQL_Injection_Security(veld_emailadres.Text);
        wachtwoord_Ingevoerd = veld_wachtwoord.Text;

        OleDbCommand cmd = new OleDbCommand();
        cmd.CommandText = @"SELECT [wachtwoord], [klantID], [voornaam], [achternaam] FROM [KLANT] WHERE [email] = @email;";
        cmd.CommandType = CommandType.Text;
        cmd.Parameters.AddWithValue("email", emailadres);

        OleDbConnection databaseConnectie = null;
        try
        {
            databaseConnectie = new OleDbConnection(ConnectionString);
        }
        catch
        {
            Response.Redirect("~/Inloggen.aspx?login=connection_failed");
        }

        cmd.Connection = databaseConnectie;
        databaseConnectie.Open();
        OleDbDataReader dr = cmd.ExecuteReader();

        if (!dr.Read())
        {
            Response.Redirect("~/Inloggen.aspx?login=failed");
        }

        wachtwoord_Database = dr.GetString(0);
        klantID = dr.GetInt32(1);
        voornaam = dr.GetString(2);
        achternaam = dr.GetString(3);

        if (wachtwoord_Ingevoerd == wachtwoord_Database)
        {
            Session["klantID"] = klantID;
            Session["naam"] = voornaam + " " + achternaam;

            Response.Redirect(Request.RawUrl);
        }

        else
        {
            Response.Redirect("~/Inloggen.aspx?login=failed");
        }
    }

    protected string SQL_Injection_Security(string emailadres)
    {
        string emailadres_secure = "";

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
        Response.Redirect("~/Registreren.aspx");
    }
}