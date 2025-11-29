<%@ Page Title="Quản Lý Tin Đăng (Admin)" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="QuanLyTin.aspx.cs" Inherits="WebApplication1.Admin.QuanLyTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <h2 class="text-center mb-4">Quản Lý Tin Đăng (Admin)</h2>

        <asp:Button ID="btnThemMoi" runat="server" CssClass="btn btn-success mb-3"
            Text="➕ Thêm tin mới" OnClick="btnThemMoi_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-success"></asp:Label>

        <asp:GridView ID="gvTin" runat="server"
            CssClass="table table-bordered"
            AutoGenerateColumns="False"
            AllowPaging="true"
            PageSize="10"
            OnPageIndexChanging="gvTin_PageIndexChanging"
            OnRowCommand="gvTin_RowCommand">

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Mã Tin" />
                <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" />
                <asp:BoundField DataField="Gia" HeaderText="Giá" />
                <asp:BoundField DataField="NgayDang" HeaderText="Ngày Đăng" 
                                DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Ảnh">
                    <ItemTemplate>
                        <img src="/<%# Eval("HinhAnh") %>" style="width:80px;height:60px;object-fit:cover;" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="FullName" HeaderText="Người đăng" />

                <asp:TemplateField HeaderText="Chức năng">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Sửa" CssClass="btn btn-warning btn-sm"
                            CommandName="editTin" CommandArgument='<%# Eval("ID") %>' />

                        <asp:Button runat="server" Text="Xóa" CssClass="btn btn-danger btn-sm"
                            CommandName="deleteTin" CommandArgument='<%# Eval("ID") %>'
                            OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
