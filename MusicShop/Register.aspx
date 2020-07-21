<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="MusicShop.WebForm3" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <table style="width:60%">
        <tr>
            <td>Email Address: </td>
            <td>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                 <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" 
                        ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="Email address must be entered and it should be in correct formant">
                        *
                    </asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>Password: </td>
            <td>
                <asp:TextBox ID="txtPWD" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtPWD" ErrorMessage="Password must be entered" ForeColor="Red">*

                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Confirm Password: </td>
            <td>
                <asp:TextBox ID="txtPWDConfirm" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToCompare="txtPWD" ControlToValidate="txtPWDConfirm" ErrorMessage="Password and Confirm Password must be same" ForeColor="Red">*

                    </asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Name: </td>
            <td>
                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        ControlToValidate="txtName" runat="server" ErrorMessage="Please enter your name" ForeColor="Red">*
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Address: </td>
            <td>
                <asp:TextBox ID="txtAdd" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtAdd" ErrorMessage="Please enter your name" ForeColor="Red">*
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Phone Number: </td>
            <td>
                <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtPhone" ErrorMessage="Please enter your name" ForeColor="Red">*
                    </asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
            </td>
            
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblRegister" ForeColor="Red" runat="server"></asp:Label></td>
            <td>
                <asp:Button ID="btnRegister" runat="server" OnClick="Button1_Click" Text="Register" Width="107px" />
            </td>
        </tr>
    </table>
</asp:Content>
