<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="AddingItem.aspx.cs" Inherits="Store.Pages.Admin.AddingItem" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
        Добавление товаров
    </div>
    
    <div class="addingItem">
        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
            <div id="notation" style="margin-bottom:1.5em; font-size:1.3em">
                <asp:Label ID="Label1" runat="server" Text="Заполните следующие строки"></asp:Label>
            </div>
            <table id="insertTable">
                <tr>
                    <td>Название </td>
                    <td><SX:VInput Property="Name" ModelType="Item" runat="server" /></td>
                </tr>
                <tr>
                    <td>Цена</td>
                    <td><SX:VInput Property="Price" ModelType="Item" runat="server" /></td>
                </tr>
                <tr>
                    <td>Вес</td>
                    <td><SX:VInput Property="Weight" ModelType="Item" runat="server" /></td>
                </tr>
                <tr>
                    <td>Описание</td>
                    <td><SX:VInput Property="Description" ModelType="Item" runat="server" /></td>
                </tr>
                <tr>
                    <td>Категория</td>
                    <td><SX:VInput Property="Category" ModelType="Item" runat="server" /></td>
                </tr>
                <tr>
                    <td>Изображение</td>
                    <td><input runat="server" id="ItemImage" type="file" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Button ID="Button1" runat="server" CssClass="actionButton" Text="Добавить" OnClick="Button1_Click" />
                    </td>
                </tr>
            </table>
        
    </div>
</asp:Content>
