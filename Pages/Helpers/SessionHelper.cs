using System;
using System.Web.SessionState;
using Store.Models;

namespace Store.Pages.Helpers
{
    public enum SessionKey
    {
        CART
    }

    public static class SessionHelper
    {

        public static void Set(HttpSessionState session, SessionKey key, object value)
        {
            session[Enum.GetName(typeof(SessionKey), key)] = value;
        }

        public static T Get<T>(HttpSessionState session, SessionKey key)
        {
            object dataValue = session[Enum.GetName(typeof(SessionKey), key)];
            if (dataValue != null && dataValue is T)
            {
                return (T)dataValue;
            }
            else
            {
                return default(T);
            }
        }

        public static Order GetOrder(HttpSessionState session)
        {
            Order myOrder = Get<Order>(session, SessionKey.CART);
            if (myOrder == null)
            {
                myOrder = new Order();
                Set(session, SessionKey.CART, myOrder);
            }
            return myOrder;
        }
    }
}