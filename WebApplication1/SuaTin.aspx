<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="SuaTin.aspx.cs" Inherits="WebApplication1.SuaTin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4" style="max-width: 700px;">

    <h3 class="mb-4 text-center">Sửa Tin Đăng</h3>

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

    <!-- GIÁ + SỐ ĐIỆN THOẠI -->
    <div class="row">
        <div class="col-md-6 mb-3">
            <label>Giá</label>
            <asp:TextBox ID="txtGia" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

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

    <!-- LOẠI -->
    <div class="mb-3">
        <label>Loại Nhà Đất</label>
        <asp:DropDownList ID="ddlLoai" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <label>Loại BĐS</label>
        <asp:DropDownList ID="ddlLoaiBDS" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>

  <h5 class="mt-4">Hình ảnh hiện tại</h5>

<div style="display:flex; flex-wrap:wrap; gap:20px; padding-left:5px;">

    <asp:Repeater ID="rpAnh" runat="server">
        <ItemTemplate>

            <div style="width:130px; text-align:center;">

                <img src="/<%# Eval("ImagePath") %>" 
                     style="width:130px; height:95px; object-fit:cover;
                            border:1px solid #ccc; border-radius:4px;" />

                <asp:LinkButton ID="btnDeleteImg" runat="server"
                    Text="Xóa"
                    CssClass="btn btn-sm btn-danger mt-2"
                    CommandName="deleteImg"
                    CommandArgument='<%# Eval("IDImages") %>'
                    OnClientClick="return confirm('Bạn muốn xoá ảnh này?');" />

            </div>

        </ItemTemplate>
    </asp:Repeater>

</div>


    <!-- ẢNH BÌA -->
    <h5 class="mt-4">Ảnh bìa hiện tại</h5>
    <img id="imgAnhBia" runat="server"
         style="width:150px; height:100px; object-fit:cover; border:1px solid #ccc;" />

    <!-- UPLOAD ẢNH BÌA -->
    <div class="mb-3 mt-2">
        <label>Thay ảnh bìa mới</label>
        <asp:FileUpload ID="fuAnhBia" runat="server" CssClass="form-control" />
    </div>

    <!-- UPLOAD ẢNH PHỤ MỚI -->
    <div class="mb-3 mt-3">
        <label>Thêm ảnh mới</label>
        <asp:FileUpload ID="fileAnh" AllowMultiple="true" runat="server" CssClass="form-control" />
    </div>

    <asp:Button ID="btnLuu" runat="server" Text="Cập nhật"
        CssClass="btn btn-primary w-100" OnClick="btnLuu_Click" />

</div>

</asp:Content>
