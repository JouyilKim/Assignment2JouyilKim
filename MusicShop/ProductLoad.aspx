<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductLoad.aspx.cs" Inherits="MusicShop.WebForm5" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table id="tb1">
        <tr>
            <td id="td1">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" DataKeyNames="product_id" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                    <Columns>
                        <asp:TemplateField HeaderText="Images">
                            <ItemTemplate>
                                    <asp:ImageButton  ID="image" ImageUrl='<%# Eval("img") %>' Width="200px" Height="200px" runat="server" 
                                        PostBackUrl='<%# "ProductDetail.aspx?product_id="+ Eval("product_id") %>' AlternateText="error"
                                         />
                                
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="product_id" HeaderText="product_id" SortExpression="product_id" ReadOnly="True" Visible="False" />
                        <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
                        <asp:BoundField DataField="productPrice" HeaderText="productPrice" SortExpression="productPrice" />
                        <asp:BoundField DataField="brand" HeaderText="brand" SortExpression="brand" />
                        <asp:BoundField DataField="img" HeaderText="img" SortExpression="img" Visible="False"/>
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [product_id], [productName], [productPrice], [brand], [img] FROM [tblProduct] WHERE ([type] = @type)">
                    <SelectParameters>
                        <asp:QueryStringParameter DefaultValue="Guitar" Name="type" QueryStringField="value" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>
</asp:Content>
