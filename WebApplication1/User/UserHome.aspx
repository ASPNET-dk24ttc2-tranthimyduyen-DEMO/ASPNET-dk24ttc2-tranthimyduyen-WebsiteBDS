<%@ Page Title="Trang cá nhân" Language="C#" MasterPageFile="~/Gdien.Master"
    AutoEventWireup="true" CodeBehind="UserHome.aspx.cs" Inherits="WebApplication1.UserHome" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h2>Xin chào, <asp:Label ID="lblUser" runat="server"></asp:Label> 👋</h2>
        <hr />

        <div class="row mt-4">

            <!-- Đăng tin -->
            <div class="col-md-4">
                <a href="DangTin.aspx" class="btn btn-primary w-100">Đăng Tin Mới</a>
            </div>

            <!-- Quản lý cá nhân -->
            <div class="col-md-4">
                <a href="ThongTinCaNhan.aspx" class="btn btn-success w-100">Quản Lý Cá Nhân</a>
            </div>

            <!-- Quản lý tin đã đăng -->
            <div class="col-md-4">
                <a href="QuanLyTin.aspx" class="btn btn-warning w-100">Quản Lý Tin Đã Đăng</a>
            </div>

        </div>
    </div>

</asp:Content>
