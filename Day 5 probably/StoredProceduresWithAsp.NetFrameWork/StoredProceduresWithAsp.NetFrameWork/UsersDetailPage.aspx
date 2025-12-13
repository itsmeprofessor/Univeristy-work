<%@ Page Title="" Language="C#" MasterPageFile="~/BootStrapMasterPage.Master" AutoEventWireup="true" CodeBehind="UsersDetailPage.aspx.cs" Inherits="StoredProceduresWithAsp.NetFrameWork.UsersDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="CPHTitle" runat="server">
    Users Details Page
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="CPHBodyForm" runat="server">
    <div class="w-75 mx-auto p-3">
        <div class ="mb-3">
            <asp:Label ID="LabId" runat="server" Text="Please Enter Your Id" CssClass="form-label"></asp:Label>
            <asp:DropDownList ID="DDLUsers" runat="server" CssClass="form-control"></asp:DropDownList>
            <div class="d-flex justify-content-center">
                <asp:Button ID="BtnSearch" runat="server" Text="Search" CssClass="btn btn-primary mt-3 " OnClick="BtnSearch_Click"/>
            </div>
        </div>
        <div class ="mb-3">
            <asp:Label ID="LabName" runat="server" Text="Please Enter Your Name" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class ="mb-3">
            <asp:Label ID="LabEmail" runat="server" Text="Please Enter Your Email" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class ="mb-3">
            <asp:Label ID="LabAddress" runat="server" Text="Please Enter Your Address" CssClass="form-label"></asp:Label>
            <asp:TextBox ID="TxtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class ="d-flex justify-content-center mb-3">
            <asp:Button ID="BtnSave" runat="server" Text="Save" CssClass="btn btn-success me-3 " OnClick="BtnSave_Click" />
            <asp:Button ID="BtnUpdate" runat="server" Text="Update" CssClass="btn btn-warning text-white me-3" OnClick="BtnUpdate_Click"/>
            <asp:Button ID="BtnDelete" runat="server" Text="Delete" CssClass="btn btn-danger me-3" OnClick="BtnDelete_Click"/>
            <asp:Button ID="BtnClear" runat="server" Text="Clear" CssClass="btn btn-info me-3" OnClick="BtnClear_Click"/>
        </div>
        <div class ="mb-3">
            <asp:Label ID="LabResult" runat="server" Text="" CssClass="form-label text-danger"></asp:Label>
        </div>
        <div class ="mb-3">
            <asp:GridView ID="GVUsers" runat="server" CssClass="table"></asp:GridView>
        </div>
    </div>
</asp:Content>
