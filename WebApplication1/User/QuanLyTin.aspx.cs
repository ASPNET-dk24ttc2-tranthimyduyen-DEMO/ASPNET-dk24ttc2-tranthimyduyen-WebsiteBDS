using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication1.User
{
    public partial class QuanLyTin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("~/DangNhap.aspx");
                    return;
                }

                LoadTin();
            }
        }

        // ================================
        // LOAD TIN (User hoặc Admin)
        // ================================
        private void LoadTin()
        {
            int role = Convert.ToInt32(Session["RoleID"]);   // 1 = admin
            int userId = Convert.ToInt32(Session["UserID"]);

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "";

                if (role == 1)   // Admin xem tất cả tin
                {
                    sql = @"SELECT ID, TieuDe, Gia, NgayDang, HinhAnh
                            FROM TinDang
                            ORDER BY NgayDang DESC";
                }
                else             // User chỉ xem tin của mình
                {
                    sql = @"SELECT ID, TieuDe, Gia, NgayDang, HinhAnh
                            FROM TinDang
                            WHERE UserID = @UID
                            ORDER BY NgayDang DESC";
                }

                SqlCommand cmd = new SqlCommand(sql, conn);
                if (role != 1)  // chỉ user mới có @UID
                    cmd.Parameters.AddWithValue("@UID", userId);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                gvTin.DataSource = dt;
                gvTin.DataBind();
            }
        }

        // ================================
        // PHÂN TRANG
        // ================================
        protected void gvTin_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvTin.PageIndex = e.NewPageIndex;
            LoadTin();
        }

        // ================================
        // XỬ LÝ NÚT SỬA / XOÁ
        // ================================
        protected void gvTin_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "editTin")
            {
                // Trang sửa tin nằm ở ngoài thư mục User → dùng đường dẫn tuyệt đối
                Response.Redirect("~/SuaTin.aspx?ID=" + id);
            }
            else if (e.CommandName == "deleteTin")
            {
                XoaTin(id);
                LoadTin();

                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Xoá tin thành công!";
            }
        }

        // ================================
        // XOÁ TIN (cả TinDang và ảnh trong TinDangImages)
        // ================================
        private void XoaTin(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Xoá ảnh chi tiết
                string sql1 = "DELETE FROM TinDangImages WHERE ID = @ID";
                SqlCommand cmd1 = new SqlCommand(sql1, conn);
                cmd1.Parameters.AddWithValue("@ID", id);
                cmd1.ExecuteNonQuery();

                // Xoá tin chính
                string sql2 = "DELETE FROM TinDang WHERE ID = @ID";
                SqlCommand cmd2 = new SqlCommand(sql2, conn);
                cmd2.Parameters.AddWithValue("@ID", id);
                cmd2.ExecuteNonQuery();
            }
        }
    }
}
