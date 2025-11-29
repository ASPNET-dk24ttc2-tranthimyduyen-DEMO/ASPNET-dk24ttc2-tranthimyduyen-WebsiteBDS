using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class TinTucChiTiet : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string id = Request.QueryString["id"];

                if (string.IsNullOrEmpty(id))
                {
                    pnlTin.Visible = false;
                    pnlLoi.Visible = true;
                    return;
                }

                LoadTinTuc(id);
                LoadThuVien(id);
            }
        }

        // ===============================
        // 1) Load thông tin bài viết
        // ===============================
        void LoadTinTuc(string id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT TieuDe, NoiDung, AnhBia, NgayDang, U.FullName
                    FROM TinTuc TT
                    LEFT JOIN Users U ON TT.UserID = U.UserID
                    WHERE MaTinTuc = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    pnlTin.Visible = true;
                    pnlLoi.Visible = false;

                    lblTieuDe.Text = rd["TieuDe"].ToString();
                    ltNoiDung.Text = rd["NoiDung"].ToString();
                    lblNgayDang.Text = Convert.ToDateTime(rd["NgayDang"]).ToString("dd/MM/yyyy");
                    lblNguoiDang.Text = rd["FullName"].ToString();

                    // Ảnh bìa
                    string anhBia = rd["AnhBia"].ToString();

                    if (!string.IsNullOrEmpty(anhBia))
                        imgAnhBia.Src = ResolveUrl("~/TinTucImages/" + anhBia);
                    else
                        imgAnhBia.Src = ResolveUrl("~/Images/no-image.jpg");
                }
                else
                {
                    pnlTin.Visible = false;
                    pnlLoi.Visible = true;
                }
            }
        }

        // ===============================
        // 2) Load thư viện ảnh
        // ===============================
        void LoadThuVien(string id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT ImagePath 
                    FROM TinTucImages 
                    WHERE MaTinTuc = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataReader rd = cmd.ExecuteReader();

                rpThuVien.DataSource = rd;
                rpThuVien.DataBind();
            }
        }
    }
}
