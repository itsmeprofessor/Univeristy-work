<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Users.aspx.cs" Inherits="ThirdWebApp.Users" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form2" runat="server">
        <table>
            <tr>
                <td>
                    <asp:Label ID="LabId" Text="Please Enter Your Id" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="DDLUsers" runat="server" ></asp:DropDownList>
                </td>
                <td>
                    <asp:Button ID="BtnSearch" Text="Search"  OnClick="BtnSearch_Click" runat="server"/>
                </td>
            </tr>
            
            <tr>
                <td>
                    <asp:Label ID="LabName" Text="Please Enter Your Name" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtName" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabEmail" Text="Please Enter Your Email" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="LabAddress" Text="Please Enter Your Address" runat="server"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="TxtAddress" runat="server"></asp:TextBox>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="BtnInsert" Text="Insert" runat="server" OnClick="BtnInsert_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnUpdate" Text="Update" runat="server" OnClick="BtnUpdate_Click" />
                </td>
                <td>
                    <asp:Button ID="BtnDelete" Text="Delete" runat="server" OnClick="BtnDelete_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:Label ID="LabResult" Text="" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:GridView ID ="DGVUsers" runat="server"></asp:GridView>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>