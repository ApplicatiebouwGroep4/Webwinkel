<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="inlog page.aspx.cs" Inherits="inlog_page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="Label1" runat="server" Text="gebruikersnaam"></asp:Label>
    <asp:TextBox ID="TextBox1" runat="server" Height="24px" 
        style="margin-left: 69px; margin-top: 6px; margin-bottom: 0px"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
    ControlToValidate="TextBox1" ErrorMessage="vul uw gebruikersnaam in"></asp:RequiredFieldValidator>
<asp:Button ID="Button3" runat="server" Height="24px" onclick="Button3_Click" 
    style="margin-left: 187px" Text="help" Width="70px" />
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Text="wachtwoord"></asp:Label>
<asp:TextBox ID="TextBox2" runat="server" ontextchanged="TextBox2_TextChanged" 
    style="margin-left: 96px"></asp:TextBox>
<asp:RangeValidator ID="RangeValidator1" runat="server" 
    ControlToValidate="TextBox2" ErrorMessage="onuist wachtwoord" MaximumValue="9" 
    MinimumValue="0"></asp:RangeValidator>
    <br />
    <br />
    <asp:Button ID="Button1" runat="server" Height="22px" 
    onclick="Button1_Click" style="margin-left: 88px" Text="login" Width="81px" />
<asp:Button ID="Button2" runat="server" Height="22px" onclick="Button2_Click" 
    style="margin-left: 79px" Text="Registreren" Width="76px" />
    <br />
    <asp:Button ID="Button4" runat="server" Height="20px" 
    onclick="Button4_Click" 
    style="margin-left: 88px; margin-right: 0px; margin-top: 20px" 
    Text="Wachtwoord vergeten?" Width="168px" />
    <br />
</asp:Content>

