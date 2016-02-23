<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Store.Pages.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link rel="stylesheet" href="/Content/LoginStyles.css" />
    <title>Вход в систему</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        Интернет-магазин
    </div>
        <div class="title">
            Вход в систему
        </div>
        <div id="loginContainer">
            <asp:Login ID="Login1" runat="server"
                TitleText="Введите, пожалуйста, данные"
                UsernameRequiredErrorMessage="Введите, пожалуйста, ваш логин 乁(๏ ͜ʖ๏)ㄏ"
                PasswordRequiredErrorMessage="Введите, пожалуйста, ваш пароль 乁(๏ ͜ʖ๏)ㄏ"
                FailureText="Имя пользователя или пароль неверны ( ͡°෴ ͡°)"
                LoginButtonText="Войти"
                >

            </asp:Login>
        </div>
    </form>
</body>
</html>
