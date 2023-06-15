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
    public partial class NewsLogin : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string password = txtPassword.Text;

            // Kiểm tra đăng nhập của người dùng
            if (KiemTraDangNhap(username, password, out string loaiTaiKhoan))
            {
                // Lưu tên đăng nhập và loại tài khoản vào Session
                Session["Username"] = username;
                Session["LoaiTaiKhoan"] = loaiTaiKhoan;

                // Lưu tên đăng nhập vào cookie
                HttpCookie usernameCookie = new HttpCookie("Username");
                HttpCookie loaitaikhoancookie = new HttpCookie("Loaitaikhoan");
                usernameCookie.Value = username;
                loaitaikhoancookie.Value = loaiTaiKhoan;
                Response.Cookies.Add(usernameCookie);
                Response.Cookies.Add(loaitaikhoancookie);

                // Đăng nhập thành công
                Response.Redirect("/Views/Index.aspx");
            }
            else
            {
                // Đăng nhập thất bại
                lbl_error.Text = "Đăng nhập không thành công, vui lòng kiểm tra lại tài khoản và mật khẩu";
            }
        }

        private bool KiemTraDangNhap(string username, string password, out string loaiTaiKhoan)
        {
            // Thực hiện truy vấn kiểm tra tài khoản người dùng trong cơ sở dữ liệu
            // Trả về true nếu tên đăng nhập và mật khẩu hợp lệ, ngược lại trả về false

            // Kết nối đến cơ sở dữ liệu và thực hiện truy vấn kiểm tra tài khoản

            string query = "SELECT LoaiTaiKhoan FROM NguoiDung WHERE TenNguoiDung = @Username AND MatKhau = @Password";

            using (ketnoi = new SqlConnection(connStr))
            {
                if (ketnoi.State == ConnectionState.Closed) { ketnoi.Open(); }
                SqlCommand cmd = new SqlCommand(query, ketnoi);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Password", password);

                object result = cmd.ExecuteScalar();
                ketnoi.Close();

                if (result != null)
                {
                    loaiTaiKhoan = result.ToString();
                    return true;
                }
                else
                {
                    loaiTaiKhoan = string.Empty;
                    return false;
                }
            }
        }
    }
}