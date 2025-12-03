<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="SimpleLoginForm.LoginForm" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>Bootstrap Test</title>
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" />
    <script src="~/Scripts/jquery.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h3>Login Here</h3>
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
            </div>
            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-success" OnClick="btnLogin_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>
        </div>
    </form>
</body>
</html>
