<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="LMSProject.Student.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Student Dashboard</h2>
    <p>Welcome, <asp:Label ID="lblUserName" runat="server" Text="" /></p>
</asp:Content>
