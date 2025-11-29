using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class NhaDatBan : System.Web.UI.Page
    {
        string conn = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNhaDatBan();
            }
        }

        private void LoadNhaDatBan()
        {
            using (SqlConnection con = new SqlConnection(conn))
            {
                string query = @"
                    SELECT ID, TieuDe, Gia, DiaChi, HinhAnh, NgayDang
                    FROM TinDang
                    WHERE IDLoaiBDS = 1
                    ORDER BY NgayDang DESC
                ";

                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                rpBan.DataSource = dt;
                rpBan.DataBind();
            }
        }
    }
}
