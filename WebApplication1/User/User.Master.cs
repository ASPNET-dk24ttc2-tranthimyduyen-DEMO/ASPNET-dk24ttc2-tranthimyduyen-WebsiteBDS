using System;

namespace WebApplication1.User
{
    public partial class User : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null || Session["RoleID"].ToString() != "2")
            {
                Response.Redirect("~/DangNhap.aspx");
            }

            lblFullName.Text = Session["FullName"].ToString();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/DangNhap.aspx");
        }
    }
}
