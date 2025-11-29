using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadStats();
        }

        void LoadStats()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                con.Open();

                // Tổng tin đăng
                lblTinDang.Text = new SqlCommand("SELECT COUNT(*) FROM TinDang", con).ExecuteScalar().ToString();

                // Tổng người dùng
                lblUsers.Text = new SqlCommand("SELECT COUNT(*) FROM Users", con).ExecuteScalar().ToString();

                // Loại nhà đất
                lblLoaiNha.Text = new SqlCommand("SELECT COUNT(*) FROM LoaiNhaDat", con).ExecuteScalar().ToString();

                // Loại BĐS
                lblLoaiBDS.Text = new SqlCommand("SELECT COUNT(*) FROM LoaiBDS", con).ExecuteScalar().ToString();

                // Tin tức
                lblTinTuc.Text = new SqlCommand("SELECT COUNT(*) FROM TinTuc", con).ExecuteScalar().ToString();
            }
        }
    }
}
