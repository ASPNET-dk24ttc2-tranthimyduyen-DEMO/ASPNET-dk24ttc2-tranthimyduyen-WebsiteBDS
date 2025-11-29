<%@ Page Title="Quản Lý Tin Đăng" Language="C#" MasterPageFile="~/User/User.Master"
    AutoEventWireup="true" CodeBehind="QuanLyTin.aspx.cs" Inherits="WebApplication1.User.QuanLyTin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">
        <h3 class="text-center mb-4">Quản Lý Tin Đăng</h3>

        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger"></asp:Label>

        <asp:GridView ID="gvTin" runat="server" CssClass="table table-bordered"
            AutoGenerateColumns="False"
            OnRowCommand="gvTin_RowCommand"
            EmptyDataText="Bạn chưa đăng tin nào."
            AllowPaging="true" PageSize="5"
            OnPageIndexChanging="gvTin_PageIndexChanging">

            <Columns>
                <asp:BoundField DataField="ID" HeaderText="Mã Tin" />
                <asp:BoundField DataField="TieuDe" HeaderText="Tiêu đề" />
                <asp:BoundField DataField="Gia" HeaderText="Giá" />
                <asp:BoundField DataField="NgayDang" HeaderText="Ngày đăng" 
                                DataFormatString="{0:dd/MM/yyyy}" />

                <asp:TemplateField HeaderText="Ảnh">
                    <ItemTemplate>
                        <img src="/<%# Eval("HinhAnh") %>" style="width:80px; height:60px; object-fit:cover;" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Chức năng">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Sửa" CssClass="btn btn-sm btn-warning"
                            CommandName="editTin" CommandArgument='<%# Eval("ID") %>' />

                        <asp:Button runat="server" Text="Xoá" CssClass="btn btn-sm btn-danger"
                            CommandName="deleteTin" CommandArgument='<%# Eval("ID") %>'
                            OnClientClick="return confirm('Bạn chắc chắn muốn xoá?');" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>

</asp:Content>
