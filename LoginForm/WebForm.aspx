<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm.aspx.cs" Inherits="LoginForm.WebForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login Form</title>
    <style type="text/css">
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .login-container {
            width: 350px;
            margin: 80px auto;
            padding: 30px;
            background-color: #ffffff;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            border-radius: 8px;
        }

        h2 {
            text-align: center;
            color: #333;
        }

        table {
            width: 100%;
        }

        td {
            padding: 10px 5px;
        }

        input[type="text"],
        input[type="password"] {
            width: 95%;
            padding: 8px;
            border: 1px solid #ccc;
            border-radius: 4px;
        }

        .login-button {
            width: 100%;
            padding: 10px;
            background-color: #007bff;
            color: white;
            border: none;
            border-radius: 4px;
            font-weight: bold;
            cursor: pointer;
        }

            .login-button:hover {
                background-color: #0056b3;
            }

        .error-message {
            color: red;
            font-weight: bold;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <table>
                <tr>
                    <td>Username</td>
                    <td>
                        <asp:TextBox ID="userName" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="userPassword" runat="server" TextMode="password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center;">
                        <asp:Button ID="Button1" runat="server" Text="Login" CssClass="login-button" OnClick="Button1_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Label ID="lblMessage" runat="server" CssClass="error-message"></asp:Label>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
