<%@ Page Title="Chi tiết tin đăng" Language="C#" MasterPageFile="~/Gdien.Master"
    AutoEventWireup="true" CodeBehind="ChiTietTinDang.aspx.cs" Inherits="WebApplication1.ChiTietTinDang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:40px;">

        <!-- TIÊU ĐỀ -->
        <h2 class="text-center mb-4"><asp:Label ID="lblTieuDe" runat="server"></asp:Label></h2>

        <div class="row">

            <!-- CỘT TRÁI : ẢNH -->
            <div class="col-md-7 text-center">
                <asp:Image ID="imgHinh" runat="server"
                    Width="100%" Height="400px"
                    Style="object-fit:cover; border-radius:10px;" />
            </div>

            <!-- CỘT PHẢI : THÔNG TIN -->
            <div class="col-md-5">

                <h3>Thông tin chi tiết</h3>

                <p><strong>Giá:</strong> <asp:Label ID="lblGia" runat="server" /></p>
                <p><strong>Địa chỉ:</strong> <asp:Label ID="lblDiaChi" runat="server" /></p>
                <p><strong>Số điện thoại:</strong> <asp:Label ID="lblSDT" runat="server" /></p>
                <p><strong>Loại nhà đất:</strong> <asp:Label ID="lblLoai" runat="server" /></p>
                <p><strong>Hình thức giao dịch:</strong> <asp:Label ID="lblHinhThuc" runat="server" /></p>
                <p><strong>Mô tả:</strong></p>
                <p><strong>Người đăng:</strong> <asp:Label ID="lblNguoiDang" runat="server" /></p>


                <div style="white-space:pre-line; border:1px solid #ddd; padding:10px; border-radius:5px;">
                    <asp:Label ID="lblMoTa" runat="server" />
                </div>

            </div>

        </div>

        <!-- ẢNH PHỤ -->
        <h4 class="mt-5">Hình ảnh khác</h4>
        <div class="row mt-3">
            <asp:Repeater ID="rpAnhChiTiet" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-3">
                        <img src='<%# ResolveUrl("~/") + Eval("ImagePath") %>'
                             style="width:100%; height:150px; object-fit:cover; border-radius:8px;" />
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

</asp:Content>
