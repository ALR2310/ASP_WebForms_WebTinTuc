using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASP_WebForms_WebTinTuc.Views
{
    public partial class NewsDetails : System.Web.UI.Page
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
                LoadDataMenuLeft();
                RandomChuDe();
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

                string query = "SELECT t.Id, t.TieuDe, a.TenTG, t.Id_ChuDe, d.TenChuDe, t.NgayDang, c.NoiDung1, c.HinhAnh, c.NoiDung2 " +
                    "FROM TinTuc t INNER JOIN ChiTietTinTuc c ON t.Id = c.Id_TinTuc INNER JOIN TacGia a ON t.Id_TacGia = a.Id " +
                    "INNER JOIN dbo.ChuDe d ON d.Id = t.Id_ChuDe WHERE t.Id = @TinTucId";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@TinTucId", tinTucId);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string tieuDe = reader["TieuDe"].ToString();
                    string noiDung1 = reader["NoiDung1"].ToString();
                    string hinhAnh = reader["HinhAnh"].ToString();
                    string noiDung2 = reader["NoiDung2"].ToString();
                    string tenTg = reader["TenTG"].ToString();
                    string chude = reader["TenChuDe"].ToString();
                    string ngaydang = reader["NgayDang"].ToString();

                    // Hiển thị thông tin tin tức trên trang NewsDetails
                    lblTieuDe.Text = tieuDe;
                    lblNoiDung1.Text = noiDung1;
                    imgHinhAnh.ImageUrl = hinhAnh;
                    lblNoiDung2.Text = noiDung2;
                    lblTacGia.Text = tenTg;
                    lblChuDe.Text = chude;
                    lblNgayDang.Text = ngaydang;
                }

                reader.Close();
            }
        }

        void LoadDataMenuLeft()
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == ConnectionState.Closed) { ketnoi.Open(); }
                string query = "SELECT TieuDe, HinhAnh FROM dbo.TinTuc INNER " +
                    "JOIN dbo.ChiTietTinTuc ON ChiTietTinTuc.Id_TinTuc = TinTuc.Id ORDER BY NEWID()";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                Repeater2.DataSource = data;
                Repeater2.DataBind();
            }
        }

        void RandomChuDe()
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == ConnectionState.Closed) { ketnoi.Open(); }
                string query = "SELECT TOP 3 TieuDe, HinhAnh FROM dbo.TinTuc " +
                    "INNER JOIN dbo.ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe " +
                    "INNER JOIN dbo.ChiTietTinTuc ON ChiTietTinTuc.Id_TinTuc = TinTuc.Id " +
                    "WHERE TenChuDe = @TenChuDe ORDER BY NEWID()";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@TenChuDe", lblChuDe.Text);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                Repeater1.DataSource = data;
                Repeater1.DataBind();
            }
        }
    }
}