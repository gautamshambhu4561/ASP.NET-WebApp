<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="LoginForm.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p> successful login in this page
            </p>
            <asp:Label ID="lblWelcome" runat="server" Text="lblWelcome"></asp:Label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Logout" />
    </form>
</body>
</html>
