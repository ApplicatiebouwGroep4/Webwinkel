<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Winkelwagen.aspx.cs" Inherits="Winkelwagen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="productID" DataSourceID="SqlDataSource" CellPadding="4" ForeColor="#333333" GridLines="None" Width="747px" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:BoundField DataField="productID" HeaderText="productID" SortExpression="productID" InsertVisible="False" ReadOnly="True" />
                    <asp:BoundField DataField="productplaatje" HeaderText="productplaatje" SortExpression="productplaatje" />
                    <asp:BoundField DataField="productnaam" HeaderText="productnaam" SortExpression="productnaam" />
                    <asp:BoundField DataField="productprijs" HeaderText="productprijs" SortExpression="productprijs" />

                <asp:TemplateField HeaderText="Aantal">
                        <ItemTemplate>
                            <asp:DropDownList ID="Antalproducten" Width="50" runat="server">
                            </asp:DropDownList>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Verwijder">
                        <ItemTemplate>
                            <asp:CheckBox ID="verwijder" runat="server" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" Height="70px"/>
                <HeaderStyle BackColor="#006600" Font-Bold="True" ForeColor="#EEEEEE"  Height="70px" CssClass="GridviewHeader"/>
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center"/>
                <RowStyle BackColor="#EEEEEE"  Height="90px"/>
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#F8FAFA" />
                <SortedAscendingHeaderStyle BackColor="#246B61" />
                <SortedDescendingCellStyle BackColor="#D4DFE1" />
                <SortedDescendingHeaderStyle BackColor="#15524A" />
            </asp:GridView>
            <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" SelectCommand="SELECT [productprijs], [productplaatje], [productnaam], [productID] FROM [PRODUCT]" DeleteCommand="DELETE FROM [PRODUCT] WHERE [productID]=@productID">
                <DeleteParameters>
                    <asp:Parameter Name="productID" />
                </DeleteParameters>
            </asp:SqlDataSource>

            <br />
            <table style="width:100%;">
                <tr>
                    <td style="width: 493px">&nbsp;</td>
                    <td>
                        <asp:Label ID="TotaalPrijsLabel" runat="server" ForeColor="#006600" Text="Totaal Prijs:"></asp:Label>
                        <asp:Label ID="Label2" runat="server" Text="€ "></asp:Label>
                        <asp:Label ID="Label3" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>

    </div>

    <table> 
      <tr>
        <td style="width: 168px">
            <asp:Button ID="VerwijderButton" runat="server" Text="Verder Winkelen" Width="160px" border-radius="20px" BackColor="#006600" ForeColor="White" Height="40px" OnClick="VerwijderButton_Click" />
        </td>
          <td>
              <asp:Button ID="verwijderen" runat="server" Text="Verwijder Product" Width="123px" BackColor="#006600"  ForeColor="White" Height="40px" OnClick="verwijderen_Click" style="margin-left: 145px"/>
          </td>
        <td style="width: 111px">
            <asp:Button ID="BestellingAfrondeButton" runat="server" Text="Bestelling Afronden" Width="160px" BackColor="#006600" style="margin-left: 95px" ForeColor="White" Height="40px" />
        </td>
        <td style="width: 111px">
            &nbsp;</td>
        <td style="width: 254px">
            &nbsp;</td>
      </tr>
    </table>
</asp:Content>

