using System;

namespace WebApplication1
{
    public partial class Gdien : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                SetupMenu();
        }

        private void SetupMenu()
        {
            // ==== CHƯA ĐĂNG NHẬP ====
            if (Session["UserID"] == null)
            {
                linkDangNhap.Visible = true;
                linkDangKy.Visible = true;

                linkDangTin.Visible = true;
                linkDangXuat.Visible = false;

                linkProfile.Visible = false;       // Ẩn link trong dropdown
                linkUserProfile.Visible = false;   // Ẩn NÚT XANH (bạn đang muốn ẩn)

                linkDangTin.NavigateUrl = "~/DangNhap.aspx?returnUrl=DangTin.aspx";
                return;
            }

            // ==== ĐÃ ĐĂNG NHẬP ====
            linkDangNhap.Visible = false;
            linkDangKy.Visible = false;

            linkDangTin.Visible = true;
            linkDangXuat.Visible = true;

            linkProfile.Visible = true;
            linkUserProfile.Visible = true;

            lblUserName.InnerText =
                Session["FullName"] != null ? Session["FullName"].ToString() :
                Session["UserName"] != null ? Session["UserName"].ToString() :
                "User";

            // ==== PHÂN QUYỀN ====
            string role = Session["RoleID"] == null ? "0" : Session["RoleID"].ToString();

            if (role == "2")
            {
                // USER
                linkProfile.NavigateUrl = "~/User/ThongTinCaNhan.aspx";
                lnkQuanLyTin.NavigateUrl = "~/User/QuanLyTin.aspx";
                lnkQuanLyTin.Visible = true;
            }
            else
            {
                // ADMIN
                linkProfile.NavigateUrl = "~/Admin/Dashboard.aspx";
                lnkQuanLyTin.NavigateUrl = "~/Admin/QuanLyTin.aspx";
                lnkQuanLyTin.Visible = true;
            }

        }


        protected void linkDangXuat_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/Default.aspx");
        }

        protected void btnSearch2_Click(object sender, EventArgs e)
        {
            string url = "~/TimKiem.aspx?";
            url += "key=" + Server.UrlEncode(txtKey2.Text.Trim());
            url += "&loaiGD=" + ddlLoaiGD2.SelectedValue;
            url += "&loaiBDS=" + ddlLoaiBDS2.SelectedValue;
            url += "&tinh=" + ddlTinh2.SelectedValue;

            Response.Redirect(url);
        }
    }
}
