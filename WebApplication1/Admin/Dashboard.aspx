<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Admin/Admin.master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="WebApplication1.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container mt-4">
    <h2 class="mb-4">📊 Thống kê tổng quan</h2>

    <div class="row">

        <!-- Tổng tin đăng -->
        <div class="col-md-3">
            <div class="card text-white bg-primary mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">Tin đăng</h5>
                    <h3><asp:Label ID="lblTinDang" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <!-- Người dùng -->
        <div class="col-md-3">
            <div class="card text-white bg-success mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">Người dùng</h5>
                    <h3><asp:Label ID="lblUsers" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <!-- Loại nhà đất -->
        <div class="col-md-3">
            <div class="card text-white bg-info mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">Loại nhà đất</h5>
                    <h3><asp:Label ID="lblLoaiNha" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

        <!-- Loại BĐS -->
        <div class="col-md-3">
            <div class="card text-white bg-warning mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">Loại BĐS</h5>
                    <h3><asp:Label ID="lblLoaiBDS" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

    </div>

    <div class="row">

        <!-- Tin tức -->
        <div class="col-md-3">
            <div class="card text-white bg-danger mb-3 shadow">
                <div class="card-body">
                    <h5 class="card-title">Tin tức</h5>
                    <h3><asp:Label ID="lblTinTuc" runat="server" Text="0"></asp:Label></h3>
                </div>
            </div>
        </div>

    </div>

</div>

</asp:Content>
