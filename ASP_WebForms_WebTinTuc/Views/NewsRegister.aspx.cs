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
    public partial class NewsRegister : System.Web.UI.Page
    {
        string connStr = ConfigurationManager.ConnectionStrings["ASP_NEWS"].ConnectionString.ToString();
        SqlConnection ketnoi;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Kiểm tra tên tài khoản đã tồn tại trong CSDL hay chưa
            bool isUserNameExists = CheckUserName(txtUserName.Text);

            if (isUserNameExists)
            {
                // Nếu tên tài khoản đã tồn tại, hiển thị thông báo lỗi
                lbl_error.Text = "Tên tài khoản đã tồn tại. vui lòng thử tên khác";
            }
            else
            {
                lbl_error.Text = string.Empty;
                // Nếu tên tài khoản chưa tồn tại, thêm mới dữ liệu vào CSDL
                using (ketnoi = new SqlConnection(connStr))
                {
                    if (ketnoi.State == System.Data.ConnectionState.Closed) { ketnoi.Open(); }
                    //Kiểm tra xem password có giống nhau không, nếu giống thì thực hiện tiếp, khác thì trả về thông báo lỗi
                    if (txtPassword.Text == txtRePassword.Text)
                    {
                        string query = "INSERT nguoidung VALUES (@TenNguoiDung, @MatKhau, @LoaiTaiKhoan)";
                        SqlCommand cmd = new SqlCommand(query, ketnoi);
                        cmd.Parameters.AddWithValue("@TenNguoiDung", txtUserName.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txtPassword.Text);
                        cmd.Parameters.AddWithValue("@LoaiTaiKhoan", "user");   //Loại tài khoản mặt định
                        cmd.ExecuteNonQuery();

                        //Hiển thị thông báo đăng ký thành công
                        lbl_error.ForeColor = System.Drawing.Color.Green;
                        lbl_error.Text = "Chúc mừng bạn đăng ký thành công";

                        //chuyển hướng về trang đăng nhập
                        Response.AppendHeader("Refresh", "2;url=/Views/NewsLogin");
                        //Response.Redirect("/Login.aspx");
                    }
                    else
                    {
                        lbl_error.Text = "Mật khẩu và nhập lại mật khẩu không giống nhau";
                    }
                }
            }
        }

        private bool CheckUserName(string userName)
        {
            using (ketnoi = new SqlConnection(connStr))
            {
                ketnoi.Open();
                string query = "SELECT COUNT(*) FROM dbo.NguoiDung WHERE TenNguoiDung = @TenNguoiDung";
                SqlCommand cmd = new SqlCommand(query, ketnoi);

                cmd.Parameters.AddWithValue("TenNguoiDung", txtUserName.Text);

                int count = (int)cmd.ExecuteScalar();

                //Trả về true nếu tên tài khoản có tồn tại
                return count > 0;
            }
        }
    }
}