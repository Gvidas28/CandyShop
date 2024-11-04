using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public Comment GetCommentById(int id)
        {
            var query = @$"
                SELECT i.ID, i.CustomerId, i.ItemId, i.Text, c.Username, i.CommentId
                FROM comments as i
                LEFT JOIN customers as c ON c.Id = i.CustomerId
                WHERE i.ID = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var result = command.ExecuteReader();
            if (!result.Read())
                return null;

            var comment = new Comment
            {
                ID = int.Parse(result.GetString(0)),
                CustomerId = int.Parse(result.GetString(1)),
                ItemId = int.Parse(result.GetString(2)),
                Text = result.GetString(3),
                CustomerName = result.GetString(4),
                CommentId = !result.IsDBNull(5) ? int.Parse(result.GetString(5)) : null,
            };

            connection.Close();

            return comment;
        }

        public List<Comment> GetCommentsByItemId(int itemId)
        {
            var query = @"
                SELECT i.ID, i.CustomerId, i.ItemId, i.Text, c.Username, i.CommentId
                FROM comments as i
                LEFT JOIN customers as c ON c.Id = i.CustomerId
                WHERE i.ItemId = ?itemId";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?itemId", itemId);

            connection.Open();

            var result = command.ExecuteReader();
            var comments = new List<Comment>();

            while (result.Read())
            {
                comments.Add(new Comment
                {
                    ID = int.Parse(result.GetString(0)),
                    CustomerId = int.Parse(result.GetString(1)),
                    ItemId = int.Parse(result.GetString(2)),
                    Text = result.GetString(3),
                    CustomerName = result.GetString(4),
                    CommentId = !result.IsDBNull(5) ? int.Parse(result.GetString(5)) : null,
                });
            }

            connection.Close();

            return comments;
        }

        public bool AddComment(Comment comment)
        {
            var query = @"
            INSERT INTO comments (CustomerId, ItemId, Text, CommentId) 
            VALUES (?customerId, ?itemId, ?text, ?commentId)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?customerId", comment.CustomerId);
            command.Parameters.AddWithValue("?itemId", comment.ItemId);
            command.Parameters.AddWithValue("?text", comment.Text);
            command.Parameters.AddWithValue("?commentId", comment.CommentId);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert item!");

            connection.Close();
            return true;
        }

        public bool UpdateComment(Comment comment)
        {
            var query = @"
                UPDATE `comments`
                SET `CustomerId` = ?customerId, `ItemId` = ?itemId, `Text` = ?text
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", comment.ID);
            command.Parameters.AddWithValue("?customerId", comment.CustomerId);
            command.Parameters.AddWithValue("?itemId", comment.ItemId);
            command.Parameters.AddWithValue("?text", comment.Text);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update item!");

            connection.Close();
            return true;
        }

        public bool DeleteComment(int id)
        {
            var query = @"
                DELETE FROM `comments`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete item!");

            connection.Close();
            return true;
        }
    }
}