using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1.User
{
    public partial class DangTin : System.Web.UI.Page
    {
        string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=BDS;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/DangNhap.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadLoai();
                LoadLoaiBDS();
            }
        }

        void LoadLoai()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LoaiNhaDat", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlLoai.DataSource = dt;
                ddlLoai.DataTextField = "TenLoai";
                ddlLoai.DataValueField = "LoaiID";
                ddlLoai.DataBind();
            }
        }

        void LoadLoaiBDS()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM LoaiBDS", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlLoaiBDS.DataSource = dt;
                ddlLoaiBDS.DataTextField = "TenLoaiBDS";
                ddlLoaiBDS.DataValueField = "IDLoaiBDS";
                ddlLoaiBDS.DataBind();
            }
        }

        protected void btnDangTin_Click(object sender, EventArgs e)
        {
            // ==== KIỂM TRA RỖNG ====
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text))
            {
                lblMsg.Text = "⚠ Tiêu đề không được để trống!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtGia.Text))
            {
                lblMsg.Text = "⚠ Giá không được để trống!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDiaChi.Text))
            {
                lblMsg.Text = "⚠ Địa chỉ không được để trống!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMoTa.Text))
            {
                lblMsg.Text = "⚠ Mô tả không được để trống!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlLoai.SelectedIndex < 0)
            {
                lblMsg.Text = "⚠ Vui lòng chọn loại nhà!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (ddlLoaiBDS.SelectedIndex < 0)
            {
                lblMsg.Text = "⚠ Vui lòng chọn loại bất động sản!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!fuAnh.HasFile)
            {
                lblMsg.Text = "⚠ Vui lòng chọn hình ảnh!";
                lblMsg.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Nếu tất cả hợp lệ → tiếp tục lưu
            string fileName = "";

            // Upload ảnh
            if (fuAnh.HasFile)
            {
                fileName = DateTime.Now.Ticks + Path.GetExtension(fuAnh.FileName);
                fuAnh.SaveAs(Server.MapPath("~/images/" + fileName));
            }

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(@"
            INSERT INTO TinDang(TieuDe, Gia, DiaChi, MoTa, LoaiID, IDLoaiBDS, HinhAnh, NgayDang, UserID)
            VALUES (@td, @gia, @dc, @mt, @loai, @bds, @anh, GETDATE(), @uid)
        ", conn);

                cmd.Parameters.AddWithValue("@td", txtTieuDe.Text);
                cmd.Parameters.AddWithValue("@gia", txtGia.Text);
                cmd.Parameters.AddWithValue("@dc", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@mt", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@loai", ddlLoai.SelectedValue);
                cmd.Parameters.AddWithValue("@bds", ddlLoaiBDS.SelectedValue);
                cmd.Parameters.AddWithValue("@anh", fileName);
                cmd.Parameters.AddWithValue("@uid", Session["UserID"]);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMsg.Text = "✔ Đăng tin thành công!";
            lblMsg.ForeColor = System.Drawing.Color.Green;

            ClearForm();
        }

        void ClearForm()
        {
            txtTieuDe.Text = "";
            txtGia.Text = "";
            txtDiaChi.Text = "";
            txtMoTa.Text = "";
            ddlLoai.SelectedIndex = 0;
            ddlLoaiBDS.SelectedIndex = 0;
        }
    }
}
