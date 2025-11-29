<%@ Page Title="Quản Lý User" Language="C#" MasterPageFile="~/Admin/Admin.Master"
    AutoEventWireup="true" CodeBehind="QLUser.aspx.cs"
    Inherits="WebApplication1.Admin.QLUser" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4">

        <h2 class="mb-3">Quản Lý User</h2>

        <asp:HiddenField ID="hdUserID" runat="server" />

        <div class="card p-3 mb-4">

            <div class="row">
                <div class="col-md-4 mb-3">
                    <label>Username</label>
                    <asp:TextBox ID="txtUsername" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4 mb-3">
                    <label>Password</label>
                    <asp:TextBox ID="txtPassword" CssClass="form-control" TextMode="Password" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4 mb-3">
                    <label>Full Name</label>
                    <asp:TextBox ID="txtFullName" CssClass="form-control" runat="server"></asp:TextBox>
                </div>
            </div>

            <div class="row">
                <div class="col-md-4 mb-3">
                    <label>Email</label>
                    <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                </div>

                <div class="col-md-4 mb-3">
                    <label>Role</label>
                    <asp:DropDownList ID="ddlRole" CssClass="form-control" runat="server"></asp:DropDownList>
                </div>

                <div class="col-md-4 d-flex align-items-end mb-3">
                    <asp:Button ID="btnLuu" runat="server" Text="Lưu"
                        CssClass="btn btn-success me-2" OnClick="btnLuu_Click" />
                    <asp:Button ID="btnHuy" runat="server" Text="Hủy"
                        CssClass="btn btn-secondary" OnClick="btnHuy_Click" />
                </div>
            </div>

        </div>

        <!-- Danh sách User -->
        <asp:GridView ID="gvUser" runat="server" CssClass="table table-bordered"
            AutoGenerateColumns="False" OnRowCommand="gvUser_RowCommand">

            <Columns>

                <asp:BoundField DataField="UserID" HeaderText="ID" />

                <asp:BoundField DataField="Username" HeaderText="Username" />

                <asp:BoundField DataField="FullName" HeaderText="Họ tên" />

                <asp:BoundField DataField="Email" HeaderText="Email" />

                <asp:BoundField DataField="RoleName" HeaderText="Quyền" />

                <asp:TemplateField HeaderText="Hành động">
                    <ItemTemplate>
                        <asp:Button ID="btnSua" runat="server" CommandName="sua"
                            CommandArgument='<%# Eval("UserID") %>'
                            CssClass="btn btn-warning btn-sm" Text="Sửa" />

                        <asp:Button ID="btnXoa" runat="server" CommandName="xoa"
                            CommandArgument='<%# Eval("UserID") %>'
                            CssClass="btn btn-danger btn-sm" Text="Xóa" />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>

        </asp:GridView>

    </div>

</asp:Content>
