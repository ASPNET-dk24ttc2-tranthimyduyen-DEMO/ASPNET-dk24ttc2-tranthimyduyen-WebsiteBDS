<%@ Page Title="Thông Tin Cá Nhân" Language="C#" MasterPageFile="~/User/User.Master"
    AutoEventWireup="true" CodeBehind="ThongTinCaNhan.aspx.cs"
    Inherits="WebApplication1.User.ThongTinCaNhan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4">
        <h3 class="mb-3">Thông Tin Cá Nhân</h3>

        <asp:Label ID="lblMsg" runat="server" CssClass="text-success"></asp:Label>

        <div class="row">
            <div class="col-md-6">

                <div class="form-group mb-3">
                    <label>Họ và Tên</label>
                    <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Tên đăng nhập</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                </div>

                <asp:Button ID="btnLuu" runat="server" CssClass="btn btn-primary" Text="Lưu Thông Tin"
                    OnClick="btnLuu_Click" />
            </div>

            <div class="col-md-6">
                <h5>Đổi Mật Khẩu</h5>

                <div class="form-group mb-3">
                    <label>Mật khẩu hiện tại</label>
                    <asp:TextBox ID="txtOldPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="form-group mb-3">
                    <label>Mật khẩu mới</label>
                    <asp:TextBox ID="txtNewPass" TextMode="Password" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <asp:Button ID="btnDoiMatKhau" runat="server" CssClass="btn btn-warning"
                    Text="Đổi Mật Khẩu" OnClick="btnDoiMatKhau_Click" />
            </div>
        </div>
    </div>
</asp:Content>
