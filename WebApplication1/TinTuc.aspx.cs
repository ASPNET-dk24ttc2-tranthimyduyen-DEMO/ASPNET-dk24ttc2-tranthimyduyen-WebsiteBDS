using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace WebApplication1
{
    public partial class TinTuc : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                // 1) Tạo thư mục TinTucImages nếu chưa có
                string folderPath = Server.MapPath("~/TinTucImages/");
                if (!Directory.Exists(folderPath))
                    Directory.CreateDirectory(folderPath);

                string anhBiaFileName = "";

                // 2) Lưu ảnh bìa
                if (fileAnhBia.HasFile)
                {
                    anhBiaFileName = DateTime.Now.Ticks + "_" + Path.GetFileName(fileAnhBia.FileName);
                    fileAnhBia.SaveAs(folderPath + anhBiaFileName);
                }

                int newMaTinTuc = 0;

                using (SqlConnection conn = new SqlConnection(connStr))
                {
                    conn.Open();

                    // 3) Insert TinTuc
                    string sql = @"
                        INSERT INTO TinTuc (TieuDe, TomTat, NoiDung, AnhBia, NgayDang, UserID)
                        OUTPUT INSERTED.MaTinTuc
                        VALUES (@TieuDe, @TomTat, @NoiDung, @AnhBia, GETDATE(), @UserID)";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@TieuDe", txtTieuDe.Text);
                    cmd.Parameters.AddWithValue("@TomTat", txtTomTat.Text);
                    cmd.Parameters.AddWithValue("@NoiDung", txtNoiDung.Text);
                    cmd.Parameters.AddWithValue("@AnhBia", anhBiaFileName);
                    cmd.Parameters.AddWithValue("@UserID", 1); // Tạm, bạn có thể lấy từ session

                    newMaTinTuc = (int)cmd.ExecuteScalar(); // Lấy ID tin vừa tạo
                }

                // 4) Lưu ảnh phụ vào bảng TinTucImages
                if (fileAnhPhu.HasFiles)
                {
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();

                        foreach (var file in fileAnhPhu.PostedFiles)
                        {
                            string tenFile = DateTime.Now.Ticks + "_" + Path.GetFileName(file.FileName);
                            string fullPath = folderPath + tenFile;

                            file.SaveAs(fullPath);

                            string sqlImg = @"INSERT INTO TinTucImages (MaTinTuc, ImagePath)
                                              VALUES (@MaTinTuc, @ImagePath)";

                            SqlCommand cmdImg = new SqlCommand(sqlImg, conn);
                            cmdImg.Parameters.AddWithValue("@MaTinTuc", newMaTinTuc);
                            cmdImg.Parameters.AddWithValue("@ImagePath", tenFile);
                            cmdImg.ExecuteNonQuery();
                        }
                    }
                }

                lblError.Text = "Đăng tin thành công!";
                lblError.ForeColor = System.Drawing.Color.Green;
            }
            catch (Exception ex)
            {
                lblError.Text = "Lỗi: " + ex.Message;
            }
        }
    }
}
