<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Winkelwagen.aspx.cs" Inherits="Winkelwagen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:GridView ID="GrdWinkelwagen" runat="server" AutoGenerateColumns="False" DataKeyNames="productID" DataSourceID="SqlDataSource" 
        OnRowCancelingEdit="GrdWinkelwagen_RowCancelingEdit" OnRowDeleting="GrdWinkelwagen_RowDeleting" OnRowEditing="GrdWinkelwagen_RowEditing" 
        OnRowUpdating="GrdWinkelwagen_RowUpdating">
        <Columns>
            <asp:BoundField DataField="productnaam" HeaderText="productnaam" SortExpression="productnaam" />
            <asp:BoundField DataField="productplaatje" HeaderText="productplaatje" SortExpression="productplaatje" />
            <asp:BoundField DataField="productprijs" HeaderText="productprijs" SortExpression="productprijs" DataFormatString="{0:c}" />
            <asp:TemplateField HeaderText="Aantal">
                <ItemTemplate>
                    <asp:TextBox runat="server" Width="30px"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Totaal_Prijs">
                <ItemTemplate>
                    <asp:Label runat="server"></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="true" ShowEditButton="true" />
        </Columns>
        <EmptyDataTemplate>
            De winkelwagen is leeg, voeg toe producten.
            <a href="Catalogus.aspx">Kiez Producten</a>
        </EmptyDataTemplate>
    </asp:GridView>

    <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [productID], [productnaam], [productprijs], [productplaatje] FROM [PRODUCT]"></asp:SqlDataSource>

    <br />
    <table style="width:100%;">
        <tr>
            <td style="width: 280px">
                <asp:Label ID="Totaal_PrijsLabel" runat="server"></asp:Label>
            </td>
            <td style="width: 195px">
                <asp:Button ID="BestelButton" OnClick="BestelButton_Click" runat="server"  style="margin-left: 11px" Text="Bestellen" Width="117px" />
            </td>
            <td>
                <asp:Button ID="Verder_winkelenButton" runat="server" Text="Verder Winkelen" Width="117px" OnClick="Verder_winkelenButton_Click" />
            </td>
        </tr>
    </table>

</asp:Content>

