using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Model.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrderList()
        {
            var query = @"
                SELECT `ID`, `CustomerId`, `ItemId`, `Status`, `Price`, `OrderDate`
                FROM `orders`";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();
            var orders = new List<Order>();

            while (result.Read())
            {
                orders.Add(new Order
                {
                    ID = int.Parse(result.GetString(0)),
                    CustomerId = int.Parse(result.GetString(1)),
                    ItemId = int.Parse(result.GetString(2)),
                    Status = result.GetString(3),
                    Price = decimal.Parse(result.GetString(4)),
                    OrderDate = DateTime.Parse(result.GetString(5))
                });
            }

            connection.Close();

            return orders;
        }

        public void AddOrder(Order order)
        {
            var query = @"
                INSERT INTO `orders` (`CustomerId`, `ItemId`, `Status`, `Price`, `OrderDate`)
                VALUES (?customerId, ?itemId, ?status, ?price, ?orderDate)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?customerId", order.CustomerId);
            command.Parameters.AddWithValue("?itemId", order.ItemId);
            command.Parameters.AddWithValue("?status", order.Status);
            command.Parameters.AddWithValue("?price", order.Price);
            command.Parameters.AddWithValue("?orderDate", order.OrderDate);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert order!");

            connection.Close();
        }

        public void UpdateOrder(Order order)
        {
            var query = @"
                UPDATE `orders`
                SET `CustomerId` = ?customerId, `ItemId` = ?itemId, `Status` = ?status, `Price` = ?price, `OrderDate` = ?orderDate
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", order.ID);
            command.Parameters.AddWithValue("?customerId", order.CustomerId);
            command.Parameters.AddWithValue("?itemId", order.ItemId);
            command.Parameters.AddWithValue("?status", order.Status);
            command.Parameters.AddWithValue("?price", order.Price);
            command.Parameters.AddWithValue("?orderDate", order.OrderDate);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update order!");

            connection.Close();
        }

        public void DeleteOrder(int id)
        {
            var query = @"
                DELETE FROM `orders`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete order!");

            connection.Close();
        }
    }
}