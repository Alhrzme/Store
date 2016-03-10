using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using Store.Models;
using System.Web.ModelBinding;

namespace Store.Pages.Admin
{
    public partial class Orders : System.Web.UI.Page
    {
        List<Order> _orders = OrdersDB.GetOrders();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                int confirmID;
                if (int.TryParse(Request.Form["confirm"], out confirmID))
                {
                    Order myOrder = _orders.Where(o => o.OrderID == confirmID).FirstOrDefault();
                    if (myOrder != null)
                    {
                        OrdersDB.ConfirmOrder(confirmID);
                        myOrder.IsConfirmed = true;
                    }
                }
            }
        }

        public IQueryable<Order> GetOrders()
        {
            return _orders.AsQueryable<Order>();
        }

        public void UpdateOrder(int orderID)
        {
            Order myOrder = _orders.Where(p => p.OrderID == orderID).FirstOrDefault();
            if (myOrder != null && TryUpdateModel(myOrder,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                OrdersDB.UpdateOrder(myOrder);
            }
        }

        public void DeleteOrder(int orderID)
        {
            Order myOrder = _orders.Where(p => p.OrderID == orderID).FirstOrDefault();
            if (myOrder != null)
            {
                OrdersDB.DeleteOrder(myOrder);
            }
            _orders.Remove(myOrder);
        }

        public decimal Total(IEnumerable<OrderItem> orderLines)
        {
            decimal total = 0;
            foreach (OrderItem o in orderLines)
            {
                total += o.Item.Price * o.Quantity;
            }
            return total;
        }

        protected void ListView1_SelectedIndexChanging(object sender, ListViewSelectEventArgs e)
        {
            ListView1.SelectedIndex = e.NewSelectedIndex;
            int orderID = (int)ListView1.SelectedDataKey.Value;

            IEnumerable<OrderItem> orderItems = _orders.Where(o => o.OrderID == orderID).FirstOrDefault().OrderItems;
            GridView1.DataSource = orderItems;
            GridView1.DataBind();

        }

    }
}