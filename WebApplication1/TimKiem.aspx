<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TimKiem.aspx.cs" Inherits="WebApplication1.TimKiem" MasterPageFile="~/Gdien.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <h2 class="text-center">Kết quả tìm kiếm</h2>
        <hr />

        <!-- KẾT QUẢ TÌM KIẾM -->
        <asp:Repeater ID="rptTinKiem" runat="server">
            <ItemTemplate>
                <div class="card mb-3" style="border:1px solid #ddd; border-radius:6px; padding:15px; margin-bottom:20px;">
                    <div class="row">

                        <!-- ẢNH -->
                        <div class="col-sm-4">
                            <img src='<%# Eval("HinhAnh") %>' class="img-responsive" style="height:200px; width:100%; object-fit:cover; border-radius:5px;" />
                        </div>

                        <!-- THÔNG TIN -->
                        <div class="col-sm-8">
                            <h3><a href='ChiTiet.aspx?id=<%# Eval("ID") %>'><%# Eval("TieuDe") %></a></h3>

                            <p><b>Giá:</b> 
                                <span style="color:red;"><%# Eval("Gia", "{0:N0}") %> VNĐ</span>
                            </p>

                            <p><b>Địa chỉ:</b> <%# Eval("DiaChi") %></p>
                            <p><b>Loại nhà đất:</b> <%# Eval("TenLoai") %></p>

                            <p><b>Người đăng:</b> <%# Eval("FullName") %> |
                               <b>Ngày:</b> <%# Eval("NgayDang", "{0:dd/MM/yyyy}") %></p>

                            <p><%# Eval("MoTa") %></p>

                            <a href='ChiTiet.aspx?id=<%# Eval("ID") %>' class="btn btn-primary">Xem chi tiết</a>

                        </div>

                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- TRƯỜNG HỢP KHÔNG CÓ KẾT QUẢ -->
        <asp:Panel ID="pnlNoData" runat="server" Visible="false">
            <div class="alert alert-warning text-center">
                Không tìm thấy tin nào phù hợp.
            </div>
        </asp:Panel>

    </div>

</asp:Content>
