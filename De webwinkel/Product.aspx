<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ProductDetails">
    <p id="product_p">
        #<asp:Label ID="lbl_titel" runat="server"></asp:Label>
        </p>
    &nbsp;<asp:Image ID="img_productplaatje" runat="server" />
&nbsp;&nbsp;&nbsp;&nbsp;
    <p>&nbsp;
        €<asp:Label ID="lbl_prijs" runat="server"></asp:Label>
&nbsp;</p>
    <p>Categorie:
        <asp:Label ID="lbl_categorie" runat="server"></asp:Label>
        </p>
    <p>+Plaats in winkelmand</p>
</div><!--end ProductDetails-->

<div id="ProductenContent">
    <p>
        <asp:Label ID="lbl_omschrijving" runat="server"></asp:Label>
    </p>
</div><!--end ProductenContent-->

<div id="slider2">
    <p>Slider vergelijkbare producten, "klanten die dit product kochten bekeken ook..."</p>
</div><!--end slider2-->
</asp:Content>

