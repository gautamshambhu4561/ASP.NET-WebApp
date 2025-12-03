<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationForm.aspx.cs" Inherits="FormValidationForm.ValidationForm" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASP.NET Web Form Validation Example</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width: 500px; margin: 20px auto;">
        <h2>Registration Form</h2>

        <asp:Label ID="lblName" runat="server" Text="Name:"></asp:Label><br />
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvName" runat="server"
            ControlToValidate="txtName" ErrorMessage="Name is required!"
            ForeColor="Red" Display="Dynamic" SetFocusOnError="true" /><br /><br />

        <asp:Label ID="lblAge" runat="server" Text="Age:"></asp:Label><br />
        <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
        <asp:RangeValidator ID="rvAge" runat="server"
            ControlToValidate="txtAge" MinimumValue="18" MaximumValue="100" Type="Integer"
            ErrorMessage="Age must be between 18 and 100" ForeColor="Red" Display="Dynamic" /><br /><br />

        <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label><br />
        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        <asp:RegularExpressionValidator ID="revEmail" runat="server"
            ControlToValidate="txtEmail"
            ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
            ErrorMessage="Invalid email format!" ForeColor="Red" Display="Dynamic" /><br /><br />

        <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label><br />
        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
        <asp:RequiredFieldValidator ID="rfvPassword" runat="server"
            ControlToValidate="txtPassword" ErrorMessage="Password is required!"
            ForeColor="Red" Display="Dynamic" /><br /><br />

        <!-- Confirm Password Field -->
        <asp:Label ID="lblConfirm" runat="server" Text="Confirm Password:"></asp:Label><br />
        <asp:TextBox ID="txtConfirm" runat="server" TextMode="Password"></asp:TextBox>
        <asp:CompareValidator ID="cvPassword" runat="server"
            ControlToValidate="txtConfirm" ControlToCompare="txtPassword"
            ErrorMessage="Passwords do not match!" ForeColor="Red" Display="Dynamic" /><br /><br />

        <!-- Custom Validation Field -->
        <asp:Label ID="lblCustom" runat="server" Text="Custom Code (must be 'ABC123'):"></asp:Label><br />
        <asp:TextBox ID="txtCustom" runat="server"></asp:TextBox>
        <asp:CustomValidator ID="cvCustom" runat="server"
            ControlToValidate="txtCustom" ErrorMessage="Code must be 'ABC123'"
            OnServerValidate="cvCustom_ServerValidate" ForeColor="Red" Display="Dynamic" /><br /><br />

        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" /><br /><br />

        <!-- Validation Summary -->
        <asp:ValidationSummary ID="vsSummary" runat="server" ForeColor="Red" HeaderText="Please correct the following errors:" />
    </div>
    </form>
</body>
</html>

