using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class NhaChoThue : System.Web.UI.Page
    {
                string conn = ConfigurationManager.ConnectionStrings["WebBDS"].ConnectionString;

            protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {
                    LoadNhaDatChoThue();
                }
            }

            private void LoadNhaDatChoThue()
            {
                using (SqlConnection con = new SqlConnection(conn))
                {
                    string query = @"
                    SELECT ID, TieuDe, Gia, DiaChi, HinhAnh, NgayDang
                    FROM TinDang
                    WHERE IDLoaiBDS = 2
                    ORDER BY NgayDang DESC
                ";

                    SqlDataAdapter da = new SqlDataAdapter(query, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    rpBan.DataSource = dt;
                    rpBan.DataBind();
                }
            }
        }
    }
