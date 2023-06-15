using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_WebForms_WebTinTuc.Views
{
    public partial class NewsDelete : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int IdTinTuc = Convert.ToInt32(Request.QueryString["id"]);
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }

                //Xoá dữ liệu bảng chitiettintuc
                string query = "DELETE FROM ChiTietTinTuc WHERE Id_TinTuc = @Id_TinTuc";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@Id_TinTuc", IdTinTuc);
                cmd.ExecuteNonQuery();

                //Xoá dữ liệu bảng tintuc
                query = "DELETE FROM dbo.TinTuc WHERE Id = @Id";
                cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@Id", IdTinTuc);
                cmd.ExecuteNonQuery();
            }

            Response.Redirect("NewsManager.aspx");
        }
    }
}