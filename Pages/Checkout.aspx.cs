using Store.Models;
using System;
using System.Web.ModelBinding;
using Store.Pages.Helpers;

namespace Store.Pages
{
    public partial class Checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkoutForm.Visible = true;
            checkoutMessage.Visible = false;

            if (IsPostBack)
            {
                Order myOrder = SessionHelper.GetOrder(Session);
                if (TryUpdateModel(myOrder, new FormValueProvider(ModelBindingExecutionContext)))
                {
                    myOrder.Date = DateTime.Now;
                    OrdersDB.SaveOrder(myOrder);
                    myOrder.Clear();
                    checkoutForm.Visible = false;
                    checkoutMessage.Visible = true;
                }
            }
        }
    }
}