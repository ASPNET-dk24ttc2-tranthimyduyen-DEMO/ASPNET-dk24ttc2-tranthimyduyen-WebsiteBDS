<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TinTuc.aspx.cs" Inherits="WebApplication1.TinTuc" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Đăng Tin Tức</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server" class="container mt-4">

        <div class="d-flex justify-content-between align-items-center mb-4">
            <h3>Đăng Tin Tức (Admin)</h3>

            <div>
                <!-- Nút quay lại trang quản trị tin tức -->
                <asp:HyperLink ID="btnBack" runat="server"
                    CssClass="btn btn-secondary me-2"
                    NavigateUrl="~/Admin/QLTinTuc.aspx">
                    ⬅ Trở lại
                </asp:HyperLink>

                <!-- Nút quay về Trang chủ -->
                <asp:HyperLink ID="btnHome" runat="server"
                    CssClass="btn btn-primary"
                    NavigateUrl="~/Default.aspx">
                    🏠 Trang chủ
                </asp:HyperLink>
            </div>
        </div>

        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>

        <div class="mb-3">
            <label>Tiêu đề</label>
            <asp:TextBox ID="txtTieuDe" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Tóm tắt</label>
            <asp:TextBox ID="txtTomTat" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Nội dung</label>
            <asp:TextBox ID="txtNoiDung" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="6"></asp:TextBox>
        </div>

        <div class="mb-3">
            <label>Ảnh bìa</label>
            <asp:FileUpload ID="fileAnhBia" runat="server" CssClass="form-control" />
        </div>

        <div class="mb-3">
            <label>Ảnh phụ (nhiều ảnh)</label>
            <asp:FileUpload ID="fileAnhPhu" runat="server" AllowMultiple="true" CssClass="form-control" />
        </div>

        <asp:Button ID="btnLuu" runat="server" Text="Đăng Tin Tức"
            CssClass="btn btn-success mt-2"
            OnClick="btnLuu_Click" />

    </form>
</body>
</html>
