<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ValidationDemo.aspx.cs" Inherits="AllValidatorsDemo.aspx.ValidationDemo" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Simple Validation Example</title>
</head>
<body>
<form runat="server">
    
    <!-- RequiredFieldValidator -->
    Name:
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="rfvName" runat="server"
        ControlToValidate="txtName"
        ErrorMessage="Name is required!"
        ForeColor="Red"></asp:RequiredFieldValidator>
    <br /><br />

    <!-- CompareValidator -->
    Age:
    <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
    <asp:CompareValidator ID="cvAge" runat="server"
        ControlToValidate="txtAge"
        Operator="DataTypeCheck"
        Type="Integer"
        ErrorMessage="Please enter a valid number!"
        ForeColor="Red"></asp:CompareValidator>
    <br /><br />

    <!-- RangeValidator -->
    Marks (0–100):
    <asp:TextBox ID="txtMarks" runat="server"></asp:TextBox>
    <asp:RangeValidator ID="rvMarks" runat="server"
        ControlToValidate="txtMarks"
        MinimumValue="0" MaximumValue="100"
        Type="Integer"
        ErrorMessage="Marks must be between 0 and 100!"
        ForeColor="Red"></asp:RangeValidator>
    <br /><br />

    <!-- RegularExpressionValidator -->
    Email:
    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
    <asp:RegularExpressionValidator ID="revEmail" runat="server"
        ControlToValidate="txtEmail"
        ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
        ErrorMessage="Invalid email format!"
        ForeColor="Red"></asp:RegularExpressionValidator>
    <br /><br />

    <!-- CompareValidator (match password) -->
    Password:
    <asp:TextBox ID="txtPwd" runat="server" TextMode="Password"></asp:TextBox><br />
    Confirm Password:
    <asp:TextBox ID="txtConfirmPwd" runat="server" TextMode="Password"></asp:TextBox>
    <asp:CompareValidator ID="cvPwd" runat="server"
        ControlToValidate="txtConfirmPwd"
        ControlToCompare="txtPwd"
        ErrorMessage="Passwords do not match!"
        ForeColor="Red"></asp:CompareValidator>
    <br /><br />

    <!-- CustomValidator -->
    Enter Number (must be even):
    <asp:TextBox ID="txtNumber" runat="server"></asp:TextBox>
    <asp:CustomValidator ID="cvEven" runat="server"
        ControlToValidate="txtNumber"
        OnServerValidate="cvEven_ServerValidate"
        ErrorMessage="Please enter an even number!"
        ForeColor="Red"></asp:CustomValidator>
    <br /><br />

    <!-- ValidationSummary -->
    <asp:ValidationSummary ID="vsSummary" runat="server"
        HeaderText="Please correct the following:"
        ForeColor="Red" />

    <br />
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
    <asp:Label ID="lblResult" runat="server" ForeColor="Green"></asp:Label>

</form>
</body>
</html>
