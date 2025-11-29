<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master"
    AutoEventWireup="true" CodeBehind="TinTucChiTiet.aspx.cs"
    Inherits="WebApplication1.TinTucChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container" style="margin-top:30px;">

        <asp:Panel ID="pnlTin" runat="server" Visible="false">

            <h2 class="text-center" style="margin-bottom:20px;">
                <asp:Label ID="lblTieuDe" runat="server"></asp:Label>
            </h2>

         
              <!-- Ảnh bìa -->
            <img id="imgAnhBia" runat="server"
                 class="img-thumbnail"
                 style="width:100%; height:300px; object-fit:cover;" />



            <p style="margin-top:15px; font-size:16px;">
                <strong>Ngày đăng:</strong> 
                <asp:Label ID="lblNgayDang" runat="server"></asp:Label>
                <br />
                <strong>Người đăng:</strong>
                <asp:Label ID="lblNguoiDang" runat="server"></asp:Label>
            </p>

            <!-- Nội dung -->
            <div style="margin-top:20px; font-size:18px; line-height:1.7;">
                <asp:Literal ID="ltNoiDung" runat="server"></asp:Literal>
            </div>

            <hr />

            <!-- Album ảnh -->
            <h3>Thư viện ảnh</h3>
            <div class="row">
                <asp:Repeater ID="rpThuVien" runat="server">
                <ItemTemplate>
            <img src='<%# ResolveUrl("~/TinTucImages/" + Eval("ImagePath")) %>' 
                     class="img-thumbnail"
                     style="width:100%; height:500px; object-fit:cover; border-radius:6px;" />
                </ItemTemplate>
            </asp:Repeater>
                        </div>

                        <div style="clear:both"></div>

        </asp:Panel>

        <!-- Không tìm thấy -->
        <asp:Panel ID="pnlLoi" runat="server" Visible="false">
            <h3 class="text-danger text-center">❌ Không tìm thấy bài viết!</h3>
        </asp:Panel>

    </div>

</asp:Content>
