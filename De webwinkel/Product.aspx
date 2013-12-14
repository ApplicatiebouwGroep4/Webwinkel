<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div id="ProductDetails">
    <p id="product_p">Product details: Naam, beoordeling, verlanglijst, mail naar vriend etc.</p>
    <img src="Image/chaga.jpg" alt="product plaatje" />
    <p>Prijs</p>
    <p>Hoeveelheid in voorad</p>
    <p>+Plaats in winklmand</p>
</div><!--end ProductDetails-->

<div id="ProductenContent">
    <p>Content informatie</p>
</div><!--end ProductenContent-->

<div id="slider2">
    <p>Slider vergelijkbare producten, "klanten die dit product kochten bekeken ook..."</p>
</div><!--end slider2-->
</asp:Content>

