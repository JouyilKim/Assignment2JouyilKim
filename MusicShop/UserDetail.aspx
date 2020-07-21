<%@ Page Title="" Language="C#" MasterPageFile="~/Master.Master" AutoEventWireup="true" CodeBehind="UserDetail.aspx.cs" Inherits="MusicShop.WebForm9" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table>
        <tr>
            <td>
                <asp:Button ID="btnHistory" runat="server" Text="See your Order History" PostBackUrl="OrderHistory.aspx" />
            </td>
        </tr>
        <tr>
            <td>
                <h2>
                   Edit User Detail
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
                        <Columns>
                            <asp:CommandField ShowEditButton="True" />
                            <asp:BoundField DataField="email" HeaderText="email" SortExpression="email" />
                            <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" Visible="false" />
                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                            <asp:BoundField DataField="address" HeaderText="address" SortExpression="address" />
                            <asp:BoundField DataField="phone" HeaderText="phone" SortExpression="phone" />
                        </Columns>
                    </asp:GridView>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [tblUser] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblUser] ([email], [Id], [name], [address], [phone]) VALUES (@email, @Id, @name, @address, @phone)" SelectCommand="SELECT [email], [Id], [name], [address], [phone] FROM [tblUser] WHERE ([ID] = @user_id)" UpdateCommand="UPDATE [tblUser] SET [email] = @email, [name] = @name, [address] = @address, [phone] = @phone WHERE [Id] = @Id">
                        <DeleteParameters>
                            <asp:Parameter Name="Id" Type="Int32" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="Id" Type="Int32" />
                            <asp:Parameter Name="name" Type="String" />
                            <asp:Parameter Name="address" Type="String" />
                            <asp:Parameter Name="phone" Type="Int32" />
                        </InsertParameters>
                        <SelectParameters>
                            <asp:CookieParameter CookieName="user_id" Name="user_id" />
                        </SelectParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="email" Type="String" />
                            <asp:Parameter Name="name" Type="String" />
                            <asp:Parameter Name="address" Type="String" />
                            <asp:Parameter Name="phone" Type="Int32" />
                            <asp:Parameter Name="Id" Type="Int32" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                </h2>
            </td>
        </tr>
    </table>
</asp:Content>
