<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="MusicShop.WebForm7" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="order_id" DataSourceID="SqlDataSource1" OnRowDeleting="GridView1_RowDeleting">
        <Columns>
            <asp:CommandField ShowDeleteButton="True" />
            <asp:TemplateField HeaderText="Images">
            <ItemTemplate>
                    <asp:ImageButton ID="image" ImageUrl='<%# Eval("img") %>' Width="100px" Height="100px" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="order_id" HeaderText="order_id" ReadOnly="True" SortExpression="order_id" Visible="false"/>
            <asp:BoundField DataField="product_id" HeaderText="product_id" SortExpression="product_id" Visible="false" />
            <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
            <asp:BoundField DataField="orderQuantity" HeaderText="orderQuantity" SortExpression="orderQuantity" />
            <asp:BoundField DataField="orderTotalPrice" HeaderText="orderTotalPrice" SortExpression="orderTotalPrice" />
            <asp:BoundField DataField="cart_id" HeaderText="cart_id" SortExpression="cart_id" Visible="false" />
            <asp:BoundField DataField="img" HeaderText="img" SortExpression="img" Visible="false" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM tblOrders WHERE order_id = @order_id" SelectCommand="SELECT tblOrders.order_id, tblOrders.product_id, tblOrders.orderTotalPrice, tblOrders.orderQuantity, tblOrders.cart_id, tblProduct.productName, tblProduct.img FROM tblOrders INNER JOIN tblProduct ON tblOrders.product_id = tblProduct.product_id
WHERE cart_id = @cart_id">
        <DeleteParameters>
            <asp:Parameter Name="order_id" />
        </DeleteParameters>
        <SelectParameters>
            <asp:CookieParameter CookieName="cart_id" Name="cart_id" />
        </SelectParameters>
    </asp:SqlDataSource>
    <table>
        <tr>
            <td>
                <asp:Button ID="btnDeleteAll" runat="server" Text="Dump All Orders" OnClick="btnDeleteAll_Click" />
            </td>
            <td>
                <asp:Button ID="btnCheckOut" runat="server" Text="CheckOut" OnClick="btnCheckOut_Click" />
            </td>
        </tr>
    </table>

</asp:Content>
<%--<asp:TemplateField HeaderText="Images">
                <ItemTemplate>
                    <asp:ImageButton ID="image" ImageUrl='<%# Eval("img") %>' Width="100px" Height="100px" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="img" HeaderText="img" SortExpression="img" Visible="false" />
            <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
            <asp:BoundField DataField="orderQuantity" HeaderText="orderQuantity" SortExpression="orderQuantity" />
            <asp:BoundField DataField="orderTotalPrice" HeaderText="orderTotalPrice" SortExpression="orderTotalPrice" />--%>