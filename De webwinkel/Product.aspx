<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Product.aspx.cs" Inherits="Product" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="ProductDetails">
        <p id="productplaatje"><asp:Image ID="img_productplaatje" runat="server" Height="200px" Width="200px" /></p>
        <p id="product_info">
            <br />
            <br />
            <asp:Label ID="lbl_titel" Font-Size="X-Large" Font-Bold="true" runat="server"></asp:Label>
            <br />
            <br />
            Categorie: <asp:Label ID="lbl_categorie" runat="server"></asp:Label>
            <br />
            <br />
            <asp:Label ID="lbl_prijs" runat="server" ForeColor="Red" Font-Size="Large"></asp:Label>
        </p>
        <p id="product_winkelwagen">
            <br />
            <br />
            <br />
            In voorraad: <asp:Label ID="lbl_voorraad" runat="server"></asp:Label>
            <br />
            <asp:ImageButton ID="knop_VoegAanWinkelwagen" Height="25px" Width="60px" ImageUrl="~/Image/aan_winkelwagen_toevoegen.gif" runat="server" />
            <select id="Select1" name="D1" style="width: 50px">
                <option>1</option>
                <option>2</option>
                <option>3</option>
                <option>4</option>
                <option>5</option>
                <option>6</option>
                <option>7</option>
                <option>8</option>
                <option>9</option>
                <option>10</option>
            </select></p>
    &nbsp;</div><!--end ProductDetails-->

<div id="Product_Omschrijving">
    <p>
        <asp:Label ID="lbl_omschrijving" runat="server"></asp:Label>
    </p>
</div><!--end ProductenContent-->

<div id="slider2">
    <asp:ListView ID="listview_Catalogus" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="productID" GroupItemCount="5">
        <AlternatingItemTemplate>
            <td id="Td1" runat="server" style="" class="productenlijst">
                <asp:LinkButton ID="productIDLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# "#"+Eval("productID") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <asp:LinkButton ID="productnaamLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# Eval("productnaam") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:ImageButton ID="productplaatjeLabel" runat="server" ImageUrl='<%# Eval("productplaatje") %>' Height="100px" Width="120px" OnClick="productplaatjeLabel_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:Label ID="productprijsLabel" runat="server" ForeColor="red" Font-Bold="true" Text='<%# "€"+Eval("productprijs") %>' />
                <br /></td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td id="Td2" runat="server" style="">productID:
                <asp:Label ID="productIDLabel1" runat="server" Text='<%# Eval("productID") %>' />
                <br />productnaam:
                <asp:TextBox ID="productnaamTextBox" runat="server" Text='<%# Bind("productnaam") %>' />
                <br />productplaatje:
                <asp:TextBox ID="productplaatjeTextBox" runat="server" Text='<%# Bind("productplaatje") %>' />
                <br />productprijs:
                <asp:TextBox ID="productprijsTextBox" runat="server" Text='<%# Bind("productprijs") %>' />
                <br />
                <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                <br /></td>
        </EditItemTemplate>
        <EmptyDataTemplate>
            <table id="Table1" runat="server" style="">
                <tr>
                    <td>Helaas! Er zijn geen producten gevonden. Verfijn uw zoekopdracht.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td id="Td3" runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td id="Td4" runat="server" style="">productnaam:
                <asp:TextBox ID="productnaamTextBox" runat="server" Text='<%# Bind("productnaam") %>' />
                <br />productplaatje:
                <asp:TextBox ID="productplaatjeTextBox" runat="server" Text='<%# Bind("productplaatje") %>' />
                <br />productprijs:
                <asp:TextBox ID="productprijsTextBox" runat="server" Text='<%# Bind("productprijs") %>' />
                <br />
                <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                <br />
                <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                <br /></td>
        </InsertItemTemplate>
        <ItemTemplate>
            <td id="Td5" runat="server" style="" class="productenlijst">
                <asp:LinkButton ID="productIDLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# "#"+Eval("productID") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <asp:LinkButton ID="productnaamLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# Eval("productnaam") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:ImageButton ID="productplaatjeLabel" runat="server" ImageUrl='<%# Eval("productplaatje") %>' Height="100px" Width="120px" OnClick="productplaatjeLabel_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:Label ID="productprijsLabel" runat="server" ForeColor="red" Font-Bold="true" Text='<%# "€"+Eval("productprijs") %>' />
                <br /></td>
        </ItemTemplate>
        <LayoutTemplate>
            <table id="Table2" runat="server">
                <tr id="Tr1" runat="server">
                    <td id="Td6" runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr id="Tr2" runat="server">
                    <td id="Td7" runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="5">

                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td id="Td8" runat="server" style="">productID:
                <asp:Label ID="productIDLabel" runat="server" Text='<%# Eval("productID") %>' />
                <br />productnaam:
                <asp:Label ID="productnaamLabel" runat="server" Text='<%# Eval("productnaam") %>' />
                <br />productplaatje:
                <asp:Label ID="productplaatjeLabel" runat="server" Text='<%# Eval("productplaatje") %>' />
                <br />productprijs:
                <asp:Label ID="productprijsLabel" runat="server" Text='<%# Eval("productprijs") %>' />
                <br /></td>
        </SelectedItemTemplate>
        </asp:ListView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT [productID], [productnaam], [productplaatje], [productprijs] FROM [PRODUCT]"></asp:SqlDataSource>
    &nbsp;&nbsp;
</div><!--end slider2-->
</asp:Content>

