<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LMSProject.Auth.Login" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Login - LMS</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/site.css" rel="stylesheet" />
    <script src="../Scripts/validations.js"></script>
</head>
<body>
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <h2 class="mb-4 text-center">Login</h2>
                <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
                <div class="card">
                    <div class="card-body">
                        <form id="form1" runat="server">
                            <div class="mb-3">
                                <label for="txtEmail" class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" />
                            </div>
                            <div class="mb-3">
                                <label for="txtPassword" class="form-label">Password</label>
                                <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" />
                            </div>
                            <asp:Button ID="btnLogin" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="btnLogin_Click" OnClientClick="return validateLogin();" />
                        </form>
                        <p class="mt-3 text-center"><a href="Register.aspx">Register</a></p>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
