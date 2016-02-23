using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Store.Models;

namespace Store
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    //[System.Web.Script.Services.ScriptService]
    public class OrdersDB : System.Web.Services.WebService
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        [WebMethod]
        public static List<Order> GetOrders()
        {
            List<Order> orders = new List<Order>();
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("GetOrders", con);
            cmd.CommandType = CommandType.StoredProcedure;

            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Order currentOrder = new Order()
                {
                    OrderID = (int)reader["OrderID"],
                    PhoneNumber = (string)reader["PhoneNumber"],
                    Address = (string)reader["Address"],
                    Date = (DateTime)reader["OrderDate"],
                    IsConfirmed = (bool)reader["IsConfirmed"]
                };
                orders.Add(currentOrder);
            }
            reader.Close();
            foreach (Order order in orders)
            {
                SqlCommand command = new SqlCommand("GetOrderItems", con);
                command.Parameters.AddWithValue("@orderID", order.OrderID);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader datareader = command.ExecuteReader();
                while (datareader.Read())
                {
                    order.AddItem(new Item()
                    {
                        ItemID = (int)datareader["ItemID"],
                        Name = (string)datareader["Name"],
                        Price = (decimal)datareader["Price"],
                        Description = (string)datareader["Description"],
                        Category = (string)datareader["Category"],
                        Weight = (decimal)datareader["Weight"]
                    }, (int)datareader["Quantity"]);
                }
                datareader.Close();
            }
            return orders;
        }

        [WebMethod]
        public static void UpdateOrder(Order order)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("UpdateOrder", con);
                cmd.Parameters.AddWithValue("@orderID", order.OrderID);
                cmd.Parameters.AddWithValue("@address", order.Address);
                cmd.Parameters.AddWithValue("@phoneNumber", order.PhoneNumber);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public static void ConfirmOrder(int orderID)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("ConfirmOrder", con);
                cmd.Parameters.AddWithValue("@orderID", orderID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public static void DeleteOrder(Order order)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("DeleteOrder", con);
                cmd.Parameters.AddWithValue("@orderId", order.OrderID);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public static void SaveOrder(Order order)
        {
            SqlConnection conn = GetConnection();
            SqlCommand cmd = new SqlCommand("InsertOrder", conn);
            cmd.Parameters.AddWithValue("@address", order.Address);
            cmd.Parameters.AddWithValue("@date", order.Date);
            cmd.Parameters.AddWithValue("@phoneNumber", order.PhoneNumber);
            cmd.Parameters.Add("@orderId", SqlDbType.Int);
            cmd.Parameters["@orderId"].Direction = ParameterDirection.Output;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();

                int orderId = Convert.ToInt32(cmd.Parameters["@orderId"].Value);


                foreach (OrderItem orderItem in order.OrderItems)
                {
                    SqlCommand command = new SqlCommand("InsertOrderItem", conn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@quantity", orderItem.Quantity);
                    command.Parameters.AddWithValue("@itemId", orderItem.Item.ItemID);
                    command.Parameters.AddWithValue("@orderId", orderId);
                    command.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                throw new ApplicationException("Ошибка данных");
            }
            finally
            {
                conn.Close();
            }
            

        }
    }
}
