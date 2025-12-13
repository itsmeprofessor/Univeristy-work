<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="StoredProceduresWithAsp.NetFrameWork.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LabId" runat="server" Text="Please Enter Your Id"> </asp:Label>
            <asp:DropDownList ID="DDLUsers" runat="server"></asp:DropDownList>
            <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
        </div>
        <div>
            <asp:Label ID="LabName" runat="server" Text="Please Enter Your Name"> </asp:Label>
            <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabEmail" runat="server" Text="Please Enter Your Email"> </asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LabAddress" runat="server" Text="Please Enter Your Address"> </asp:Label>
            <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="BtnSave" runat="server" Text="Save" OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" OnClick="BtnUpdate_Click" />
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" OnClick="BtnDelete_Click"/>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" OnClick="BtnClear_Click" />
        </div>
        <div>
            <asp:Label ID="LabResult" runat="server" Text=""> </asp:Label>
        </div>
        <div>
            <asp:GridView ID="GVUsers" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
