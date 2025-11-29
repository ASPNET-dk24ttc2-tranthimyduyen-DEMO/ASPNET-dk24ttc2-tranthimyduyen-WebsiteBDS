using System;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1.User
{
    public partial class ThemTinDang : System.Web.UI.Page
    {
        string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=BDS;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadLoaiNha();
                LoadLoaiBDS();
            }
        }

        void LoadLoaiNha()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT LoaiID, TenLoai FROM LoaiNhaDat";
                SqlCommand cmd = new SqlCommand(sql, conn);

                ddlLoaiNha.DataSource = cmd.ExecuteReader();
                ddlLoaiNha.DataTextField = "TenLoai";
                ddlLoaiNha.DataValueField = "LoaiID";
                ddlLoaiNha.DataBind();
            }
        }

        void LoadLoaiBDS()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT IDLoaiBDS, TenLoaiBDS FROM LoaiBDS";
                SqlCommand cmd = new SqlCommand(sql, conn);

                ddlLoaiBDS.DataSource = cmd.ExecuteReader();
                ddlLoaiBDS.DataTextField = "TenLoaiBDS";
                ddlLoaiBDS.DataValueField = "IDLoaiBDS";
                ddlLoaiBDS.DataBind();
            }
        }

        protected void btnThem_Click(object sender, EventArgs e)
        {
            string fileName = "";

            // LƯU ẢNH
            if (fuHinhAnh.HasFile)
            {
                fileName = Path.GetFileName(fuHinhAnh.FileName);
                fuHinhAnh.SaveAs(Server.MapPath("~/images/" + fileName));
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"INSERT INTO TinDang
                                (TieuDe, Gia, DiaChi, MoTa, HinhAnh, LoaiID, UserID, NgayDang, IDLoaiBDS)
                               VALUES
                                (@TieuDe, @Gia, @DiaChi, @MoTa, @HinhAnh, @LoaiID, @UserID, GETDATE(), @IDLoaiBDS)";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text);
                cmd.Parameters.AddWithValue("@Gia", txtGia.Text);
                cmd.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@MoTa", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@HinhAnh", fileName);
                cmd.Parameters.AddWithValue("@LoaiID", ddlLoaiNha.SelectedValue);
                cmd.Parameters.AddWithValue("@IDLoaiBDS", ddlLoaiBDS.SelectedValue);
                cmd.Parameters.AddWithValue("@UserID", Session["UserID"]); // ✔ user đang đăng nhập

                cmd.ExecuteNonQuery();

                lblThongBao.Text = "✔ Đăng tin thành công!";
            }
        }
    }
}
