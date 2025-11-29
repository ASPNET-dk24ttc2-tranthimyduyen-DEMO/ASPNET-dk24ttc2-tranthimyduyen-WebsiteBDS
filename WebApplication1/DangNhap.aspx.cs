using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;

namespace WebApplication1
{
    public partial class DangNhap : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                string sql = @"SELECT UserID, FullName, RoleID 
                               FROM Users 
                               WHERE Username = @u AND Password = @p";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);

                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.Read())
                {
                    Session["UserID"] = rd["UserID"];
                    Session["FullName"] = rd["FullName"];
                    Session["RoleID"] = rd["RoleID"];   // sửa: giống Gdien.master

                    string role = rd["RoleID"].ToString();

                    // ==== PHÂN QUYỀN CHUYỂN TRANG ====
                    if (role == "1")
                    {
                        // Admin → Dashboard
                        Response.Redirect("~/Admin/Dashboard.aspx");
                    }
                    else
                    {
                        // User → Trang chủ
                        Response.Redirect("~/Default.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Sai tên đăng nhập hoặc mật khẩu!";
                }
            }
        }
    }
}
