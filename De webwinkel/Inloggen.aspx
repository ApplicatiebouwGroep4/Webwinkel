<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Inloggen.aspx.cs" Inherits="Inloggen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="inlogpage">
        <h1>Inloggen</h1>
        <asp:Label ID="lbl_warning" runat="server" ForeColor="Red" Text="Het opgegeven emailadres en/of wachtwoord klopt niet." Visible="False"></asp:Label>
        <br />
        <asp:Label ID="lbl_emailadres" runat="server" Text="Emailadres:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="veld_emailadres" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Label ID="lbl_wachtwoord" runat="server" Text="Wachtwoord:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="veld_wachtwoord" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="knop_inloggen" runat="server" OnClick="knop_inloggen_Click" Text="Inloggen" />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="knop_registreren" runat="server" OnClick="knop_registreren_Click" Text="Registreren" />
        <br />

    </div>
</asp:Content>

