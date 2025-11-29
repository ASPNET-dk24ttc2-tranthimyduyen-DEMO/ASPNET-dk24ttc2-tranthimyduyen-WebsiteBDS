using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;

namespace WebApplication1
{
    public partial class DangTin : Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            // ======================================
            // KIỂM TRA ĐĂNG NHẬP
            // ======================================
            if (Session["UserID"] == null)
            {
                Response.Redirect("DangNhap.aspx?returnUrl=DangTin");
                return;
            }

            if (!IsPostBack)
            {
                LoadLoai();
                LoadLoaiBDS();
            }
        }

        // ================================
        // LOAD DANH MỤC
        // ================================
        void LoadLoai()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT LoaiID, TenLoai FROM LoaiNhaDat";
                SqlCommand cmd = new SqlCommand(sql, conn);

                ddlLoai.DataSource = cmd.ExecuteReader();
                ddlLoai.DataTextField = "TenLoai";
                ddlLoai.DataValueField = "LoaiID";
                ddlLoai.DataBind();
            }
        }

        void LoadLoaiBDS()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT IDLoaiBDS, TenLoaiBDS FROM LoaiBDS";
                SqlCommand cmd = new SqlCommand(sql, conn);

                ddlLoaiBDS.DataSource = cmd.ExecuteReader();
                ddlLoaiBDS.DataTextField = "TenLoaiBDS";
                ddlLoaiBDS.DataValueField = "IDLoaiBDS";
                ddlLoaiBDS.DataBind();
            }
        }

        // ================================
        // ĐĂNG TIN
        // ================================
        protected void btnDangTin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                lblMessage.Text = "Vui lòng nhập số điện thoại!";
                return;
            }

            if (!fileAnh.HasFiles)
            {
                lblMessage.Text = "Vui lòng chọn ít nhất 1 hình!";
                return;
            }

            string folder = Server.MapPath("~/images/Uploads/");
            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string anhPreview = "";

            try
            {
                int index = 0;
                foreach (var file in fileAnh.PostedFiles)
                {
                    string ext = Path.GetExtension(file.FileName).ToLower();
                    if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                        continue;

                    string fileName = DateTime.Now.Ticks + "_" + index + ext;
                    string fullPath = Path.Combine(folder, fileName);

                    file.SaveAs(fullPath);

                    if (index == 0)
                    {
                        anhPreview = "images/Uploads/" + fileName;
                        imgPreview.ImageUrl = "~/" + anhPreview;
                    }

                    index++;
                }

                // Lưu tin + lấy ID
                int newTinID = SaveTin(anhPreview);

                // Lưu nhiều ảnh chi tiết
                SaveAnhChiTiet(newTinID);

                lblMessage.CssClass = "text-success";
                lblMessage.Text = "Đăng tin thành công!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Lỗi: " + ex.Message;
            }

        }

        // ================================
        // LƯU TIN ĐĂNG
        // ================================
        int SaveTin(string preview)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"
                    INSERT INTO TinDang 
                    (TieuDe, Gia, DiaChi, MoTa, SDT, LoaiID, IDLoaiBDS, HinhAnh, UserID, NgayDang)
                    OUTPUT INSERTED.ID
                    VALUES 
                    (@T, @G, @D, @M, @SDT, @L, @LB, @AP, @UID, GETDATE())";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@T", txtTieuDe.Text);
                cmd.Parameters.AddWithValue("@G", txtGia.Text);
                cmd.Parameters.AddWithValue("@D", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@M", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@L", ddlLoai.SelectedValue);
                cmd.Parameters.AddWithValue("@LB", ddlLoaiBDS.SelectedValue);
                cmd.Parameters.AddWithValue("@AP", preview);


                // Lấy user đang đăng tin
                cmd.Parameters.AddWithValue("@UID", Convert.ToInt32(Session["UserID"]));

                return (int)cmd.ExecuteScalar();
            }
        }

        // ================================
        // LƯU NHIỀU ẢNH CHI TIẾT
        // ================================
        void SaveAnhChiTiet(int tinID)
        {
            string folder = Server.MapPath("~/images/Uploads/");

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                int index = 0;

                foreach (var file in fileAnh.PostedFiles)
                {
                    string ext = Path.GetExtension(file.FileName).ToLower();
                    if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                        continue;

                    string fileName = DateTime.Now.Ticks + "_" + index + ext;
                    string fullPath = Path.Combine(folder, fileName);

                    file.SaveAs(fullPath);

                    string sql = @"INSERT INTO TinDangImages (ID, ImagePath) 
                                   VALUES (@ID, @URL)";

                    SqlCommand cmd = new SqlCommand(sql, conn);

                    cmd.Parameters.AddWithValue("@ID", tinID);
                    cmd.Parameters.AddWithValue("@URL", "images/Uploads/" + fileName);

                    cmd.ExecuteNonQuery();

                    index++;
                }
            }
        }
    }
}
