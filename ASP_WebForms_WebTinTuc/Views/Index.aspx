<%@ Page Title="" Language="C#" MasterPageFile="~/_MyLayout.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="ASP_WebForms_WebTinTuc.Views.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container">

        <div class="content">
            <div class="news_list">
                <asp:Repeater ID="Repeater1"  runat="server">
                    <ItemTemplate>

                        <div class="news_list_item">
                            <h2 class="news_list_title">
                                <a href="#" class="link_item"><%# Eval("TieuDe") %></a>
                            </h2>
                            <div class="news_list_desc">
                                <div class="news_list_img">
                                    <img src="<%# Eval("HinhAnh") %>" alt="">
                                </div>
                                <div class="news_list_description">
                                    <p class="news_list_desc_summary">
                                        <%# Eval("NoiDung1") %>
                                    </p>
                                    <div class="news_list_desc_sub">
                                        <a href="<%# "NewsDetails.aspx?id=" + Eval("Id") %>" class="link_item">Xem Thêm</a>
                                        <div class="news_list_sub">
                                            <p class="news_list_datetime"><%# Convert.ToDateTime(Eval("NgayDang")).ToString("dd/MM/yyyy") %></p>
                                            <p class="news_list_auther">Tác giả: <a href="#"><%# Eval("TenTG") %></a>
                                            </p>
                                        </div>
                                    </div>
                                </div>
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
