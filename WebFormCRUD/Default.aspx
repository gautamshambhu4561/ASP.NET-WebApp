<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFormCRUD.Default" %>
<html>
<body>
    <form runat="server">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="false" DataKeyNames="Id">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="ID" ReadOnly="true" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:BoundField DataField="Course" HeaderText="Course" />
                <asp:HyperLinkField Text="Edit" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Edit.aspx?id={0}" />
                <asp:HyperLinkField Text="Delete" DataNavigateUrlFields="Id" DataNavigateUrlFormatString="Delete.aspx?id={0}" />
            </Columns>
        </asp:GridView>
        <a href="Add.aspx">Add New Student</a>
    </form>
</body>
</html>

