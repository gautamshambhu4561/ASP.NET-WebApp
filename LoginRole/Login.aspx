<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginRole.Login" %>
<html>
<body>
    <form runat="server">
        Username: <asp:TextBox ID="txtUsername" runat="server" /><br />
        Password: <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /><br />
        <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </form>
</body>
</html>

