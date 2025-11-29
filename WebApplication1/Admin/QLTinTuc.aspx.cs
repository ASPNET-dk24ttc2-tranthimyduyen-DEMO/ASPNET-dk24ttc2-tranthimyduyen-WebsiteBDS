using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Web.UI;

namespace WebApplication1.Admin
{
    public partial class QLTinTuc : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                LoadTinTuc();
        }

        // ================================
        // LOAD DỮ LIỆU
        // ================================
        void LoadTinTuc()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = "SELECT * FROM TinTuc ORDER BY MaTinTuc DESC";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvTin.DataSource = dt;
                gvTin.DataBind();
            }
        }

        // ================================
        // NÚT TẠO TIN MỚI
        // ================================
        protected void btnTaoTinMoi_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/TinTuc.aspx");
        }

      
        // NÚT LƯU (THÊM + SỬA)
        // ================================
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text.Trim();
            string tomTat = txtTomTat.Text.Trim();
            string noiDung = txtMoTa.Text.Trim();
            string tenAnh = "";

            // Upload ảnh
            if (fuAnh.HasFile)
            {
                string ext = Path.GetExtension(fuAnh.FileName);
                tenAnh = "tin_" + DateTime.Now.Ticks + ext;
                fuAnh.SaveAs(Server.MapPath("~/TinTucImages/" + tenAnh));
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                if (hfID.Value == "")
                {
                    // ----- THÊM MỚI -----
                    string sql =
                        "INSERT INTO TinTuc (TieuDe, TomTat, NoiDung, AnhBia, NgayDang) " +
                        "VALUES (@TieuDe, @TomTat, @NoiDung, @AnhBia, GETDATE())";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@TomTat", tomTat);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@AnhBia", tenAnh);

                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "✔ Thêm tin tức thành công!";
                }
                else
                {
                    // ----- SỬA -----
                    string sql;

                    if (tenAnh != "")
                        sql = "UPDATE TinTuc SET TieuDe=@TieuDe, TomTat=@TomTat, NoiDung=@NoiDung, AnhBia=@AnhBia WHERE MaTinTuc=@ID";
                    else
                        sql = "UPDATE TinTuc SET TieuDe=@TieuDe, TomTat=@TomTat, NoiDung=@NoiDung WHERE MaTinTuc=@ID";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                    cmd.Parameters.AddWithValue("@TomTat", tomTat);
                    cmd.Parameters.AddWithValue("@NoiDung", noiDung);
                    cmd.Parameters.AddWithValue("@ID", hfID.Value);

                    if (tenAnh != "")
                        cmd.Parameters.AddWithValue("@AnhBia", tenAnh);

                    cmd.ExecuteNonQuery();
                    lblMsg.Text = "✔ Cập nhật tin tức thành công!";
                }
            }

            LoadTinTuc();
        }

        // ================================
        // NÚT HỦY
        // ================================
        protected void btnHuy_Click(object sender, EventArgs e)
        {
            hfID.Value = "";
            txtTieuDe.Text = "";
            txtTomTat.Text = "";
            txtMoTa.Text = "";
            imgPreview.ImageUrl = "";
            lblMsg.Text = "";
        }

        // ================================
        // GRIDVIEW SỬA – XÓA
        // ================================
        protected void gvTin_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            // ------------ SỬA ------------
            if (e.CommandName == "sua")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    string query = "SELECT * FROM TinTuc WHERE MaTinTuc=@ID";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ID", id);

                    SqlDataReader rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        hfID.Value = id;
                        txtTieuDe.Text = rd["TieuDe"].ToString();
                        txtTomTat.Text = rd["TomTat"].ToString();
                        txtMoTa.Text = rd["NoiDung"].ToString();

                        if (rd["AnhBia"] != DBNull.Value)
                            imgPreview.ImageUrl = "~/TinTucImages/" + rd["AnhBia"].ToString();
                    }
                }

                lblMsg.Text = "Đang sửa tin tức...";
            }

            // ------------ XÓA ------------
            if (e.CommandName == "xoa")
            {
                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // Xóa ảnh khỏi thư mục
                    string queryImg = "SELECT AnhBia FROM TinTuc WHERE MaTinTuc=@ID";
                    SqlCommand cmdImg = new SqlCommand(queryImg, conn);
                    cmdImg.Parameters.AddWithValue("@ID", id);
                    string file = cmdImg.ExecuteScalar()?.ToString();

                    if (!string.IsNullOrEmpty(file))
                    {
                        string path = Server.MapPath("~/TinTucImages/" + file);
                        if (File.Exists(path))
                            File.Delete(path);
                    }

                    string sql = "DELETE FROM TinTuc WHERE MaTinTuc=@ID";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@ID", id);
                    cmd.ExecuteNonQuery();
                }

                lblMsg.Text = "✔ Xóa tin tức thành công!";
                LoadTinTuc();
            }
        }
    }
}
