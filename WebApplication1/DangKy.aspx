<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="DangKy.aspx.cs" Inherits="WebApplication1.DangKy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5" style="max-width:500px;">
        <h3 class="text-center mb-4">Đăng ký tài khoản</h3>

        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-2" placeholder="Tên đăng nhập" />
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-2" TextMode="Password" placeholder="Mật khẩu" />
        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control mb-2" placeholder="Họ tên" />
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-3" placeholder="Email" />

        <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary w-100" 
                    Text="Đăng ký" OnClick="btnRegister_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger mt-2 d-block"></asp:Label>
    </div>

</asp:Content>
