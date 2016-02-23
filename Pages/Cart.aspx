<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="Store.Pages.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPlaceHolder" runat="server">
    <div id="content">
        <h2>Ваша корзина</h2>
        <table id="cartTable">
            <thead>
                <tr>
                    <th>Кол-во товаров</th>
                    <th>Название</th>
                    <th>Цена</th>
                    <th>Общая стоимость</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="Repeater1" ItemType="Store.Models.OrderItem"
                    SelectMethod="GetOrderItems" EnableViewState="false" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Item.Quantity %></td>
                            <td><%# Item.Item.Name %></td>
                            <td><%# Item.Item.Price.ToString("c")%></td>
                            <td><%# ((Item.Quantity * 
                                Item.Item.Price).ToString("c"))%></td>
                            <td>
                                <button type="submit" class="actionButtons" name="remove"
                                    value="<%#Item.Item.ItemID %>">
                                    Удалить</button>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
            <tfoot>
                <tr>
                    <td colspan="3">Итого:</td>
                    <td><%= OrderTotal.ToString("c") %></td>
                </tr>
            </tfoot>
        </table>
        <p class="actionButtons">
            <a href="<%=ReturnUrl %>">Продолжить покупки</a>
            <a href="<%=CheckoutUrl %>">Оформить заказ</a>
        </p>
    </div>
</asp:Content>
