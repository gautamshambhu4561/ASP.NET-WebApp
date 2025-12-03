<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Quiz.aspx.cs" Inherits="FormValidationForm.Quiz" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="lblQuestion" runat="server" Font-Bold="true" />
<br /><br />

<asp:RadioButtonList ID="rblOptions" runat="server" />
<br />

<asp:Button ID="btnNext" runat="server" Text="Next" OnClick="btnNext_Click" />

        </div>
    </form>
</body>
</html>
