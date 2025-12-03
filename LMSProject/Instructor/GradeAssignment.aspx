<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Instructor.Master" AutoEventWireup="true" CodeBehind="GradeAssignment.aspx.cs" Inherits="LMSProject.Instructor.GradeAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Grade Assignments</h2>
    <div class="mb-3">
        <label for="ddlCourse" class="form-label">Course</label>
        <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCourse_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <asp:GridView ID="gvSubmissions" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered">
        <Columns>
            <asp:BoundField DataField="SubmissionID" HeaderText="ID" />
            <asp:BoundField DataField="UserName" HeaderText="Student Name" />
            <asp:BoundField DataField="FilePath" HeaderText="File" />
            <asp:TemplateField HeaderText="Grade">
                <ItemTemplate>
                    <asp:TextBox ID="txtGrade" runat="server" CssClass="form-control" Text='<%# Eval("Grade") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:Button ID="btnSaveGrade" runat="server" Text="Save Grade" CssClass="btn btn-primary btn-sm" CommandArgument='<%# Eval("SubmissionID") %>' OnCommand="btnSaveGrade_Click" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
