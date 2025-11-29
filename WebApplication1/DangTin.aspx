<%@ Page Title="Đăng Tin" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="DangTin.aspx.cs" Inherits="WebApplication1.DangTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4" style="max-width: 700px;">

    <h3 class="mb-4 text-center">Đăng Tin Bất Động Sản</h3>

    <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

    <!-- TIÊU ĐỀ -->
    <div class="mb-3">
        <label>Tiêu đề</label>
        <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- ĐỊA CHỈ -->
    <div class="mb-3">
        <label>Địa chỉ</label>
        <asp:TextBox ID="txtDiaChi" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <!-- GIÁ + SỐ ĐIỆN THOẠI TRÊN CÙNG 1 HÀNG -->
    <div class="row">
    <!-- GIÁ -->
    <div class="col-md-6 mb-3">
        <label>Giá</label>
        <asp:TextBox ID="txtGia" runat="server" CssClass="form-control"></asp:TextBox>
    </div>

    <!-- SỐ ĐIỆN THOẠI -->
    <div class="col-md-6 mb-3">
        <label>Số điện thoại</label>
        <asp:TextBox ID="txtSDT" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
</div>

    <!-- MÔ TẢ -->
    <div class="mb-3">
        <label>Mô tả</label>
        <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" Rows="4" CssClass="form-control"></asp:TextBox>
    </div>
    

    <!-- LOẠI NHÀ ĐẤT -->
    <div class="mb-3">
        <label>Loại nhà đất</label>
        <asp:DropDownList ID="ddlLoai" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <!-- LOẠI BẤT ĐỘNG SẢN (BÁN / CHO THUÊ...) -->
    <div class="mb-3">
        <label>Loại BĐS (Hình thức giao dịch)</label>
        <asp:DropDownList ID="ddlLoaiBDS" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>


    <!-- ẢNH XEM TRƯỚC (1 ảnh đầu tiên) -->
    <label>Ảnh xem trước</label>
    <asp:Image ID="imgPreview" runat="server"
    CssClass="img-thumbnail mb-3"
    Style="width:200px; height:150px; object-fit:cover; border:1px solid #ccc;" />

    <!-- UPLOAD NHIỀU ẢNH -->
    <div class="mb-3">
        <label>Chọn ảnh (có thể chọn nhiều)</label>
        <asp:FileUpload ID="fileAnh" runat="server" AllowMultiple="true" CssClass="form-control" />
    </div>

    <!-- NÚT ĐĂNG TIN -->
    <asp:Button ID="btnDangTin" runat="server"
        Text="Đăng Tin"
        CssClass="btn btn-primary w-100"
        OnClick="btnDangTin_Click" />

</div>

</asp:Content>
