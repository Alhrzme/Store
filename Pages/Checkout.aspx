<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="Store.Pages.Checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPlaceHolder" runat="server">
    <div id="content">
        <div id="checkoutForm" class="checkout" runat="server">
            <h2>Оформить заказ</h2>
            Пожалуйста, введите свои данные!
            <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
            <div id="checkoutTable">
                <table>
                    <tr>
                        <td>Адрес доставки</td>
                        <td><SX:VInput Property="Address" ModelType="Order" runat="server"/></td>
                    </tr>
                    <tr>
                        <td>Номер телефона</td>
                        <td><SX:VInput Property="PhoneNumber" ModelType="Order" runat="server"/></td>
                    </tr>
                    <tr>
                        <td></td>
                        <td><p class="actionButtons">
                            <button class="actionButtons" type="submit">Обработать заказ</button></p>
                        </td>
                    </tr>
            </table>
            </div>
        </div>
        <div id="checkoutMessage" runat="server">
            <h2>Спасибо!</h2>
            Спасибо что выбрали наш магазин!
        </div>
    </div>
    
</asp:Content>
