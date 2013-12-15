<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Accountgegevens.aspx.cs" Inherits="Accountgegevens" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Accountgegevens</h1>
    <table style="width: 100%; height: 100%;">
        <tr>
            <td style="width: 215px">
                <asp:Label ID="voornaamLabel" runat="server" Text="Voornam:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="voornaamTextBox" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="voornaamTextBox" ErrorMessage="Geef een voornaam" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="AchternaamLabel" runat="server" Text="Achternaam:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="achternaamTextBox" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="achternaamTextBox" ErrorMessage="Geef een achternaam" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="emailLabel1" runat="server" Text="E-mail:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="emailTextBox" runat="server" TextMode="Email" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="emailTextBox" ErrorMessage="Geef een valid e-mail" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                    ControlToValidate="emailTextBox" ErrorMessage="Geef een valid e-mail adres" 
                    ForeColor="#339933" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="Label2" runat="server" Text="Wachtwoord:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="wachtwoordTextBox" runat="server" TextMode="Password" 
                    Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="wachtwoordTextBox" ErrorMessage="Geef een wachtwoord" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="pswdbevestigenLabel" runat="server" 
                    Text="Wachtwoord bevestigen:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="wchtwoordbevstigTextBox" runat="server" TextMode="Password" 
                    Width="140px"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="wachtwoordTextBox" 
                    ControlToValidate="wchtwoordbevstigTextBox" ErrorMessage="Wachtwoord onjuist" 
                    ForeColor="#339933"></asp:CompareValidator>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="wchtwoordbevstigTextBox" 
                    ErrorMessage="Bevestig uw wachtwoord" ForeColor="#339933"></asp:RequiredFieldValidator>
&nbsp;</td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="AdresLabel" runat="server" Text="Adres:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="adresTextBox" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="adresTextBox" ErrorMessage="Geef uw adres" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="PostcodeLabel" runat="server" Text="Postcode:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="postcodeTextBox" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                    ControlToValidate="postcodeTextBox" ErrorMessage="Geef uw postcode" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="PlaatsLabel" runat="server" Text="Plaats:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="plaatsTextBox" runat="server" Width="140px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="plaatsTextBox" ErrorMessage="Geef uw plaats" 
                    ForeColor="#339933"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="TelefoonnummerLabel" runat="server" Text="Telefoonnummer:"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="telefoonnummerTextBox" runat="server" TextMode="Phone" 
                    Width="140px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                <asp:Label ID="NieuwsbriefLabel" runat="server" Text="Nieuwsbrief:"></asp:Label>
            </td>
            <td>
                <asp:CheckBox ID="niuwesbriefCheckBox" runat="server" 
                    Text="Ja, ik wil graag nieuwsbrief ontvangen van alle voordelen en acties." />
            </td>
        </tr>
        <tr>
            <td style="width: 215px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 215px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td style="width: 215px">
                &nbsp;</td>
            <td>
                <asp:Button ID="verzendenButton" runat="server" Text="Verzenden" 
                    BackColor="#006600" ForeColor="#EEEEEE" onclick="verzendenButton_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

