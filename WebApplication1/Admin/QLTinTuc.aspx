<%@ Page Title="Quản Lý Tin Đăng" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="QLTinTuc.aspx.cs" Inherits="WebApplication1.Admin.QLTinTuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/css/bootstrap.min.css" rel="stylesheet" />

<div class="container mt-4">

    <h2 class="mb-3">Quản Lý Tin Tức</h2>

    <asp:Label ID="lblMsg" runat="server" Font-Bold="true" ForeColor="Green"></asp:Label>

    <div class="card p-3 mb-4 shadow-sm">
        

        <div class="row mb-2">
            <div class="col-md-6">
                <label>Tiêu Đề:</label>
                <asp:TextBox ID="txtTieuDe" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col-md-6">
                <label>Tóm Tắt:</label>
                <asp:TextBox ID="txtTomTat" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        <div class="mb-2">
            <label>Nội dung:</label>
            <asp:TextBox ID="txtMoTa" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
        </div>

        <div class="row mt-2">
            <div class="col-md-6">
                <label>Ảnh Bìa:</label>
                <asp:FileUpload ID="fuAnh" CssClass="form-control" runat="server" />
            </div>
            <div class="col-md-6">
                <asp:Image ID="imgPreview" runat="server" Width="150" CssClass="border rounded" />
            </div>
        </div>

        <div class="mt-3">
            <asp:Button ID="btnLuu" runat="server" Text="Lưu" CssClass="btn btn-primary" OnClick="btnLuu_Click" />
            <asp:Button ID="btnHuy" runat="server" Text="Hủy" CssClass="btn btn-secondary ms-2" OnClick="btnHuy_Click" />
                    </div>
    </div>

    <hr />
                <asp:HiddenField ID="hfID" runat="server" />
                <asp:Button ID="btnTaoTinMoi" runat="server" Text="➕ Thêm Tin Tức"
                CssClass="btn btn-primary mb-3"
                OnClick="btnTaoTinMoi_Click" />

    <asp:GridView ID="gvTin" runat="server" CssClass="table table-bordered"
        AutoGenerateColumns="False" OnRowCommand="gvTin_RowCommand">

        <Columns>

            <asp:BoundField DataField="MaTinTuc" HeaderText="ID" />

            <asp:BoundField DataField="TieuDe" HeaderText="Tiêu Đề" />

            <asp:BoundField DataField="TomTat" HeaderText="Tóm Tắt" />

            <asp:BoundField DataField="NoiDung" HeaderText="Nội Dung" />

            <%-- Hiển thị ảnh bìa --%>
            <asp:TemplateField HeaderText="Ảnh" ItemStyle-Width="120px">
                <ItemTemplate>
                    <img src='<%# ResolveUrl("~/TinTucImages/" + Eval("AnhBia")) %>' 
                         width="90" style="border-radius:6px;" />
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Sửa" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnSua" runat="server" Text="Sửa"
                        CommandName="sua"
                        CommandArgument='<%# Eval("MaTinTuc") %>'
                        CssClass="btn btn-primary btn-sm"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="80px" ItemStyle-HorizontalAlign="Center">
                <ItemTemplate>
                    <asp:LinkButton ID="btnXoa" runat="server" Text="Xóa"
                        CommandName="xoa"
                        CommandArgument='<%# Eval("MaTinTuc") %>'
                        CssClass="btn btn-danger btn-sm"
                        OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>

        </Columns>

    </asp:GridView>

</div>

</asp:Content>
