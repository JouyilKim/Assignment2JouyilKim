<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="AddProduct.aspx.cs" Inherits="MusicShop.WebForm6" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            text-align: right;
            width: 180px;
            font-size: 18px;
        }
        .auto-style2 {
            margin-left: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Button ID="btnEdit" runat="server" Text="Edit Products" Height="50px" Width="165px" OnClick="btnEdit_Click" />
    <table style="width:65%">
        <tr>
            <td colspan="2">
                <h1>Add Products</h1>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Product ID:&nbsp&nbsp&nbsp
            </td>
            <td>
                <asp:TextBox ID="txtProductID" runat="server" Enabled="false" Height="25px" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Product Name:&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:TextBox ID="txtProductName" runat="server" Height="25px" Width="290px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtProductName" ForeColor="Red" ErrorMessage="must fill the Name">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Product Price:&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:TextBox ID="txtProductPrice" runat="server" Height="25px" Width="290px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Description:&nbsp;&nbsp;&nbsp;

            </td>
            <td>
                <asp:TextBox ID="txtDescription" runat="server" Height="25px" Width="290px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Product Type:&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:DropDownList ID="dropdownType" runat="server" CssClass="auto-style2" >
                    <asp:ListItem>Guitar</asp:ListItem>
                    <asp:ListItem>Bass</asp:ListItem>
                    <asp:ListItem>Drum</asp:ListItem>
                    <asp:ListItem>Mic</asp:ListItem>
                    <asp:ListItem>Accessories</asp:ListItem>
                    <asp:ListItem>Others</asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Product Brand:&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:TextBox ID="txtBrand" runat="server" Height="25px" Width="290px"></asp:TextBox>
                
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                Image :&nbsp;&nbsp;&nbsp;</td>
            <td>
                <asp:FileUpload ID="fileUploadImg" runat="server" Width="290px" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">
                &nbsp;</td>
            <td>
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
        </tr>
        <tr>
            <td class="auto-style1">

                &nbsp;</td>
            <td>

                <asp:Button ID="btnAddProduct" runat="server" Text="Upload" Width="240px" OnClick="btnAddProduct_Click" />
            </td>
        </tr>
    </table>
</asp:Content>
