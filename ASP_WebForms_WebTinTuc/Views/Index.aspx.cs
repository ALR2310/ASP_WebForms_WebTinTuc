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
    public partial class Index : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
                LoadDataMenuLeft();
            }
        }

        void LoadData()
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == ConnectionState.Closed) { ketnoi.Open(); }
                string query = "SELECT t.Id, t.TieuDe, t.NgayDang, t.Id_TacGia, c.NoiDung1, c.HinhAnh, a.TenTG " +
                    "FROM TinTuc t INNER JOIN ChiTietTinTuc c ON t.Id = c.Id_TinTuc " +
                    "INNER JOIN TacGia a ON t.Id_TacGia = a.Id  ORDER BY t.Id DESC";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                Repeater1.DataSource = data;
                Repeater1.DataBind();
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
    }
}