using System;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class ChiTietTinDang : System.Web.UI.Page
    {
        string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int id = Convert.ToInt32(Request.QueryString["id"]);
                    LoadThongTin(id);
                }
            }
        }

        void LoadThongTin(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"
                SELECT 
                    TD.ID, TD.TieuDe, TD.Gia, TD.DiaChi, TD.MoTa, TD.HinhAnh, TD.SDT,
                    L.TenLoai AS TenLoaiNhaDat,
                    B.TenLoaiBDS,
                    U.FullName AS NguoiDang
                FROM TinDang TD
                LEFT JOIN LoaiNhaDat L ON TD.LoaiID = L.LoaiID
                LEFT JOIN LoaiBDS B ON TD.IDLoaiBDS = B.IDLoaiBDS
                LEFT JOIN Users U ON TD.UserID = U.UserID
                WHERE TD.ID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    lblTieuDe.Text = dr["TieuDe"].ToString();
                    lblGia.Text = dr["Gia"].ToString();
                    lblDiaChi.Text = dr["DiaChi"].ToString();
                    lblMoTa.Text = dr["MoTa"].ToString();
                    lblSDT.Text = dr["SDT"].ToString();

                    lblLoai.Text = dr["TenLoaiNhaDat"].ToString();
                    lblHinhThuc.Text = dr["TenLoaiBDS"].ToString();

                    // ⭐ HIỂN THỊ NGƯỜI ĐĂNG
                    lblNguoiDang.Text = dr["NguoiDang"].ToString();

                    imgHinh.ImageUrl = dr["HinhAnh"].ToString();
                }

                dr.Close();
            }

            // Load ảnh phụ
            LoadAnhPhu(id);
        }

        void LoadAnhPhu(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = "SELECT ImagePath FROM TinDangImages WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                conn.Open();
                rpAnhChiTiet.DataSource = cmd.ExecuteReader();
                rpAnhChiTiet.DataBind();
            }
        }
    }
}
