<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupportForm.aspx.cs" Inherits="WebFormApplication.SupportForm" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SupportForm</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>SupportForm</h1>
            <p>
                <asp:Literal ID="ltMessage" runat="server"></asp:Literal>
            </p>
            <p>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtFirstName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="RequiredFieldValidator" ForeColor="Red">First name is required.</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtLastName" runat="server"></asp:TextBox>
            </p>
            <p>
                <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="valEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="RequiredFieldValidator" ForeColor="Red">Email is required.</asp:RequiredFieldValidator>
            </p>
            <p>
                <asp:Label ID="lblDesc" runat="server" Text="Description:"></asp:Label>
            </p>
            <p>
                <asp:TextBox ID="txtDesc" runat="server" Height="101px" TextMode="MultiLine" Width="417px"></asp:TextBox>
            </p>
            <p>&nbsp;</p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
            </p>
        </div>
    </form>
</body>
</html>
