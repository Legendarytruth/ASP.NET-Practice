<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewsletterSignup.aspx.cs" Inherits="WebFormsApplication.NewsletterSignup" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Newsletter Signup</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
          <h1>Newsletter Signup</h1>
            <p>
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </p>
        </div>
        <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
&nbsp;&nbsp;
        <asp:TextBox ID="txtEmail" runat="server" ViewStateMode="Disabled"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btnSubmit" runat="server"  OnClick="btnSubmit_Click" Text="Submit" />
    </form>
</body>
</html>
