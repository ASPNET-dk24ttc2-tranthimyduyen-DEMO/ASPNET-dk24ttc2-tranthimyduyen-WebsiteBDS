using System;
using WebApplication1.Admin;

namespace WebApplication1
{
    public partial class UserHome : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("~/DangNhap.aspx");
                }

                lblUser.Text = Session["UserName"].ToString();
            }
        }
    }
}
