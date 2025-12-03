<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>LMS - Default</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/site.css" rel="stylesheet" />
    <script src="https://cdn.jsdelivr.net/npm/jquery@3.6.0/dist/jquery.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</head>
<body>
    <nav class="navbar navbar-expand-lg navbar-dark bg-primary">
        <div class="container-fluid">
            <a class="navbar-brand" href="Default.aspx">LMS</a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav">
                <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarNav">
                <ul class="navbar-nav me-auto">
                    <li class="nav-item"><a class="nav-link" href="Home.aspx">Home</a></li>
                    <li class="nav-item"><a class="nav-link" href="About.aspx">About</a></li>
                </ul>
                <ul class="navbar-nav">
                    <asp:PlaceHolder ID="phAuth" runat="server">
                        <li class="nav-item"><a class="nav-link" href="../Auth/Login.aspx">Login</a></li>
                        <li class="nav-item"><a class="nav-link" href="../Auth/Register.aspx">Register</a></li>
                    </asp:PlaceHolder>
                </ul>
            </div>
        </div>
    </nav>
    <div class="container mt-4">
        <h1>Welcome to LMS</h1>
        <p>Please log in or register to access the system.</p>
    </div>
</body>
</html>