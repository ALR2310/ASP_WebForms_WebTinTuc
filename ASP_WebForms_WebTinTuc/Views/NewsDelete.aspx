<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="NewsDelete.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.NewsDelete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="news_delete">
          <div class="news_delete_title">
            <h1>Bạn có chắc muốn xoá bản tin này không?</h1>
          </div>
          <div class="news_delete_button">
              <asp:Button ID="btnDelete" class="news_delete_button_submit" OnClick="btnDelete_Click" runat="server" Text="Xoá Ngay" />
            <a class="news_delete_button_cancel" href="/NewsManager">Quay lại</a>
          </div>
          <div class="news_delete_content">

          </div>
        </div>

    </div>

</asp:Content>
