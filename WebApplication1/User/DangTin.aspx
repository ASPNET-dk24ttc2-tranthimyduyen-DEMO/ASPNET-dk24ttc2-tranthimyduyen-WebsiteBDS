<%@ Page Title="Đăng Tin Mới" Language="C#" MasterPageFile="~/User/User.Master"
    AutoEventWireup="true" CodeBehind="DangTin.aspx.cs"
    Inherits="WebApplication1.User.DangTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

<div class="container mt-4">
    <h3 class="mb-3">Đăng Tin Mới</h3>

    <asp:Label ID="lblMsg" runat="server" CssClass="text-success fw-bold"></asp:Label>

    <div class="row">
        <div class="col-md-8">

            <div class="form-group mb-3">
                <label>Tiêu đề</label>
                <asp:TextBox ID="txtTieuDe" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label>Giá</label>
                <asp:TextBox ID="txtGia" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label>Địa chỉ</label>
                <asp:TextBox ID="txtDiaChi" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label>Mô tả</label>
                <asp:TextBox ID="txtMoTa" TextMode="MultiLine" Rows="4"
                    CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="form-group mb-3">
                <label>Loại Nhà Đất</label>
                <asp:DropDownList ID="ddlLoai" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group mb-3">
                <label>Loại BĐS</label>
                <asp:DropDownList ID="ddlLoaiBDS" CssClass="form-control" runat="server"></asp:DropDownList>
            </div>

            <div class="form-group mb-3">
                <label>Hình ảnh</label>
                <asp:FileUpload ID="fuAnh" CssClass="form-control" runat="server" />
            </div>

            <asp:Button ID="btnDangTin" runat="server" CssClass="btn btn-success"
                Text="Đăng Tin" OnClick="btnDangTin_Click" />

        </div>
    </div>
</div>

</asp:Content>
