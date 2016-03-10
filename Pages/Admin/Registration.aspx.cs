using System;
using System.Web.Security;

namespace Store.Pages.Admin
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                string username = Request.Form["username"];
                string password = Request.Form["password"];
                string email = Request.Form["email"];
                string userRole = UserRole.Text;
                if (username != null && password != null && email != null && userRole != null)
                {
                    Membership.CreateUser(username, password, email);
                    Roles.AddUserToRole(username, userRole);
                    Success.Text = "Пользователь" + username + "зарегистрирован!";
                }
            }
        }
    }
}