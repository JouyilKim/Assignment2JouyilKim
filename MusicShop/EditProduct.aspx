<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="MusicShop.WebForm4" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnAddProduct" runat="server" Text="AddProduct" Height="50px" OnClick="btnAddProduct_Click" Width="199px" />
    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
        <asp:ListItem>Guitar</asp:ListItem>
        <asp:ListItem>Bass</asp:ListItem>
        <asp:ListItem>Drum</asp:ListItem>
        <asp:ListItem>Mic</asp:ListItem>
        <asp:ListItem>Accessories</asp:ListItem>
        <asp:ListItem>Others</asp:ListItem>
    </asp:DropDownList>
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="product_id" DataSourceID="SqlDataSource1" OnRowUpdating="GridView1_RowUpdating">
        <Columns>
            
            <asp:BoundField DataField="product_id" HeaderText="product_id" ReadOnly="True" SortExpression="product_id" />
            <asp:BoundField DataField="productName" HeaderText="productName" SortExpression="productName" />
            <asp:BoundField DataField="productPrice" HeaderText="productPrice" SortExpression="productPrice" />
            <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
            <asp:BoundField DataField="brand" HeaderText="brand" SortExpression="brand" />
            <asp:BoundField DataField="img" HeaderText="img" SortExpression="img" />
            <asp:TemplateField HeaderText="UploadImage">
                <ItemTemplate>
                    <asp:Image ImageUrl ='<%# Eval("img") %>' Width="100px" Height="100px" runat="server" ID="image" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fileUploadEdit1" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>"
        SelectCommand="SELECT * FROM [tblProduct] WHERE ([type] = @type)"
        DeleteCommand="DELETE FROM [tblProduct] WHERE [product_id] = @product_id" InsertCommand="INSERT INTO [tblProduct] ([product_id], [productName], [productPrice], [description], [type], [brand], [img]) VALUES (@product_id, @productName, @productPrice, @description, @type, @brand, @img)" UpdateCommand="UPDATE [tblProduct] SET [productName] = @productName, [productPrice] = @productPrice, [description] = @description, [type] = @type, [brand] = @brand, [img] = @img WHERE [product_id] = @product_id">
        <DeleteParameters>
            <asp:Parameter Name="product_id" Type="Int32" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="product_id" Type="Int32" />
            <asp:Parameter Name="productName" Type="String" />
            <asp:Parameter Name="productPrice" Type="Double" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="brand" Type="String" />
            <asp:Parameter Name="img" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="Guitar" Name="type" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="productName" Type="String" />
            <asp:Parameter Name="productPrice" Type="Double" />
            <asp:Parameter Name="description" Type="String" />
            <asp:Parameter Name="type" Type="String" />
            <asp:Parameter Name="brand" Type="String" />
            <asp:Parameter Name="img" Type="String" />
            <asp:Parameter Name="product_id" Type="Int32" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <%--<asp:TemplateField HeaderText="UploadImage">
                <ItemTemplate>
                    <asp:Image ImageUrl ='<%# Eval("img") %>' Width="100px" Height="100px" runat="server" ID="image" />
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:FileUpload ID="fileUploadEdit1" runat="server" />
                </EditItemTemplate>
            </asp:TemplateField>--%>
</asp:Content>
