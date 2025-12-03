<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="SubmitAssignment.aspx.cs" Inherits="LMSProject.Student.SubmitAssignment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2 class="mb-4">Submit Assignment</h2>
    <div class="mb-3">
        <label for="fuSubmission" class="form-label">Upload Submission</label>
        <asp:FileUpload ID="fuSubmission" runat="server" CssClass="form-control" />
    </div>
    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
