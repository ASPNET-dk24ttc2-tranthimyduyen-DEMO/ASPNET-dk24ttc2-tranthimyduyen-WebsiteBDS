<%@ Page Title="Quản Lý Người Dùng" Language="C#" MasterPageFile="~/Admin/Admin.master"
    AutoEventWireup="true" CodeBehind="QLNguoiDung.aspx.cs"
    Inherits="WebApplication1.Admin.QLNguoiDung" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .table thead th {
            background: #0d6efd;
            color: #fff;
            text-align: center;
        }
        .table td, .table th {
            vertical-align: middle !important;
        }
        .action-btn {
            padding: 4px 10px;
            border-radius: 6px;
            font-size: 13px;
            margin-right: 4px;
        }
    </style>

    <h3 class="mb-3 fw-bold">Quản Lý Người Dùng</h3>

    <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False"
        CssClass="table table-bordered table-hover"
        DataKeyNames="UserID"
        OnRowEditing="gvUsers_RowEditing"
        OnRowCancelingEdit="gvUsers_RowCancelingEdit"
        OnRowUpdating="gvUsers_RowUpdating"
        OnRowDeleting="gvUsers_RowDeleting"
        OnRowDataBound="gvUsers_RowDataBound">

        <Columns>

            <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" />

            <asp:BoundField DataField="Username" HeaderText="Tên đăng nhập" />

            <asp:TemplateField HeaderText="Họ tên">
                <ItemTemplate>
                    <%# Eval("FullName") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFullNameEdit" runat="server"
                        Text='<%# Eval("FullName") %>' CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <%# Eval("Email") %>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmailEdit" runat="server"
                        Text='<%# Eval("Email") %>' CssClass="form-control" />
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Vai trò">
                <ItemTemplate>
                    <span class="badge bg-primary"><%# Eval("RoleName") %></span>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-select"></asp:DropDownList>
                </EditItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Thao tác">
                <ItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Edit"
                        CssClass="btn btn-sm btn-warning action-btn">Sửa</asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Delete"
                        OnClientClick="return confirm('Bạn chắc chắn muốn xóa?');"
                        CssClass="btn btn-sm btn-danger action-btn">Xóa</asp:LinkButton>
                </ItemTemplate>

                <EditItemTemplate>
                    <asp:LinkButton runat="server" CommandName="Update"
                        CssClass="btn btn-sm btn-success action-btn">Cập nhật</asp:LinkButton>

                    <asp:LinkButton runat="server" CommandName="Cancel"
                        CssClass="btn btn-sm btn-secondary action-btn">Huỷ</asp:LinkButton>
                </EditItemTemplate>
            </asp:TemplateField>

        </Columns>
    </asp:GridView>

    <hr />

    <h4 class="fw-bold mt-4">Thêm người dùng mới</h4>

    <div class="card p-3 shadow-sm" style="max-width: 500px;">

        <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control mb-2" placeholder="Tên đăng nhập"></asp:TextBox>
        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control mb-2" placeholder="Mật khẩu" TextMode="Password"></asp:TextBox>
        <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control mb-2" placeholder="Họ tên"></asp:TextBox>
        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control mb-2" placeholder="Email"></asp:TextBox>

        <asp:DropDownList ID="ddlAddRole" runat="server" CssClass="form-select mb-3"></asp:DropDownList>

        <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" CssClass="btn btn-primary w-100"
            OnClick="btnAdd_Click" />

        <asp:Label ID="lblMessage" runat="server" CssClass="text-success mt-2 d-block"></asp:Label>

    </div>

</asp:Content>
