<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Admin.Master" AutoEventWireup="true" CodeBehind="ManageAnnouncements.aspx.cs" Inherits="LMSProject.Admin.ManageAnnouncements" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<h2 class="mb-4">Manage Announcements</h2>
    <div class="mb-3">
        <label for="txtTitle" class="form-label">Title</label>
        <asp:TextBox ID="txtTitle" runat="server" CssClass="form-control" />
    </div>
    <div class="mb-3">
        <label for="txtContent" class="form-label">Content</label>
        <asp:TextBox ID="txtContent" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="4" />
    </div>
    <asp:DropDownList ID="ddlCourse" runat="server" CssClass="form-control mb-3" AppendDataBoundItems="true">
        <asp:ListItem Value="0" Text="Select Course" />
    </asp:DropDownList>
    <asp:Button ID="btnAddAnnouncement" runat="server" Text="Add Announcement" CssClass="btn btn-primary" OnClick="btnAddAnnouncement_Click" />
    <asp:GridView ID="gvAnnouncements" runat="server" AutoGenerateColumns="false" CssClass="table table-bordered mt-3">
        <Columns>
            <asp:BoundField DataField="AnnouncementID" HeaderText="ID" />
            <asp:BoundField DataField="Title" HeaderText="Title" />
            <asp:BoundField DataField="Content" HeaderText="Content" />
            <asp:BoundField DataField="PostedDate" HeaderText="Posted Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
            <asp:BoundField DataField="CourseTitle" HeaderText="Course" />
        </Columns>
    </asp:GridView>
    <div id="errorMessage" class="alert alert-danger d-none" runat="server"></div>
</asp:Content>
