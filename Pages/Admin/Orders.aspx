<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Orders.aspx.cs" Inherits="Store.Pages.Admin.Orders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        Заказы
    </div>
    <div class="ordersContainer">
        <asp:ListView ID="ListView1" ItemType="Store.Models.Order" SelectMethod="GetOrders"
            EnableViewState="false" DataKeyNames="OrderID" UpdateMethod="UpdateOrder"
            DeleteMethod="DeleteOrder" OnSelectedIndexChanging="ListView1_SelectedIndexChanging" runat="server">
            <LayoutTemplate>
                <table id="ordersTable">
                    <tr>
                        <th class="firstTableStyle">Номер заказа</th>
                        <th class="secondTableStyle">Дата заказа</th>
                        <th class="thirdTableStyle">Адрес</th>
                        <th class="thirdTableStyle">Номер телефона</th>
                        <th class="secondTableStyle">Количество товаров</th>
                        <th class="secondTableStyle">Стоимость заказа</th>
                        <th></th>
                        <th></th>
                    </tr>
                    <tr runat="server" id="itemPlaceholder"></tr>
                </table>
                <asp:DataPager runat="server" ID="ContactsDataPager" PageSize="10">
	                <Fields>
	                    <asp:NextPreviousPagerField ShowFirstPageButton="true" ShowLastPageButton="true"
	                        FirstPageText="|&lt;&lt; " LastPageText=" &gt;&gt;|"
	                        NextPageText=" &gt; " PreviousPageText=" &lt; " />
	                </Fields>
	            </asp:DataPager>
                
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td class="firstTableStyle"><%# Item.OrderID %></td>
                    <td class="secondTableStyle"><%# Item.Date.ToString("dd-M-yyyy") %></td>
                    <td class="thirdTableStyle"><%# Item.Address %></td>
                    <td class="thirdTableStyle"><%# Item.PhoneNumber %></td>
                    <td class="secondTableStyle"><%# Item.OrderItems.Sum(o => o.Quantity) %></td>
                    <td class="secondTableStyle"><%# Total(Item.OrderItems).ToString("C") %></td>
                    <td class="firstTableStyle">
                        <asp:PlaceHolder ID="PlaceHolder1" Visible="<%# !Item.IsConfirmed %>" runat="server">
                                <button class="orderTableButton" type="submit" name="confirm"
                                    value="<%# Item.OrderID %>">Подтвердить</button>
                            </asp:PlaceHolder>
                        <asp:PlaceHolder ID="PlaceHolder2" Visible="<%# Item.IsConfirmed %>" runat="server">
                            &#10004;
                        </asp:PlaceHolder>
                    <td class="fourthTableStyle">
                        <asp:Button ID="Button1" CssClass="orderTableButton" CommandName="Edit" Text="Изменить" runat="server" />
                        <asp:Button ID="Button2" CssClass="orderTableButton" CommandName="Delete" Text="Отменить" runat="server" />
                        <asp:Button ID="Button3" CommandName="Select" Text="Подробнее" CssClass="orderTableButton" runat="server" />
                    </td>

                </tr>
            </ItemTemplate>
            <SelectedItemTemplate>
                <tr>
                    <td class="selectedOrder firstTableStyle"><%# Item.OrderID %></td>
                    <td class="selectedOrder secondTableStyle"><%# Item.Date.ToString("dd-M-yyyy") %></td>
                    <td class="selectedOrder thirdTableStyle"><%# Item.Address %></td>
                    <td class="selectedOrder thirdTableStyle"><%# Item.PhoneNumber %></td>
                    <td class="selectedOrder secondTableStyle"><%# Item.OrderItems.Sum(o => o.Quantity) %></td>
                    <td class="selectedOrder secondTableStyle"><%# Total(Item.OrderItems).ToString("C") %></td>
                    <td class="firstTableStyle"><asp:PlaceHolder ID="PlaceHolder1" Visible="<%# !Item.IsConfirmed %>" runat="server">
                                <button class="orderTableButton" type="submit" name="confirm"
                                    value="<%# Item.OrderID %>">Подтвердить</button>
                            </asp:PlaceHolder>
                        <asp:PlaceHolder ID="PlaceHolder2" Visible="<%# Item.IsConfirmed %>" runat="server">
                            &#10004;
                        </asp:PlaceHolder></td>
                    <td class="fourthTableStyle">
                        <asp:Button ID="Button1" CommandName="Edit" CssClass="orderTableButton" Text="Изменить" runat="server" />
                        <asp:Button ID="Button2" CommandName="Delete" CssClass="orderTableButton" Text="Отменить" runat="server" />
                    </td>
                </tr>
                
            </SelectedItemTemplate>
            <EditItemTemplate>
                <tr>
                    <td class="firstTableStyle"><%# Item.OrderID %></td>
                    <td class="secondTableStyle"><%# Item.Date.ToString("dd-m-yyyy") %></td>
                    <td class="thirdTableStyle"><input name="address" value="<%# Item.Address %>" /></td>
                    <td class="thirdTableStyle"><input name="phoneNumber" value="<%# Item.PhoneNumber %>" /></td>
                    <td class="secondTableStyle"><%# Item.OrderItems.Sum(o => o.Quantity) %></td>
                    <td class="secondTableStyle"><%# Total(Item.OrderItems).ToString("C") %></td>
                    <td class="firstTableStyle"></td>
                    <td class="fourthTableStyle">
                        <asp:Button ID="UpdateButton" CssClass="orderTableButton" CommandName="Update" Text="Обновить" runat="server" />
                        <asp:Button ID="CancelButton" CssClass="orderTableButton" CommandName="Cancel" Text="Отмена" runat="server" />
                    </td>
                </tr>
            </EditItemTemplate>
        </asp:ListView>
       <asp:GridView ID="GridView1" AutoGenerateColumns="false" ItemType="Store.Models.OrderItem" runat="server">
                        <Columns>
                            <asp:BoundField DataField="Item.ItemID" HeaderText="Номер товара" />
                            <asp:BoundField DataField="Item.Name" HeaderText="Название товара" />
                            <asp:BoundField DataField="Quantity" HeaderText="Количество" />
                            <asp:BoundField DataField="Item.Price" HeaderText="Цена товара" />
                        </Columns>
                    </asp:GridView>
    </div>
</asp:Content>
