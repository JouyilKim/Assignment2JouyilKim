<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="ProductDetail.aspx.cs" Inherits="MusicShop.WebForm8" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 732px;
            
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table id="tblProduct">
        <tr>
            <td rowspan="2" class="auto-style1" style="border:solid; border-color:black">

                <asp:Image ID="ImageProduct" runat="server" Width="350px" Height="350px" />

            </td>
            <td id="tdName" style="border:solid; border-color:black">

                <asp:Label ID="lblProductName" runat="server" Font-Size="X-Large" ></asp:Label>

            </td>
        </tr>

        <tr>
            <td id="tdPrice" style="border:solid; border-color:black" >
                <asp:Label ID="lblPrice" runat="server" Font-Size="XX-Large" ></asp:Label>
            </td>
        </tr>
        <tr>
            <td id="tdDescription" colspan="2" style="border:solid; border-color:black">
                <pre>

                </pre>
                <asp:Label ID="lblDescription" runat="server" Font-Size="Larger" ></asp:Label>
                <pre>

                </pre>
            </td>
        </tr>
        <tr>
            <td class="auto-style1" style="text-align:right">
                <asp:Label ID="lblQuantity" runat="server" Text="select how many you want:  "></asp:Label>
                <asp:DropDownList ID="dropdownQuantity" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td style="text-align:right; border:dotted; border-color:black">
                <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" Font-Size="X-Large" OnClick="btnAddToCart_Click"/>
            </td>
        </tr>
    </table>
</asp:Content>
