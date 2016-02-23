using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Order
    {
        private List<OrderItem> orderCollection = new List<OrderItem>();

        public int OrderID
        {
            get;
            set;
        }

        public bool IsConfirmed
        {
            get;
            set;
        }

        [Required(ErrorMessage ="Необходимо указать адрес доставки")]
        public string Address
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }
        [RegularExpression("^([0-9]{4,20})$", ErrorMessage ="Укажите корректный номер телефона")]
        [Required(ErrorMessage = "Необходимо указать ваш номер телефона")]
        public string PhoneNumber
        {
            get;
            set;
        }

        public IEnumerable<OrderItem> OrderItems
        {
            get
            {
                return orderCollection;
            }
        }

        public void AddItem(Item item, int quantity)
        {
            OrderItem orderItem = orderCollection
                .Where(p => p.Item.ItemID == item.ItemID)
                .FirstOrDefault();

            if (orderItem == null)
            {
                orderCollection.Add(new OrderItem
                {
                    Item = item,
                    Quantity = quantity
                });
            }
            else
            {
                orderItem.Quantity += quantity;
            }
        }

        public void RemoveOrderItem(int itemId)
        {
            orderCollection.RemoveAll(l => l.Item.ItemID == itemId);
        }

        public void Clear()
        {
            orderCollection.Clear();
        }

        public decimal ComputeTotalValue()
        {
            return orderCollection.Sum(e => e.Item.Price * e.Quantity);

        }

        
    }
}