using System;
using System.Data;
using System.Data.SqlClient;

namespace WebApplication1.Admin
{
    public partial class QLUser : System.Web.UI.Page
    {
        string connStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=BDS;Integrated Security=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadRole();
                LoadUser();
            }
        }

        void LoadRole()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "SELECT RoleID, RoleName FROM Role";
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlRole.DataSource = dt;
                ddlRole.DataTextField = "RoleName";
                ddlRole.DataValueField = "RoleID";
                ddlRole.DataBind();
            }
        }

        void LoadUser()
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = @"SELECT U.*, R.RoleName 
                               FROM Users U 
                               LEFT JOIN Role R ON U.RoleID = R.RoleID";

                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUser.DataSource = dt;
                gvUser.DataBind();
            }
        }

        protected void btnLuu_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmd;

                if (string.IsNullOrEmpty(hdUserID.Value))  // THÊM
                {
                    cmd = new SqlCommand(
                        "INSERT INTO Users (Username, Password, FullName, Email, RoleID) " +
                        "VALUES (@u, @p, @f, @e, @r)", con);
                }
                else  // SỬA
                {
                    cmd = new SqlCommand(
                        "UPDATE Users SET Username=@u, Password=@p, FullName=@f, Email=@e, RoleID=@r " +
                        "WHERE UserID=@id", con);
                    cmd.Parameters.AddWithValue("@id", hdUserID.Value);
                }

                cmd.Parameters.AddWithValue("@u", txtUsername.Text);
                cmd.Parameters.AddWithValue("@p", txtPassword.Text);
                cmd.Parameters.AddWithValue("@f", txtFullName.Text);
                cmd.Parameters.AddWithValue("@e", txtEmail.Text);
                cmd.Parameters.AddWithValue("@r", ddlRole.SelectedValue);

                cmd.ExecuteNonQuery();
            }

            ClearForm();
            LoadUser();
        }

        protected void gvUser_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            string id = e.CommandArgument.ToString();

            if (e.CommandName == "sua")
            {
                EditUser(id);
            }
            else if (e.CommandName == "xoa")
            {
                DeleteUser(id);
                LoadUser();
            }
        }

        void EditUser(string id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                string sql = "SELECT * FROM Users WHERE UserID=" + id;
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                da.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    hdUserID.Value = dt.Rows[0]["UserID"].ToString();
                    txtUsername.Text = dt.Rows[0]["Username"].ToString();
                    txtPassword.Text = dt.Rows[0]["Password"].ToString();
                    txtFullName.Text = dt.Rows[0]["FullName"].ToString();
                    txtEmail.Text = dt.Rows[0]["Email"].ToString();
                    ddlRole.SelectedValue = dt.Rows[0]["RoleID"].ToString();
                }
            }
        }

        void DeleteUser(string id)
        {
            using (SqlConnection con = new SqlConnection(connStr))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        protected void btnHuy_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        void ClearForm()
        {
            hdUserID.Value = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtFullName.Text = "";
            txtEmail.Text = "";
        }
    }
}
