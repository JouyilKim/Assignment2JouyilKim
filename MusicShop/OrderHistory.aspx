<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="OrderHistory.aspx.cs" Inherits="MusicShop.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1">
                    <Columns>
                        <asp:BoundField DataField="orderTime" HeaderText="orderTime" SortExpression="orderTime" />
                        <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
                        <asp:BoundField DataField="orderQuantity" HeaderText="orderQuantity" SortExpression="orderQuantity" />
                        <asp:BoundField DataField="orderTotalPrice" HeaderText="orderTotalPrice" SortExpression="orderTotalPrice" />
                        <asp:BoundField DataField="img" HeaderText="img" SortExpression="img" Visible="false" />
                        <asp:TemplateField HeaderText="Images">
                <ItemTemplate>
                    <asp:ImageButton ID="image" ImageUrl='<%# Eval("img") %>' Width="100px" Height="100px" runat="server" />
                </ItemTemplate>
            </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT tblOrders.orderTotalPrice, tblOrders.orderQuantity, tblOrders.orderTime, tblProduct.productName, tblProduct.img FROM tblOrders INNER JOIN tblProduct ON tblOrders.product_id = tblProduct.product_id WHERE (tblOrders.customer_id = @customer_id)">
                    <SelectParameters>
                        <asp:CookieParameter CookieName="user_id" Name="customer_id" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
