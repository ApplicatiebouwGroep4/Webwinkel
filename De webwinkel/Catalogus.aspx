<%@ Page Title="" Language="C#" MasterPageFile="~/MasterWebwinkel.master" AutoEventWireup="true" CodeFile="Catalogus.aspx.cs" Inherits="Producten" EnableEventValidation="true"%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div id="catagorie">
    <p>
        <asp:Label ID="lbl_informatie" runat="server" Text="Informatie"></asp:Label>
        </p>
    &nbsp;</div><!--end catagorie-->

<div id="catagorie_producten">
    <p><strong>Producten
        </strong></p>
    <asp:ListView ID="listview_Catalogus" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="productID" GroupItemCount="5">
        <AlternatingItemTemplate>
            <td runat="server" style="" class="productenlijst">
                <asp:LinkButton ID="productIDLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# "#"+Eval("productID") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <asp:LinkButton ID="productnaamLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# Eval("productnaam") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:ImageButton ID="productplaatjeLabel" runat="server" ImageUrl='<%# Eval("productplaatje") %>' Height="100px" Width="120px" OnClick="productplaatjeLabel_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:Label ID="productprijsLabel" runat="server" ForeColor="red" Font-Bold="true" Text='<%# "€"+Eval("productprijs") %>' />
                <br /></td>
        </AlternatingItemTemplate>
        <EditItemTemplate>
            <td runat="server" style="">productID:
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
            <table runat="server" style="">
                <tr>
                    <td>Helaas! Er zijn geen producten gevonden. Verfijn uw zoekopdracht.</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
<td runat="server" />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <InsertItemTemplate>
            <td runat="server" style="">productnaam:
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
            <td runat="server" style="" class="productenlijst">
                <asp:LinkButton ID="productIDLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# "#"+Eval("productID") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <asp:LinkButton ID="productnaamLabel" runat="server" ForeColor="black" Font-Underline="false" Text='<%# Eval("productnaam") %>' OnClick="productlink_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:ImageButton ID="productplaatjeLabel" runat="server" ImageUrl='<%# Eval("productplaatje") %>' Height="100px" Width="120px" OnClick="productplaatjeLabel_Click" CommandArgument='<%# Eval("productID") %>'/>
                <br />
                <asp:Label ID="productprijsLabel" runat="server" ForeColor="red" Font-Bold="true" Text='<%# "€"+Eval("productprijs") %>' />
                <br /></td>
        </ItemTemplate>
        <LayoutTemplate>
            <table runat="server">
                <tr runat="server">
                    <td runat="server">
                        <table id="groupPlaceholderContainer" runat="server" border="0" style="">
                            <tr id="groupPlaceholder" runat="server">
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr runat="server">
                    <td runat="server" style="">
                        <asp:DataPager ID="DataPager1" runat="server" PageSize="10">
                            <Fields>
                                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                <asp:NumericPagerField />
                                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            </Fields>
                        </asp:DataPager>
                    </td>
                </tr>
            </table>
        </LayoutTemplate>
        <SelectedItemTemplate>
            <td runat="server" style="">productID:
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
</div><!--end catagorie_producten-->
</asp:Content>

