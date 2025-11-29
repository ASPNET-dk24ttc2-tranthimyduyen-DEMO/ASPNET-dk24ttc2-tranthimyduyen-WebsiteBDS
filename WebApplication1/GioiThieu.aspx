<%@ Page Title="" Language="C#" MasterPageFile="~/Gdien.Master" AutoEventWireup="true" CodeBehind="GioiThieu.aspx.cs" Inherits="WebApplication1.GioiThieu" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5">

        <h2 class="text-center text-primary mb-4">Giới thiệu về Đề tài</h2>

        <p class="lead text-center"
           style="max-width:800px; margin-left:auto; margin-right:auto;">
           Xây dựng website mua bán bất động sản
        </p>

        <hr />

        <!-- TẦM NHÌN -->
               <div class="row my-5 gx-0">
            <div class="col-md-6 d-flex justify-content-center">
                <img src="images/duyen1.jfif" 
                     class="img-fluid rounded shadow" 
                     alt="Người thực hiện" 
                     style="width: 70%; height: auto;">
            </div>

            <div class="col-md-6 d-flex align-items-center">
                <div>
                    <h3 class="text-primary">Người thực hiện</h3>
                   <p><b>Trần Thị Mỹ Duyên</b> - Lớp: DK24TTC2 - MSSV: 170124126<br>
                       <b> Người hướng dẫn:</b> TS. Đoàn Phước Miền</p>

                    <h3 class="text-primary">Cảm hứng chọn đề tài</h3>
                    <p>
                        Sau những chuyến đi la cà tìm nhà tìm phòng quá vất vả mình nhận ra việc tìm kiếm bất động sản (BĐS) hiện nay vẫn còn khá nhiều khó khăn. 
                        Tuy có nhiều trang web cung cấp thông tin nhưng không được cập nhật thường xuyên. Điều này khiến người mua và người thuê gặp khó khăn trong việc tìm kiếm và lựa chọn BĐS phù hợp với nhu cầu của mình.
                    </p>
                </div>
            </div>
        </div>

        <!-- GIÁ TRỊ CỐT LÕI -->
        <h3 class="text-primary mt-5">Giá trị cốt lõi</h3>

        <div class="row mt-3">
            <div class="col-md-4 mb-3">
                <div class="card shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title">Uy tín</h5>
                        <p class="card-text">
                            Luôn đặt lợi ích của khách hàng lên hàng đầu,
                            đảm bảo thông tin rõ ràng và chính xác.
                        </p>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <div class="card shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title">Nhanh chóng</h5>
                        <p class="card-text">
                            Cập nhật tin đăng và thông tin thị trường mỗi ngày,
                            giúp bạn không bỏ lỡ cơ hội tốt.
                        </p>
                    </div>
                </div>
            </div>

            <div class="col-md-4 mb-3">
                <div class="card shadow-sm h-100">
                    <div class="card-body">
                        <h5 class="card-title">Hiệu quả</h5>
                        <p class="card-text">
                            Dễ sử dụng, tối ưu trải nghiệm để người dùng tiếp cận thông tin nhanh hơn.
                        </p>
                    </div>
                </div>
            </div>
        </div>

        <hr class="my-5">

        <h3 class="text-center text-primary">Liên hệ với chúng tôi</h3>
        <p class="text-center">
            📞 Hotline: <strong>0387.442.093</strong><br />
            📧 Email: <strong>duyenttm131196@tvu-onschool.edu.vn</strong><br />
            📍 Địa chỉ: 45 Nguyễn Văn Cừ, Phường 7, TP.Tuy Hoà, Phú Yên

    </div>

</asp:Content>
