using System;

namespace WebApplication1.Admin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Kiểm tra phân quyền
            if (Session["RoleID"] == null || Session["RoleID"].ToString() != "1")
            {
                Response.Redirect("~/DangNhap.aspx");
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("~/DangNhap.aspx");
        }
    }
}
