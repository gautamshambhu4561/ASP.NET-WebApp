<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CalculatorApp.aspx.cs" Inherits="FormValidationForm.CalculatorApp" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Simple ASP.NET Calculator</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2> ASP.NET Web Form Calculator</h2>

        <asp:Label ID="lblNum1" runat="server" Text="Enter First Number:" /><br />
        <asp:TextBox ID="txtNum1" runat="server" /><br /><br />

        <asp:Label ID="lblNum2" runat="server" Text="Enter Second Number:" /><br />
        <asp:TextBox ID="txtNum2" runat="server" /><br /><br />

        <asp:DropDownList ID="ddlOperation" runat="server">
            <asp:ListItem Text="Add" Value="+" />
            <asp:ListItem Text="Subtract" Value="-" />
            <asp:ListItem Text="Multiply" Value="*" />
            <asp:ListItem Text="Divide" Value="/" />
        </asp:DropDownList><br /><br />

        <asp:Button ID="btnCalculate" runat="server" Text="Calculate" OnClick="btnCalculate_Click" /><br /><br />

        <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Green" /><br />
    </form>
</body>
</html>