<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MusicShop.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table style="text-align:center; padding:50px" >
        <tr>
            <td>
                <asp:Label ID="lblName" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="linkEditProduct" runat="server" OnClick="linkDefault1_Click"></asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="LinkEditUser" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
            </td>
        </tr>
    </table>
    </asp:Content>
