using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplication1
{
    public partial class TimKiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        void LoadData()
        {
            string keyword = Request.QueryString["key"] ?? "";
            string loai = Request.QueryString["loai"] ?? "0";
            string tinh = Request.QueryString["tinh"] ?? "";
            string gia = Request.QueryString["gia"] ?? "0";

            using (SqlConnection conn = new SqlConnection(
                ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(@"
            SELECT td.ID, td.TieuDe, td.Gia, td.DiaChi, td.MoTa, td.HinhAnh,
                   ln.TenLoai, u.FullName, td.NgayDang
            FROM TinDang td
            LEFT JOIN LoaiNhaDat ln ON td.LoaiID = ln.LoaiID
            LEFT JOIN Users u ON td.UserID = u.UserID
            WHERE
                (@tuKhoa = '' OR td.TieuDe LIKE '%' + @tuKhoa + '%' OR td.MoTa LIKE '%' + @tuKhoa + '%')
                AND (@loai = 0 OR td.LoaiID = @loai)
                AND (@tinh = '' OR td.DiaChi LIKE '%' + @tinh + '%')
                AND (
                        @gia = 0 OR
                        (@gia = 1 AND td.Gia < 500000000) OR
                        (@gia = 2 AND td.Gia BETWEEN 500000000 AND 2000000000) OR
                        (@gia = 3 AND td.Gia > 2000000000)
                    )
            ", conn);

                cmd.Parameters.AddWithValue("@tuKhoa", keyword);
                cmd.Parameters.AddWithValue("@loai", Convert.ToInt32(loai));
                cmd.Parameters.AddWithValue("@tinh", tinh);
                cmd.Parameters.AddWithValue("@gia", Convert.ToInt32(gia));

                conn.Open();
                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                if (dt.Rows.Count > 0)
                {
                    rptTinKiem.DataSource = dt;
                    rptTinKiem.DataBind();
                    pnlNoData.Visible = false;
                }
                else
                {
                    pnlNoData.Visible = true;
                }
            }
        }
    }
}
