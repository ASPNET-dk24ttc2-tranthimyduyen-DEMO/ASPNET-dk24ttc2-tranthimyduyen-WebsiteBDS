using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Admin
{
    public partial class QLNguoiDung : System.Web.UI.Page
    {
        string connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUsers();
                LoadRolesToAdd();
            }
        }

        void LoadUsers()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"
                    SELECT Users.*, Role.RoleName 
                    FROM Users 
                    INNER JOIN Role ON Users.RoleID = Role.RoleID";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                gvUsers.DataSource = dt;
                gvUsers.DataBind();
            }
        }

        void LoadRolesToAdd()
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT RoleID, RoleName FROM Role", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddlAddRole.DataSource = dt;
                ddlAddRole.DataTextField = "RoleName";
                ddlAddRole.DataValueField = "RoleID";
                ddlAddRole.DataBind();
            }
        }

        void LoadRolesToEdit(DropDownList ddl)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT RoleID, RoleName FROM Role", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                ddl.DataSource = dt;
                ddl.DataTextField = "RoleName";
                ddl.DataValueField = "RoleID";
                ddl.DataBind();
            }
        }

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            LoadUsers();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            LoadUsers();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            GridViewRow row = gvUsers.Rows[e.RowIndex];

            TextBox txtFull = (TextBox)row.FindControl("txtFullNameEdit");
            TextBox txtEmail = (TextBox)row.FindControl("txtEmailEdit");
            DropDownList ddlRole = (DropDownList)row.FindControl("ddlRole");

            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = "UPDATE Users SET FullName=@Full, Email=@Email, RoleID=@Role WHERE UserID=@ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Full", txtFull.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Role", ddlRole.SelectedValue);
                cmd.Parameters.AddWithValue("@ID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            gvUsers.EditIndex = -1;
            LoadUsers();
        }


        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Value);

            using (SqlConnection conn = new SqlConnection(connString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID=@ID", conn);
                cmd.Parameters.AddWithValue("@ID", userID);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                string query = @"INSERT INTO Users (Username, Password, FullName, Email, RoleID)
                                 VALUES (@User, @Pass, @Full, @Email, @Role)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@User", txtUsername.Text);
                cmd.Parameters.AddWithValue("@Pass", txtPassword.Text);
                cmd.Parameters.AddWithValue("@Full", txtFullName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Role", ddlAddRole.SelectedValue);

                conn.Open();
                cmd.ExecuteNonQuery();
            }

            lblMessage.Text = "Đã thêm thành công!";
            LoadUsers();
        }

        protected void gvUsers_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow && e.Row.RowIndex == gvUsers.EditIndex)
            {
                DropDownList ddl = (DropDownList)e.Row.FindControl("ddlRole");
                LoadRolesToEdit(ddl);

                string selectedRole = DataBinder.Eval(e.Row.DataItem, "RoleID").ToString();
                ddl.SelectedValue = selectedRole;
            }
        }
    }
}
