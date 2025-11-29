<%@ Page Title="Đăng Tin" Language="C#" MasterPageFile="~/User/User.Master"
    AutoEventWireup="true" CodeBehind="ThemTinDang.aspx.cs" Inherits="WebApplication1.User.ThemTinDang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

<div class="container mt-4">

    <h3 class="mb-3">Đăng tin bất động sản</h3>

    <div class="row">
        <div class="col-md-7 card p-4 shadow-sm">

            <div class="mb-3">
                <label>Tiêu đề</label>
                <asp:TextBox ID="txtTieuDe" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label>Giá</label>
                <asp:TextBox ID="txtGia" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label>Địa chỉ</label>
                <asp:TextBox ID="txtDiaChi" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label>Mô tả</label>
                <asp:TextBox ID="txtMoTa" TextMode="MultiLine" CssClass="form-control" Rows="4" runat="server" />
            </div>

            <div class="mb-3">
                <label>Loại Nhà</label>
                <asp:DropDownList ID="ddlLoaiNha" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label>Loại BĐS</label>
                <asp:DropDownList ID="ddlLoaiBDS" CssClass="form-control" runat="server" />
            </div>

            <div class="mb-3">
                <label>Hình ảnh</label>
                <asp:FileUpload ID="fuHinhAnh" CssClass="form-control" runat="server" />
            </div>

            <asp:Button ID="btnThem" CssClass="btn btn-primary" Text="Đăng Tin"
                runat="server" OnClick="btnThem_Click" />

            <asp:Label ID="lblThongBao" CssClass="text-success mt-3 d-block" runat="server" />
        </div>
    </div>
</div>

</asp:Content>
