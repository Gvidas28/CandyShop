using CandyShop.Model.Entities;
using CandyShop.Model.Entities.Enums;
using CandyShop.Model.Services;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        public Admin GetAdminByUsername(string username)
        {
            var query = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`
                FROM `admins`
                WHERE `Username` = ?username";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", username);

            connection.Open();

            var result = command.ExecuteReader();
            if (!result.Read())
                return null;

            var admin = new Admin()
            {
                ID = int.Parse(result.GetString(0)),
                Username = result.GetString(1),
                Password = result.GetString(2),
                Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                LastName = !result.IsDBNull(5) ? result.GetString(5) : null
            };

            connection.Close();

            return admin;
        }

        public List<Admin> GetAdminList()
        {
            var query = @"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`
                FROM `admins`";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();
            var admins = new List<Admin>();

            while (result.Read())
            {
                admins.Add(new Admin
                {
                    ID = int.Parse(result.GetString(0)),
                    Username = result.GetString(1),
                    Password = result.GetString(2),
                    Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                    Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                    LastName = !result.IsDBNull(5) ? result.GetString(5) : null
                });
            }

            connection.Close();

            return admins;
        }

        public void AddAdmin(Admin admin)
        {
            var query = @"
                INSERT INTO `admins` (`Username`, `Password`, `Email`, `Name`, `LastName`)
                VALUES (?username, ?password, ?email, ?name, ?lastName)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", admin.Username);
            command.Parameters.AddWithValue("?password", admin.Password);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(admin.Email) ? (object)DBNull.Value : admin.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(admin.Name) ? (object)DBNull.Value : admin.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(admin.LastName) ? (object)DBNull.Value : admin.LastName);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert admin!");

            connection.Close();
        }

        public void UpdateAdmin(Admin admin)
        {
            var query = @$"
                UPDATE `admins`
                SET {(!string.IsNullOrWhiteSpace(admin.Password) ? "`Password` = ?password," : string.Empty)} `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", admin.ID);
            command.Parameters.AddWithValue("?username", admin.Username);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(admin.Email) ? (object)DBNull.Value : admin.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(admin.Name) ? (object)DBNull.Value : admin.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(admin.LastName) ? (object)DBNull.Value : admin.LastName);

            if (!string.IsNullOrWhiteSpace(admin.Password))
                command.Parameters.AddWithValue("?password", admin.Password);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update admin!");

            connection.Close();
        }

        public void DeleteAdmin(int id)
        {
            var query = @"
                DELETE FROM `admins`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete admin!");

            connection.Close();
        }
    }
}