<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="ViewGrades.aspx.cs" Inherits="LMSProject.Student.ViewGrades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">View Grades</h2>
    <asp:GridView ID="gvGrades" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="AssignmentID" HeaderText="Assignment ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Grade" HeaderText="Grade" />
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
