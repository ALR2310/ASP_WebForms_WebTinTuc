<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="NewsRegister.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.NewsRegister" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="login_form">
      <div class="center">
        <h1>Đăng Ký</h1>
        <div class="form_login" method="post">
          <div class="txt_field">
            <asp:TextBox ID="txtUserName" type="text" runat="server" required="true" />
            <span></span>
            <label>Tên Tài Khoản</label>
          </div>
          <div class="txt_field">
            <asp:TextBox Id="txtPassword" runat="server" TextMode="Password" required="true" />
            <span></span>
            <label>Mật Khẩu</label>
          </div>
            <div class="txt_field">
                <asp:TextBox ID="txtRePassword" runat="server" TextMode="Password" required="true" />
                <span></span>
                <label>Nhập Lại Mật Khẩu</label>
          </div>
            <div class="login_message">
                <asp:Label class="lbl_error" ID="lbl_error" runat="server"></asp:Label>
          </div>
            <asp:Button class="btn_login_submit" ID="btnLogin" runat="server" Text="Đăng Ký" OnClick="btnLogin_Click" />
          <div class="signup_link">Đã có tài khoản <a href="/Views/NewsLogin.aspx">Đăng Nhập</a></div>
        </div>
      </div>
    </div>

</asp:Content>
