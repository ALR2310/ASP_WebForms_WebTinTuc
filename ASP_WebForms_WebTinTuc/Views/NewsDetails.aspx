<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="NewsDetails.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.NewsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="news_Details">
          <div class="news_details_header">
            <div class="news_details_header_title">
              <h1>
                  <asp:Label ID="lblTieuDe" runat="server" Text="Tiêu Đề"></asp:Label>
              </h1>
            </div>
            <div class="news_details_title_desc">
              <ul class="news_details_tdesc_list">
                <li class="news_details_tdesc_item">
                    <asp:Label ID="lblChuDe" runat="server" Text="Chủ Đề"></asp:Label>
                </li>
                <li class="news_details_tdesc_item">
                    <asp:Label ID="lblNgayDang" runat="server" Text="Ngày Đăng"></asp:Label>
                </li>
              </ul>

              <ul class="news_details_tdesc_list">
                <li class="news_details_tdesc_item">
                    <asp:Label ID="lblTacGia" runat="server" Text="Tác Giả"></asp:Label>
                </li>
              </ul>
            </div>
          </div>
          <div class="news_details_body">
            <div class="news_details_body_content">
              <asp:Label ID="lblNoiDung1" runat="server" Text="Nội Dung 1"></asp:Label>
            </div>

            <div class="news_details_body_img">
              <asp:Image ID="imgHinhAnh" runat="server" />
            </div>

            <div class="news_details_body_content">
              <asp:Label ID="lblNoiDung2" runat="server" Text="Nội dung 2"></asp:Label>
            </div>
          </div>
        </div>

        <div class="news_details_more">
          <h3>Các Nội dung tương tự cùng chủ đề</h3>
          <div class="news_details_more_list">

            <asp:Repeater ID="Repeater1" runat="server">
              <ItemTemplate>

                <div class="nws_des_more_item">
                  <div class="nws_des_more_item_img">
                    <img
                      src="<%# Eval("HinhAnh") %>" alt="">
                  </div>
                  <div class="nws_des_more_item_title">
                    <a href="#"><%# Eval("TieuDe") %></a>
                  </div>
                </div>

              </ItemTemplate>
            </asp:Repeater>

          </div>
        </div>

    </div>

    

    <div class="menuleft">
        <div class="menuleft_content">
          <asp:Repeater ID="Repeater2" runat="server">
            <ItemTemplate>
              <div class="menuleft_item">
                <div class="menuleft_item_img">
                  <img src="<%# Eval("HinhAnh") %>" alt="">
                </div>
                <h4 class="menuleft_item_title">
                  <a href="#" class="menuleft_item_link"><%# Eval("TieuDe") %></a>
                </h4>
              </div>
            </ItemTemplate>
          </asp:Repeater>
  
        </div>
      </div>

</asp:Content>
