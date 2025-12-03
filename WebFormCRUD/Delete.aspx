<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Delete.aspx.cs" Inherits="WebFormCRUD.Delete" %>
<html>
<body>
    <form runat="server">
        <asp:Label ID="lblConfirm" runat="server" Text="Are you sure you want to delete this record?" /><br />
        <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    </form>
</body>
</html>

