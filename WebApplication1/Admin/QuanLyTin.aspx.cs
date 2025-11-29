using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Admin
{
    public partial class QuanLyTin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["RoleID"] == null || Session["RoleID"].ToString() != "1")
                {
                    Response.Redirect("~/DangNhap.aspx");
                    return;
                }

                LoadTinAdmin();
            }
        }

        void LoadTinAdmin()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    SELECT TD.ID, TD.TieuDe, TD.Gia, TD.NgayDang, TD.HinhAnh,
                           U.FullName
                    FROM TinDang TD
                    JOIN Users U ON TD.UserID = U.UserID
                    ORDER BY TD.NgayDang DESC";

                SqlCommand cmd = new SqlCommand(sql, conn);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                gvTin.DataSource = dt;
                gvTin.DataBind();
            }
        }

        protected void gvTin_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gvTin.PageIndex = e.NewPageIndex;
            LoadTinAdmin();
        }

        protected void gvTin_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "editTin")
            {
                Response.Redirect("~/SuaTin.aspx?ID=" + id);
            }
            else if (e.CommandName == "deleteTin")
            {
                DeleteTin(id);
                LoadTinAdmin();
                lblMessage.Text = "Đã xóa tin!";
            }
        }

        void DeleteTin(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Xóa ảnh phụ
                SqlCommand cmd1 = new SqlCommand("DELETE FROM TinDangImages WHERE ID = @ID", conn);
                cmd1.Parameters.AddWithValue("@ID", id);
                cmd1.ExecuteNonQuery();

                // Xóa tin chính
                SqlCommand cmd2 = new SqlCommand("DELETE FROM TinDang WHERE ID = @ID", conn);
                cmd2.Parameters.AddWithValue("@ID", id);
                cmd2.ExecuteNonQuery();
            }
        }

        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Admin sử dụng chung trang đăng tin
            Response.Redirect("~/DangTin.aspx");
        }
    }
}
