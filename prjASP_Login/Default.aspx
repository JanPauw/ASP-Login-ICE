<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="prjASP_Login._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Login Test Application</h1>
    </div>

    <asp:Table ID="Table1" runat="server" Width="418px" Height="209px">
    <asp:TableRow>
        <asp:TableCell>
            Email Address
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="edtEmail" runat="server"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            Password
        </asp:TableCell>
        <asp:TableCell>
            <asp:TextBox ID="edtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </asp:TableCell>
    </asp:TableRow>
    <asp:TableRow>
        <asp:TableCell>
            <asp:Button ID="btnSignUp" runat="server" Text="Sign Up" OnClick="Message_click"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="login_click"/>
        </asp:TableCell>
        <asp:TableCell>
            <asp:Label ID="Label1" runat="server" />
        </asp:TableCell>
    </asp:TableRow>
</asp:Table>

</asp:Content>
