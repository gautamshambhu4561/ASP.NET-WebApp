<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Edit.aspx.cs" Inherits="WebFormCRUD.Edit" %>
<html>
<body>
    <form runat="server">
        Name: <asp:TextBox ID="txtName" runat="server" /><br />
        Email: <asp:TextBox ID="txtEmail" runat="server" /><br />
        Course: <asp:TextBox ID="txtCourse" runat="server" /><br />
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </form>
</body>
</html>

