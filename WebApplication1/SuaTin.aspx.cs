using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1
{
    public partial class SuaTin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;
        int tinID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~DangNhap.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["id"], out tinID))
            {
                lblMessage.Text = "Không tìm thấy tin.";
                return;
            }

            if (!IsPostBack)
            {
                LoadLoai();
                LoadLoaiBDS();
                LoadTin();
                LoadAnh();
            }
        }

        // LOAD THÔNG TIN TIN ĐĂNG
        void LoadTin()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = "SELECT * FROM TinDang WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", tinID);

                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtTieuDe.Text = rd["TieuDe"].ToString();
                    txtGia.Text = rd["Gia"].ToString();
                    txtDiaChi.Text = rd["DiaChi"].ToString();
                    txtMoTa.Text = rd["MoTa"].ToString();
                    txtSDT.Text = rd["SDT"].ToString();

                    ddlLoai.SelectedValue = rd["LoaiID"].ToString();
                    ddlLoaiBDS.SelectedValue = rd["IDLoaiBDS"].ToString();

                    // ẢNH BÌA
                    imgAnhBia.Src = "~/" + rd["HinhAnh"].ToString();
                    ViewState["AnhBiaCu"] = rd["HinhAnh"].ToString();

                }
            }
        }

        // LOAD ẢNH PHỤ
        void LoadAnh()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                string sql = "SELECT * FROM TinDangImages WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ID", tinID);

                DataTable dt = new DataTable();
                dt.Load(cmd.ExecuteReader());

                rpAnh.DataSource = dt;
                rpAnh.DataBind();
            }
        }

        // LOAD LOẠI
        void LoadLoai()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT LoaiID, TenLoai FROM LoaiNhaDat", conn);

                ddlLoai.DataSource = cmd.ExecuteReader();
                ddlLoai.DataTextField = "TenLoai";
                ddlLoai.DataValueField = "LoaiID";
                ddlLoai.DataBind();
            }
        }

        // LOAD LOẠI BĐS
        void LoadLoaiBDS()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT IDLoaiBDS, TenLoaiBDS FROM LoaiBDS", conn);

                ddlLoaiBDS.DataSource = cmd.ExecuteReader();
                ddlLoaiBDS.DataTextField = "TenLoaiBDS";
                ddlLoaiBDS.DataValueField = "IDLoaiBDS";
                ddlLoaiBDS.DataBind();
            }
        }

        // XÓA ẢNH PHỤ
        protected void rpAnh_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "deleteImg")
            {
                int imgID = Convert.ToInt32(e.CommandArgument);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM TinDangImages WHERE IDImages = @ID", conn);
                    cmd.Parameters.AddWithValue("@ID", imgID);
                    cmd.ExecuteNonQuery();
                }

                LoadAnh();
            }
        }

        // NÚT LƯU CẬP NHẬT
        protected void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // ========== XỬ LÝ ẢNH BÌA ==========
                string anhBiaMoi = ViewState["AnhBiaCu"].ToString();

                if (fuAnhBia.HasFile)
                {
                    string ext = Path.GetExtension(fuAnhBia.FileName).ToLower();
                    if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                    {
                        string folder = Server.MapPath("~/images/Uploads/");
                        string fileName = "bia_" + DateTime.Now.Ticks + ext;
                        string path = Path.Combine(folder, fileName);

                        fuAnhBia.SaveAs(path);
                        anhBiaMoi = "images/Uploads/" + fileName;
                    }
                }

                // ========== UPDATE DATABASE ==========
                string sql = @"
                    UPDATE TinDang SET 
                        TieuDe = @T,
                        Gia = @G,
                        DiaChi = @D,
                        MoTa = @M,
                        SDT = @SDT,
                        LoaiID = @L,
                        IDLoaiBDS = @LB,
                       HinhAnh = @AnhBia
                    WHERE ID = @ID";

                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@T", txtTieuDe.Text);
                cmd.Parameters.AddWithValue("@G", txtGia.Text);
                cmd.Parameters.AddWithValue("@D", txtDiaChi.Text);
                cmd.Parameters.AddWithValue("@M", txtMoTa.Text);
                cmd.Parameters.AddWithValue("@SDT", txtSDT.Text);
                cmd.Parameters.AddWithValue("@L", ddlLoai.SelectedValue);
                cmd.Parameters.AddWithValue("@LB", ddlLoaiBDS.SelectedValue);
                cmd.Parameters.AddWithValue("@AnhBia", anhBiaMoi);
                cmd.Parameters.AddWithValue("@ID", tinID);

                cmd.ExecuteNonQuery();
            }

            // LƯU ẢNH PHỤ
            SaveNewImages();

            lblMessage.CssClass = "text-success";
            lblMessage.Text = "Cập nhật thành công!";
        }

        // LƯU ẢNH PHỤ MỚI
        void SaveNewImages()
        {
            if (!fileAnh.HasFiles) return;

            string folder = Server.MapPath("~/images/Uploads/");

            foreach (var f in fileAnh.PostedFiles)
            {
                string ext = Path.GetExtension(f.FileName).ToLower();
                if (ext != ".jpg" && ext != ".png" && ext != ".jpeg")
                    continue;

                string fileName = DateTime.Now.Ticks + ext;
                string fullPath = Path.Combine(folder, fileName);

                f.SaveAs(fullPath);

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand(
                        "INSERT INTO TinDangImages (ID, ImagePath) VALUES (@ID, @URL)", conn);

                    cmd.Parameters.AddWithValue("@ID", tinID);
                    cmd.Parameters.AddWithValue("@URL", "images/Uploads/" + fileName);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
