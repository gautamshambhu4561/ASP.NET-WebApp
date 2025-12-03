<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMSProject.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Admin Dashboard</h2>
    <p>Welcome, <asp:Label ID="lblUserName" runat="server" Text="" /></p>
    <asp:GridView ID="gvUserStats" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="Role" HeaderText="Role" />
            <asp:BoundField DataField="Count" HeaderText="Number of Users" />
        </Columns>
    </asp:GridView>

</asp:Content>
