<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Adding2Numbers.aspx.cs" Inherits="LoginFormwithADO.Adding2Numbers" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Add Numbers and Save to UserDB</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="margin: 40px;">
            <h2>Add Two Numbers</h2>
            <asp:Label ID="lblFirst" runat="server" Text="First Number: "></asp:Label>
            <asp:TextBox ID="txtFirst" runat="server"></asp:TextBox><br /><br />

            <asp:Label ID="lblSecond" runat="server" Text="Second Number: "></asp:Label>
            <asp:TextBox ID="txtSecond" runat="server"></asp:TextBox><br /><br />

            <asp:Button ID="btnAdd" runat="server" Text="Add and Save" OnClick="btnAdd_Click" /><br /><br />

            <asp:Label ID="lblResult" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>
        </div> 
    </form>
</body>
</html>
