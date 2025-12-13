<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="AuthenticationNAuthorization.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabEmail" runat="server" Text="Enter Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabPassword" runat="server" Text="Enter Password:"></asp:Label>
            <asp:TextBox ID="TxtPassword" runat="server" TextMode="Password"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnLogin" runat="server" Text="Login" OnClick="BtnLogin_Click" />
        </div>
        <div>
            <asp:Label ID="LabResult" runat="server" />
        </div>
    </form>
</body>
</html>
