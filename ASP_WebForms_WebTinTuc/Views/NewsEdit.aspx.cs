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
    public partial class NewsEdit : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int tinTucId = Convert.ToInt32(Request.QueryString["id"]);
                    LoadData(tinTucId);
                }
            }
        }

        void LoadData(int tinTucId)
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed)
                {
                    ketnoi.Open();
                }

                string query = "SELECT dbo.TinTuc.Id, dbo.TinTuc.TieuDe, dbo.TinTuc.Id_TacGia, dbo.TinTuc.Id_ChuDe, dbo.ChiTietTinTuc.Id AS 'IdChiTiet', dbo.ChiTietTinTuc.NoiDung1, dbo.ChiTietTinTuc.HinhAnh, dbo.ChiTietTinTuc.NoiDung2 FROM TinTuc INNER JOIN ChiTietTinTuc ON ChiTietTinTuc.Id_TinTuc = TinTuc.Id INNER JOIN TacGia ON TacGia.Id = TinTuc.Id_TacGia INNER JOIN ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe WHERE TinTuc.Id = @TinTucId";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@TinTucId", tinTucId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Hiển thị thông tin tin tức trên trang NewsEdit
                    txtTieuDe.Text = reader["TieuDe"].ToString();
                    txtNoiDung1.Text = reader["NoiDung1"].ToString();
                    txtHinhAnh.Text = reader["HinhAnh"].ToString();
                    txtNoiDung2.Text = reader["NoiDung2"].ToString();

                    //Chuyển đổi kiểu dữ liệu của 2 trường TacGia và ChuDe
                    int idTacGia, idChuDe;
                    bool successTG = int.TryParse(reader["Id_TacGia"].ToString(), out idTacGia);
                    bool successCD = int.TryParse(reader["Id_ChuDe"].ToString(), out idChuDe);
                    if (successTG) { drp_TacGia_Id.SelectedIndex = idTacGia; }
                    if (successCD) { drp_ChuDe_Id.SelectedIndex = idChuDe; }
                }

                reader.Close();
            }
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int tinTucId = Convert.ToInt32(Request.QueryString["id"]);
            string tieuDe = txtTieuDe.Text;
            int idTacGia = Convert.ToInt32(drp_TacGia_Id.SelectedValue);
            int idChuDe = Convert.ToInt32(drp_ChuDe_Id.SelectedValue);

            string noiDung1 = txtNoiDung1.Text;
            string hinhAnh = txtHinhAnh.Text;
            string noiDung2 = txtNoiDung2.Text;


            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed)
                {
                    ketnoi.Open();
                }

                // Cập nhật thông tin chỉnh sửa vào bảng tintuc
                string query = "UPDATE TinTuc SET TieuDe = @TieuDe, Id_TacGia = @Id_TacGia, Id_ChuDe = @Id_ChuDe WHERE Id = @TinTucId";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@TieuDe", tieuDe);
                cmd.Parameters.AddWithValue("@Id_TacGia", idTacGia);
                cmd.Parameters.AddWithValue("@Id_ChuDe", idChuDe);
                cmd.Parameters.AddWithValue("@TinTucId", tinTucId);
                cmd.ExecuteNonQuery();

                //Cập nhật thông tin chỉnh sửa vào bảng Chitiettintuc
                query = "UPDATE ChiTietTinTuc SET NoiDung1 = @NoiDung1, HinhAnh = @HinhAnh, NoiDung2 = @NoiDung2 WHERE Id_TinTuc = @TinTucId";
                cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@NoiDung1", noiDung1);
                cmd.Parameters.AddWithValue("@HinhAnh", hinhAnh);
                cmd.Parameters.AddWithValue("@NoiDung2", noiDung2);
                cmd.Parameters.AddWithValue("@TinTucId", tinTucId);
                cmd.ExecuteNonQuery();
            }

            //Chuyển hướng về trang Manager sau khi lưu chỉnh sửa thành công
            Response.Redirect("NewsManager");
        }
    }
}