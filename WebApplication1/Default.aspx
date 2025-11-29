<%@ Page Title="Trang chủ" Language="C#" MasterPageFile="~/Gdien.Master"
    AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <!-- TIN ĐĂNG MỚI NHẤT -->
    <h2 class="text-center" style="margin-top:40px;">TIN ĐĂNG MỚI NHẤT</h2>
    <hr />

    <div class="row">
        <asp:Repeater ID="rpTinDang" runat="server">
            <ItemTemplate>

                <div class="col-md-4 mb-4">
                    <div class="card h-100 d-flex flex-column shadow">

                        <!-- Ảnh tin đăng -->
                        <img class="card-img-top"
                             src='<%# ResolveUrl("~/" + Eval("HinhAnh")) %>'
                             style="height:200px; object-fit:cover;" />

                        <div class="card-body d-flex flex-column">

                            <h5 class="card-title"><%# Eval("TieuDe") %></h5>

                            <p class="card-text">
                                <strong>Giá:</strong> <%# Eval("Gia") %><br />
                                <strong>Địa chỉ:</strong> <%# Eval("DiaChi") %><br />
                                <strong>Mô tả:</strong> <%# Eval("MoTa") %>
                            </p>

                            <p class="mt-auto">
                                <small><i>Đăng ngày: <%# Eval("NgayDang", "{0:dd/MM/yyyy}") %></i></small>
                            </p>

                            <!-- Xem chi tiết -->
                            <a href='ChiTietTinDang.aspx?id=<%# Eval("ID") %>' class="btn btn-primary mt-2">
                                Xem chi tiết
                            </a>

                        </div>
                    </div>
                </div>

            </ItemTemplate>
        </asp:Repeater>
    </div>


   <!-- TIN TỨC MỚI NHẤT -->
<h2 class="text-center" style="margin-top:40px;">TIN TỨC MỚI NHẤT</h2>
<hr />

<asp:Repeater ID="rpTinTuc" runat="server">
    <ItemTemplate>

        <div class="row" style="margin-bottom:20px;">
            <div class="col-md-4">

                <!-- Ảnh tin tức -->
                <img src='<%# ResolveUrl("~/TinTucImages/" + Eval("AnhBia").ToString()) %>'
                     style="width: 200px; height:auto;"
                     alt="Ảnh tin tức" />

            </div>

            <div class="col-md-8">
                <h3><%# Eval("TieuDe") %></h3>
                <p><%# Eval("TomTat") %></p>
                <small><i>Ngày đăng: <%# Eval("NgayDang", "{0:dd/MM/yyyy}") %></i></small>

                <a href='TinTucChiTiet.aspx?id=<%# Eval("MaTinTuc") %>'
                   class="btn btn-outline-primary w-100 mt-2">
                    Xem chi tiết
                </a>
            </div>
        </div>

        <hr />

    </ItemTemplate>
</asp:Repeater>


</asp:Content>
