<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="WebApplication1.DangNhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5" style="max-width:400px;">
        <h3 class="text-center mb-4">Đăng nhập</h3>

        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-2" placeholder="Tên đăng nhập" />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-3" TextMode="Password" placeholder="Mật khẩu" />

        <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary w-100"
                    Text="Đăng nhập" OnClick="BtnLogin_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2 d-block"></asp:Label>
    </div>

</asp:Content>
