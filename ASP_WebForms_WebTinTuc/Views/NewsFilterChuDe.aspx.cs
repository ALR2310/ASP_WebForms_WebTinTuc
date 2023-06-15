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
    public partial class NewsFilterChuDe : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    int Id_ChuDe = Convert.ToInt32(Request.QueryString["id"]);
                    LoadData(Id_ChuDe);
                }
            }
        }

        void LoadData(int Id_ChuDe)
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == ConnectionState.Closed) { ketnoi.Open(); }
                string query = "SELECT dbo.TinTuc.Id, dbo.TinTuc.TieuDe, dbo.TinTuc.Id_TacGia, " +
                    "dbo.TinTuc.Id_ChuDe, dbo.ChiTietTinTuc.Id AS 'IdChiTiet', " +
                    "dbo.ChiTietTinTuc.NoiDung1, dbo.ChiTietTinTuc.HinhAnh, dbo.ChiTietTinTuc.NoiDung2 " +
                    "FROM TinTuc INNER JOIN ChiTietTinTuc ON ChiTietTinTuc.Id_TinTuc = TinTuc.Id " +
                    "INNER JOIN TacGia ON TacGia.Id = TinTuc.Id_TacGia INNER JOIN ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe " +
                    "WHERE Id_ChuDe = @Id_ChuDe ORDER BY NEWID()";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@Id_ChuDe", Id_ChuDe);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                Repeater1.DataSource = data;
                Repeater1.DataBind();
            }
        }
    }
}