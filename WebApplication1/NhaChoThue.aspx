<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="NhaChoThue.aspx.cs" Inherits="WebApplication1.NhaChoThue" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2 class="text-center" style="margin-top:30px; margin-bottom:20px;">
        🏠 Danh sách Nhà Đất Cho Thuê
    </h2>

    <div class="row">
        <asp:Repeater ID="rpBan" runat="server">
            <ItemTemplate>
                <div class="col-md-4" style="margin-bottom:25px;">
                    <div class="panel panel-default">
                        <div class="panel-heading">
                            <h4><%# Eval("TieuDe") %></h4>
                        </div>
                        <div class="panel-body">
                            <img src='/Images/<%# Eval("HinhAnh") %>' 
                                 class="img-responsive" 
                                 style="height:200px; width:100%; object-fit:cover;" />

                            <p><strong>Giá:</strong> <%# Eval("Gia") %> triệu</p>
                            <p><strong>Địa chỉ:</strong> <%# Eval("DiaChi") %></p>
                            <p><strong>Ngày đăng:</strong> <%# Eval("NgayDang", "{0:dd/MM/yyyy}") %></p>

                            <a href='ChiTietTinDang.aspx?id=<%# Eval("ID") %>' 
                               class="btn btn-primary btn-block">
                                Xem chi tiết
                            </a>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>

</asp:Content>
