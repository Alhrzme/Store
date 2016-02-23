<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Master.Master" AutoEventWireup="true" CodeBehind="ItemPage.aspx.cs" Inherits="Store.Pages.ItemPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MasterPlaceHolder" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/AjaxWebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <script>
        function AddOrderItem() {
            var quantity = document.getElementById("quantity").value;
            var id = <%=CurrentItemID %>;
            Store.AjaxWebService.AddOrderItemToOrder(quantity, id);
        }
        function BuyNowButton_Click() {
            AddOrderItem();
            location.href = "/checkout";
        }
        function AddToCartButton_Click() {
            AddOrderItem();
            var w = 400;
            var h = 180;
            var leftvar = (screen.width - w) / 2;
            var topvar = 200
            window.open("Pages/PageInWindow.html", "window",
                "width=" + w + ", height=" + h + ",left=" + leftvar + ",top=" + topvar);
        }
    </script>
    <div id="content">
        <div class="itemDetails">
            <div id="itemImage">
                <%= GetImageLink() %>
            </div>
            <div id="itemDescriptions">
                <table>
                    <tr>
                        <td>Название</td>
                        <td><%=CurrentItem.Name %></td>
                    </tr>
                    <tr>
                        <td>Цена</td>
                        <td><%=CurrentItem.Price.ToString("c") %></td>
                    </tr>
                    <tr>
                        <td>Вес</td>
                        <td><%=CurrentItem.Weight+"кг" %></td>
                    </tr>
                    <tr>
                        <td>Описание</td>
                        <td><%=CurrentItem.Description %></td>
                    </tr>
                    <tr>
                        <td>Количество</td>
                        <td><input type="text" value="1" id="quantity" /></td>
                    </tr>
                    <tr>
                        <td><input type="button" class="buttonsToBuy" value="&lt&lt Назад к товарам" onclick="location.href = '/list'" /></td>
                    <td>
                        <input type="button" onclick="AddToCartButton_Click()" class="buttonsToBuy" value="Добавить в корзину"  />
                        <input type="button" onclick="BuyNowButton_Click()" class="buttonsToBuy" value="Купить сейчас" />
                    </td>
                    </tr>
                </table>
            </div>
        </div>
    </div>
    
</asp:Content>
