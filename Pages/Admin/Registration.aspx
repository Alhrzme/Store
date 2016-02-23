<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Admin/Admin.master"
     AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Store.Pages.Admin.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="title">
            Регистрация пользователя
        </div>
    <div class="registrationForm">
        <asp:Label ID="Success" runat="server" Text="Label"></asp:Label>
        <div id="errors" data-valmsg-summary="true">
            <ul>
                <li style="display:none"></li>
            </ul>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        </div>
        <table>
            <tr>
                <td>Имя пользователя</td>
                <td>
                    <input name="username" data-val="true" data-val-required="Введите имя пользователя"
                        data-val-regex="Введите корректное имя"
                        data-val-regex-pattern="[a-zA-Z][a-zA-Z0-9-_\.]{3,20}$" />  
                </td>
            </tr>
            <tr>
                <td>Пароль</td>
                <td>
                    <input name="password" data-val="true" data-val-required="Введите пароль"
                        data-val-regex="Пароль должен содержать строчные и прописные латинские буквы, цифры"
                        data-val-regex-pattern="^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\s).*$"
                        type="password" />
                </td>
            </tr>
            <tr>
                <td>Повторите пароль</td>
                <td>
                    <input name="confirmPassword" data-val="true" 
                        data-val-required="Повторно введите пароль"
                        data-val-equalto="Введенные пароли должны совпадать"
                        data-val-equalto-other="password" type="password"/>
                </td>
            </tr>
            <tr>
                <td>Email</td>
                <td>
                    <input name="email" data-val="true" data-val-required="Введите email"
                        data-val-regex="Введите корректный email" 
                        data-val-regex-pattern="^[-\w.]+@([A-z0-9][-A-z0-9]+\.)+[A-z]{2,4}$" />
                </td>
            </tr>
            <tr>
                <td>Роль пользователя</td>
                <td>
                    <asp:RadioButtonList runat="server" ID="UserRole"
                        RepeatDirection="Horizontal" RepeatColumns="2">
                        <asp:ListItem Selected="true" Value="Clients">Клиент</asp:ListItem>
                        <asp:ListItem Value="Employee">Сотрудник</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
                <td>
                    <input type="submit" class="actionButton" value="Зарегистрировать" />
                </td>
            </tr>
        </table>

    </div>
</asp:Content>
