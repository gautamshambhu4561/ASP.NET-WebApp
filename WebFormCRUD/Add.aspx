<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add.aspx.cs" Inherits="WebFormCRUD.Add" %>
<html>
<body>
    <form runat="server">
        Name: <asp:TextBox ID="txtName" runat="server" /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server" /><br />
        Course: <asp:TextBox ID="txtCourse" runat="server" /><br />
        <asp:Button ID="btnAdd" runat="server" Text="Add Student" OnClick="btnAdd_Click" />
    </form>
</body>
</html>

