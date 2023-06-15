<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="NewsManager.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.NewsManager" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="news_manager_search">
          <div class="news_manager_search_content">
              <asp:TextBox ID="txtSearch" class="news_manager_search_text" placeholder="Tìm kiếm tin tức" runat="server"></asp:TextBox>
              <asp:Button ID="btnSearch" class="news_manager_search_btn" OnClick="btnSearch_Click" runat="server" Text="Tìm Kiếm" />
          </div>
          <div class="news_manager_search_sub_content">
            <p>Tìm kiếm Theo: </p>
              <asp:RadioButton style="padding-right: 10px" ID="rdbtnTen" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"  Text="Tên" runat="server" />
              <asp:RadioButton style="padding-right: 10px" ID="rdbtnChuDe" OnCheckedChanged="RadioButton_CheckedChanged" AutoPostBack="true"  Text="Chủ đề" runat="server" />
          </div>
        </div>

      <div class="news_manager">

        <asp:Repeater ID="Repeater1" runat="server">
          <ItemTemplate>

            <div class="news_manager_item">
              <div class="news_manager_item_image">
                <img src="<%# Eval("HinhAnh") %>" alt="" class="nws_mgr_item_img">
              </div>
              <div class="news_manager_item_content">
                <h3 class="news_manager_item_title"><%# Eval("TieuDe") %></h3>
                <div class="news_manager_item_auther">
                    <a href="#"><%# Eval("TenChuDe") %></a>
                    <p><%# Convert.ToDateTime(Eval("NgayDang")).ToString("dd/MM/yyyy") %></p>
                    <a href="#"><%# Eval("TenTG") %></a>
                </div>
                <div class="news_manager_item_CRUD">
                  <a href="<%# "NewsEdit.aspx?id=" + Eval("Id") %>" class="news_manager_item_CRUD_edit">Sửa</a>
                  <a href="<%# "NewsDetails.aspx?id=" + Eval("Id") %>" class="news_manager_item_CRUD_detail">Chi Tiết</a>
                  <a href="<%# "NewsDelete.aspx?id=" + Eval("Id") %>" class="news_manager_item_CRUD_delete">Xóa</a>
                </div>
              </div>
            </div>

          </ItemTemplate>
        </asp:Repeater>

      </div>
    </div>

</asp:Content>
