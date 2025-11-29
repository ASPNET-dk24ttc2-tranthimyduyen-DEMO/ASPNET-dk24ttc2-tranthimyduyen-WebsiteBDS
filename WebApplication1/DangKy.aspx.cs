using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class DangKy : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();
            string fullname = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            if (username == "" || password == "" || fullname == "" || email == "")
            {
                lblMessage.Text = "Vui lòng nhập đầy đủ thông tin!";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // kiểm tra username tồn tại chưa
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Users WHERE Username = @u", conn);
                checkCmd.Parameters.AddWithValue("@u", username);

                int exists = (int)checkCmd.ExecuteScalar();
                if (exists > 0)
                {
                    lblMessage.Text = "Tên đăng nhập đã tồn tại!";
                    return;
                }

                // thêm tài khoản mới
                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Users (Username, Password, FullName, Email, RoleID)
                    VALUES (@u, @p, @f, @e, 2)   -- 2 = Role User
                ", conn);

                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);
                cmd.Parameters.AddWithValue("@f", fullname);
                cmd.Parameters.AddWithValue("@e", email);

                cmd.ExecuteNonQuery();
            }

            lblMessage.CssClass = "text-success";
            lblMessage.Text = "Đăng ký thành công!";
        }
    }
}
