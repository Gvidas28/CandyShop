using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;

namespace CandyShop.Model.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public Item GetItemById(int id)
        {
            var query = @$"
                SELECT `ID`, `Name`, `Description`, `Price`, `Quantity`, `Image`
                FROM `items`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var result = command.ExecuteReader();
            if (!result.Read())
                return null;

            var item = new Item
            {
                ID = int.Parse(result.GetString(0)),
                Name = result.GetString(1),
                Description = result.GetString(2),
                Price = decimal.Parse(result.GetString(3)),
                Quantity = Int32.Parse(result.GetString(4)),
                Image = result.GetString(5),
            };

            connection.Close();

            return item;
        }

        public List<Item> GetItemList()
        {
            var query = @"
                SELECT `ID`, `Name`, `Description`, `Price`, `Quantity`, `Image`
                FROM `items`";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();
            var items = new List<Item>();

            while (result.Read())
            {
                items.Add(new Item
                {
                    ID = int.Parse(result.GetString(0)),
                    Name = result.GetString(1),
                    Description = result.GetString(2),
                    Price = decimal.Parse(result.GetString(3)),
                    Quantity = Int32.Parse(result.GetString(4)),
                    Image = result.GetString(5),
                });
            }

            connection.Close();

            return items;
        }

        public void AddItem(Item item)
        {
            var query = @"
                INSERT INTO `items` (`Name`, `Description`, `Price`, `Quantity`, `Image`)
                VALUES (?name, ?description, ?price, ?quantity, ?image)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?name", item.Name);
            command.Parameters.AddWithValue("?description", item.Description);
            command.Parameters.AddWithValue("?price", item.Price);
            command.Parameters.AddWithValue("?quantity", item.Quantity);
            command.Parameters.AddWithValue("?image", item.Image);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert item!");

            connection.Close();
        }

        public void UpdateItem(Item item)
        {
            var query = @"
                UPDATE `items`
                SET `Name` = ?name, `Description` = ?description, `Price` = ?price, `Quantity` = ?quantity, `Image` = ?image
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", item.ID);
            command.Parameters.AddWithValue("?name", item.Name);
            command.Parameters.AddWithValue("?description", item.Description);
            command.Parameters.AddWithValue("?price", item.Price);
            command.Parameters.AddWithValue("?quantity", item.Quantity);
            command.Parameters.AddWithValue("?image", item.Image);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update item!");

            connection.Close();
        }

        public void DeleteItem(int id)
        {
            var query = @"
                DELETE FROM `items`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete item!");

            connection.Close();
        }
    }
}