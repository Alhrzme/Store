using System;
using System.Collections.Generic;
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
    public class ItemsDB : System.Web.Services.WebService
    {
        private static SqlConnection GetConnection()
        {
            string connectionString = WebConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;
            SqlConnection conn = new SqlConnection(connectionString);
            return conn;
        }

        [WebMethod]
        public static List<Item> GetItemsFromDB()
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("GetAllItems", con);
            cmd.CommandType = CommandType.StoredProcedure;

            List<Item> items = new List<Item>();
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                items.Add(new Item()
                {
                    ItemID = (int)reader["ItemID"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"],
                    Description = (string)reader["Description"],
                    Category = (string)reader["Category"],
                    Weight = (decimal)reader["Weight"]
                });
            }
            reader.Close();
            return items;

        }

        public static Item GetItemByID(int id)
        {
            SqlConnection con = GetConnection();
            SqlCommand cmd = new SqlCommand("GetItem", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@id", id);

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Item item = new Item()
                {
                    ItemID = (int)reader["ItemID"],
                    Name = (string)reader["Name"],
                    Price = (decimal)reader["Price"],
                    Description = (string)reader["Description"],
                    Category = (string)reader["Category"],
                    Weight = (decimal)reader["Weight"]
                };
                reader.Close();
                return item;
            }
            catch (SqlException)
            {
                throw new ApplicationException("Ошибка данных");
            }
            finally
            {
                con.Close();
            }
        }

        [WebMethod]
        public static void AddNewItem(Item item)
        {
            using (SqlConnection con = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("AddItem", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", item.Name);
                cmd.Parameters.AddWithValue("price", item.Price);
                cmd.Parameters.AddWithValue("@description", item.Description);
                cmd.Parameters.AddWithValue("@weight", item.Weight);
                cmd.Parameters.AddWithValue("@category", item.Category);
                cmd.Parameters.AddWithValue("@image", item.Image);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }

        [WebMethod]
        public static List<string> GetCategoriesListFromDB()
        {
            using (SqlConnection conn = GetConnection())
            {
                SqlCommand cmd = new SqlCommand("GetCategories", conn);
                List<string> categories = new List<string>();
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    categories.Add((string)reader["Category"]);
                }
                return categories;
            }
        }
    }
}
