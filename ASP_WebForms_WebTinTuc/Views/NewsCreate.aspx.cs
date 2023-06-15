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
    public partial class NewsCreate : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            string tieuDe = txtTieuDe.Text;
            int tacGiaId = Convert.ToInt32(drp_TacGia_Id.SelectedValue);
            int chuDeId = Convert.ToInt32(drp_ChuDe_Id.SelectedValue);
            string noiDung1 = txtNoiDung1.Text;
            string noiDung2 = txtNoiDung2.Text;
            string imageUrl = txtUrl.Text;

            // Thực hiện việc thêm dữ liệu vào bảng TinTuc
            string queryInsertTinTuc = "INSERT INTO TinTuc (TieuDe, Id_TacGia, Id_ChuDe) VALUES (@TieuDe, @Id_TacGia, @Id_ChuDe); SELECT SCOPE_IDENTITY()";
            int tinTucId;
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                SqlCommand cmd = new SqlCommand(queryInsertTinTuc, ketnoi);
                cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                cmd.Parameters.AddWithValue("@Id_TacGia", tacGiaId);
                cmd.Parameters.AddWithValue("@Id_ChuDe", chuDeId);
                tinTucId = Convert.ToInt32(cmd.ExecuteScalar());
            }

            // Thực hiện thêm dữ liệu vào bảng ChiTietTinTuc dựa trên Id TinTuc đã lấy trước đó
            string queryInsertChiTietTinTuc = "INSERT INTO ChiTietTinTuc VALUES (@Id_TinTuc, @NoiDung1, @HinhAnh, @NoiDung2)";
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                SqlCommand cmd = new SqlCommand(queryInsertChiTietTinTuc, ketnoi);
                cmd.Parameters.AddWithValue("@Id_TinTuc", tinTucId);
                cmd.Parameters.AddWithValue("@NoiDung1", noiDung1);
                cmd.Parameters.AddWithValue("@HinhAnh", imageUrl);
                cmd.Parameters.AddWithValue("@NoiDung2", noiDung2);
                cmd.ExecuteNonQuery();
            }
            //Sau khi thêm xong trả về trang Index
            Response.Redirect("Index");
        }
    }
}