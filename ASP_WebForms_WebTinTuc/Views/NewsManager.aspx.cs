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
    public partial class NewsManager : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsCallback)
            {
                LoadData();
                rdbtnTen.Checked = true;
            }
        }

        void LoadData()
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                string query = "select TinTuc.Id, TinTuc.TieuDe, NgayDang, TenChuDe, TenTG, ChiTietTinTuc.HinhAnh " +
                    "from TinTuc INNER JOIN dbo.TacGia ON TacGia.Id = TinTuc.Id_TacGia " +
                    "Inner Join ChiTietTinTuc On ChiTietTinTuc.Id_TinTuc = TinTuc.Id " +
                    "INNER JOIN dbo.ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe ORDER BY TinTuc.Id DESC";
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                adapter.Fill(data);

                Repeater1.DataSource = data;
                Repeater1.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text))
            {
                if (rdbtnTen.Checked == true)
                {
                    using (ketnoi = new SqlConnection(connStr))
                    {
                        if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                        string query = "select TinTuc.Id, TinTuc.TieuDe, TenChuDe, NgayDang, TenTG, ChiTietTinTuc.HinhAnh " +
                            "from TinTuc INNER JOIN dbo.TacGia ON TacGia.Id = TinTuc.Id_TacGia " +
                            "INNER JOIN dbo.ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe " +
                            "Inner Join ChiTietTinTuc On ChiTietTinTuc.Id_TinTuc = TinTuc.Id " +
                            "WHERE TieuDe LIKE N'%' + @TieuDe + '%'";
                        SqlCommand cmd = new SqlCommand(@query, ketnoi);
                        cmd.Parameters.AddWithValue("@TieuDe", txtSearch.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        Repeater1.DataSource = data;
                        Repeater1.DataBind();
                    }
                }
                else
                {
                    using (ketnoi = new SqlConnection(connStr))
                    {
                        if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                        string query = "select TinTuc.Id, TinTuc.TieuDe, TenChuDe, NgayDang, TenTG, ChiTietTinTuc.HinhAnh " +
                            "from TinTuc INNER JOIN dbo.TacGia ON TacGia.Id = TinTuc.Id_TacGia " +
                            "INNER JOIN dbo.ChuDe ON ChuDe.Id = TinTuc.Id_ChuDe " +
                            "Inner Join ChiTietTinTuc On ChiTietTinTuc.Id_TinTuc = TinTuc.Id " +
                            "WHERE TenChuDe LIKE N'%' + @TenChuDe +'%'";
                        SqlCommand cmd = new SqlCommand(@query, ketnoi);
                        cmd.Parameters.AddWithValue("@TenChuDe", txtSearch.Text);
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable data = new DataTable();
                        adapter.Fill(data);

                        Repeater1.DataSource = data;
                        Repeater1.DataBind();
                    }
                }
            }
        }

        protected void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton selectedRadioButton = sender as RadioButton;

            if (selectedRadioButton != null && selectedRadioButton.Checked)
            {
                if (selectedRadioButton == rdbtnTen)
                {
                    rdbtnChuDe.Checked = false;
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                        txtSearch.Text = string.Empty;
                }
                else if (selectedRadioButton == rdbtnChuDe)
                {
                    rdbtnTen.Checked = false;
                    if (!string.IsNullOrEmpty(txtSearch.Text))
                        txtSearch.Text = string.Empty;
                }
            }
        }
    }
}