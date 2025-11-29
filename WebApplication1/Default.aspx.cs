using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using WebApplication1.Admin;

namespace WebApplication1
{
    public partial class Default : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTinDang();
                LoadTinTuc();
            }
        }

        // ====================== LOAD TIN ĐĂNG ======================
        private void LoadTinDang()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT TOP 6 ID, TieuDe, Gia, DiaChi, MoTa, HinhAnh, NgayDang
                               FROM TinDang
                               ORDER BY NgayDang DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rpTinDang.DataSource = dt;
                rpTinDang.DataBind();
            }
        }

        // ====================== LOAD TIN TỨC ======================
        private void LoadTinTuc()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string sql = @"SELECT TOP 4 MaTinTuc, TieuDe, TomTat, AnhBia, NgayDang
                               FROM TinTuc
                               ORDER BY NgayDang DESC";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rpTinTuc.DataSource = dt;
                rpTinTuc.DataBind();
            }
        }
    }
}
