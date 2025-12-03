<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Student.Master" AutoEventWireup="true" CodeBehind="EnrollCourse.aspx.cs" Inherits="LMSProject.Student.EnrollCourse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Enroll in Courses</h2>
    <div class="row">
        <asp:Repeater ID="rptCourses" runat="server">
            <ItemTemplate>
                <div class="col-md-4 mb-4">
                    <div class="card h-100">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Title") %></h5>
                            <p class="card-text"><%# Eval("Description") %></p>
                            <asp:Button ID="btnEnroll" runat="server" Text="Enroll" CssClass="btn btn-primary" CommandArgument='<%# Eval("CourseID") %>' OnCommand="btnEnroll_Click" Visible='<%# !IsEnrolled(Convert.ToInt32(Eval("CourseID"))) %>' />
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
