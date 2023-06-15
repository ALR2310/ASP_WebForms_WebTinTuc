<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="NewsEdit.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.NewsEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="news_create">
            <asp:TextBox ID="txtTieuDe"  placeholder="Tiêu đề" class="news_create_input" runat="server"></asp:TextBox>
        </div>
        <div class="news_create">
            <asp:Label class="news_create_labelfordrp" ID="Label1" runat="server" Text="Tác Giả:"></asp:Label>
            <asp:DropDownList class="input_auther" ID="drp_TacGia_Id" runat="server" DataTextField="TenTG" DataValueField="Id" DataSourceID="SqlDataSource1"></asp:DropDownList>
            <asp:Label class="news_create_labelfordrp" ID="Label2" runat="server" Text="Chủ Đề"></asp:Label>
            <asp:DropDownList class="input_category" ID="drp_ChuDe_Id" runat="server" DataTextField="TenChuDe" DataValueField="Id" DataSourceID="SqlDataSource2"></asp:DropDownList>
        </div>
        <div class="news_create">
          <asp:TextBox ID="txtNoiDung1" TextMode="MultiLine" runat="server" class="news_content_input" placeholder="Nội dung" ></asp:TextBox>
        </div>
        <div class="news_create">
            <asp:TextBox ID="txtHinhAnh" TextMode="Url" placeholder="Địa chỉ hình ảnh" class="news_create_input news_create_img" runat="server"></asp:TextBox>
        </div>
        <div class="news_create">
          <asp:TextBox ID="txtNoiDung2" TextMode="MultiLine" runat="server" class="news_content_input" placeholder="Nội dung" ></asp:TextBox>
        </div>
        <div class="news_create">
          <div class="news_create_btn">
              <asp:Button ID="btnEdit" OnClick="btnEdit_Click" class="news_create_btn_submit" runat="server" Text="Cập Nhật Bài Viết" />
          </div>
        </div>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ASP_NEWS_AdvanceConnectionString %>" SelectCommand="SELECT * FROM [TacGia]"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ASP_NEWS_AdvanceConnectionString %>" SelectCommand="SELECT * FROM [ChuDe]"></asp:SqlDataSource>

      </div>

</asp:Content>
