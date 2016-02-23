<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true"
     CodeBehind="ItemList.aspx.cs" Inherits="Store.Pages.ItemList"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="MasterPlaceHolder" runat="server">
    <div class="adminLink" id="admin" runat="server">
        <a href="<%=GetAdminLink() %>">Админка</a>
    </div>
    <div id="content">
        <div id="catalog_sorter">
            <div id="sortingSelection">
                <span>Сортировать по:</span>
                <a href='<%= GetSortingLink("name") %>'>имени</a> |
                <a href='<%= GetSortingLink("price") %>'>цене</a> |
                <a href='<%= GetSortingLink("weight") %>'>весу</a> |
                <a href='<%= GetSortingLink("default") %>'>умолчанию</a>
            </div>
            <div id="pageSizeSelection">
                <span>Показывать по</span>
                <%
                    for (int i = 0; i < pageSizes.Length; i++)
                    {
                        string path = GetPageSizeLink(pageSizes[i]);
                        Response.Write(
                            String.Format("<a href='{0}' {1}>{2}</a> ",
                                path, pageSizes[i] == CurrentPageSize ? "class='selectedPageSize'" : "", pageSizes[i]));
                    }
                %>
            </div>
            <div class="priceSelection">
                <span>Цена</span>
                от <input type="number" name="MinPriceTextBox" />
                до <input type="number" name="MaxPriceTextBox" />
                <asp:Button ID="PriceSortingButton" CssClass="priceSelectionButton" OnClick="PriceSortingButton_Click" runat="server" Text="ОК" />
            </div>
        </div>
        <asp:ListView ID="ListView1" ItemType="Store.Models.Item" SelectMethod="GetItems"
         GroupItemCount="4" runat="server">
            <ItemTemplate>
                <td>
                    <div class="item">
                        <%# GetImageLink((int)Eval("ItemID")) %><br />
                        <a href="<%# GetItemPageLink((int)Eval("ItemID")) %>" ><%# Eval("Name") %></a> <br />
                        <%# ShortenString(Eval("Description").ToString()) %><br />
                        <%# Eval("Price") %>
                    </div>
                </td>
            </ItemTemplate>
            <LayoutTemplate>
                <table>
                    <tr id="groupPlaceholder" runat="server"></tr>
                </table>
            </LayoutTemplate>
            <GroupTemplate>
	            <tr>
	                <td runat="server" id="itemPlaceholder" />
	            </tr>
            </GroupTemplate>
        
        </asp:ListView><br />
    </div>
    <div class="pager">
        <%
            for (int i = 1; i <= MaxPage; i++)
            {
                string path = GetPagerLink(i);
                Response.Write(
                    String.Format("<a href='{0}' {1}>{2}</a>",
                        path, i == CurrentPage ? "class='selected'" : "", i));
            }
        %>
    </div>
</asp:Content>
