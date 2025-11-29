using System;
using System.Data.SqlClient;

namespace WebApplication1.User
{
    public partial class ThongTinCaNhan : System.Web.UI.Page
    {
        string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=BDS;Integrated Security=True";

        int userID = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("~/DangNhap.aspx");
            }

            userID = Convert.ToInt32(Session["UserID"]);

            if (!IsPostBack)
            {
                LoadThongTin();
            }
        }

        void LoadThongTin()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(
                    "SELECT Username, FullName, Email FROM Users WHERE UserID=@UserID", conn);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    txtUsername.Text = rd["Username"].ToString();
                    txtFullName.Text = rd["FullName"].ToString();
                    txtEmail.Text = rd["Email"].ToString();
                }
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand cmd = new SqlCommand(@"
                    UPDATE Users 
                    SET FullName=@FullName, Email=@Email
                    WHERE UserID=@UserID", conn);

                cmd.Parameters.AddWithValue("@FullName", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMsg.Text = "✔ Cập nhật thông tin thành công!";
        }

        protected void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                SqlCommand check = new SqlCommand(
                    "SELECT Password FROM Users WHERE UserID=@UserID", conn);
                check.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                string passDB = check.ExecuteScalar().ToString();

                if (passDB != txtOldPass.Text)
                {
                    lblMsg.Text = "❌ Mật khẩu hiện tại không đúng!";
                    return;
                }
                conn.Close();

                SqlCommand update = new SqlCommand(
                    "UPDATE Users SET Password=@Pass WHERE UserID=@UserID", conn);

                update.Parameters.AddWithValue("@Pass", txtNewPass.Text);
                update.Parameters.AddWithValue("@UserID", userID);

                conn.Open();
                update.ExecuteNonQuery();
            }

            lblMsg.Text = "✔ Đổi mật khẩu thành công!";
        }
    }
}
