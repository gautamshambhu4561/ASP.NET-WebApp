<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="SimpleLoginForm.RegistrationForm" %>
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
            <h3>Register Here</h3>
            <div class="form-group">
                <label>Username:</label>
                <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" placeholder="Enter Username"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Password:</label>
                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="Enter Password"></asp:TextBox>
            </div>
            <div class="form-group">
                <label>Email:</label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" placeholder="Enter Email"></asp:TextBox>
            </div>
            <asp:Button ID="btnRegister" runat="server" Text="Register" CssClass="btn btn-primary" OnClick="btnRegister_Click" />
            <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>
        </div>
    </form>
</body>
</html>
