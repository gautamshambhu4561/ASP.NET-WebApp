<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Instructor.Master" AutoEventWireup="true" CodeBehind="ViewStudents.aspx.cs" Inherits="LMSProject.Instructor.ViewStudents" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">View Students</h2>
    <div class="mb-3">
        <label for="ddlCourse" class="form-label">Course</label>
        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <asp:GridView ID="gvStudents" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="UserID" HeaderText="ID" />
            <asp:BoundField DataField="Name" HeaderText="Name" />
            <asp:BoundField DataField="Email" HeaderText="Email" />
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
