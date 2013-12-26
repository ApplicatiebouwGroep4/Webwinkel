using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Configuration;

public partial class inlog_page : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
    {

    }
    protected void TextBox2_TextChanged(object sender, EventArgs e)
    {
       
 


    }
    private void InitializeMyControl()
    {
        // Set to no text.
        TextBox2.Text = "";
        // The password character is an asterisk.
        TextBox2.PasswordChar = '*';
        
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        //login
        //username
        string string1 = TextBox1.Text;
        
      
        int integer = Convert.ToInt32(string1);
       
        //wachtwoord
       string string2 = TextBox2.Text;
        double double1 = Convert.ToDouble(string2);
        int i = 0;
        
            // haal de connection string voor Access database uit web.config
            string connectionString =
            ConfigurationManager.ConnectionStrings["CijfersConnectionString"].ConnectionString;
            // maak connectie aan naar Access database
            OleDbConnection connection = new OleDbConnection(connectionString);
            // maak een SQL commando aan met een SELECT query
            string sql = "SELECT klantID FROM klant";
            OleDbCommand objCmd = new OleDbCommand(sql, connection);
            int sql2 = Convert.ToInt32(sql);
        

        int klantidnumber = sql2;
        while (i < klantidnumber)
        {
            // haal de connection string voor Access database uit web.config
            string connectionString2 =
            ConfigurationManager.ConnectionStrings["CijfersConnectionString"].ConnectionString;
            // maak connectie aan naar Access database
            OleDbConnection connection2 = new OleDbConnection(connectionString);
            // maak een SQL commando aan met een SELECT query
            string sql3 = "SELECT wachtwoord,username FROM klant";
            OleDbCommand objCmd2 = new OleDbCommand(sql, connection);
            int sql4 = Convert.ToInt32(sql3);
            
          //controle of naam klopt
            string[] wachtwoordennaam = new string[sql4]; 
            if ((string1) <> (wachtwoordennaam))
            {
                //ik heb account pagina nodig

            }

            else
            {
               //Login failed
            }

            i = i++;
        

        //contole of wachtwoord klopt
         if ((string2) <> (wachtwoordennaam))
            {
                //ik heb account pagina nodig

            }

            else
            {
               //Login failed
            }

            i = i++;
        }
    }
    

    
    protected void Button2_Click(object sender, EventArgs e)
    {
        //registreren
         Response.Redirect ("resgistratie.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        //wachtwoord vergeten

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        //help button
    }
}