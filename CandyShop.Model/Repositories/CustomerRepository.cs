using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyShop.Model.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetCustomerByUsername(string username)
        {
            var query = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `DateOfBirth`, `Address`, `IsTest`
                FROM `customers`
                WHERE `Username` = ?username";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", username);

            connection.Open();

            var result = command.ExecuteReader();
            if (!result.Read())
                return null;

            var customer = new Customer()
            {
                ID = int.Parse(result.GetString(0)),
                Username = result.GetString(1),
                Password = result.GetString(2),
                Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                LastName = !result.IsDBNull(5) ? result.GetString(5) : null,
                DateOfBirth = !result.IsDBNull(6) ? DateTime.Parse(result.GetString(6)) : null,
                Address = !result.IsDBNull(7) ? result.GetString(7) : null,
                IsTest = result.GetString(8) == "1" ? true : false
            };

            connection.Close();

            return customer;
        }

        public List<Customer> GetCustomerList()
        {
            var query = @"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `DateOfBirth`, `Address`, `IsTest`
                FROM `customers`";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();
            var customers = new List<Customer>();

            while (result.Read())
            {
                customers.Add(new Customer
                {
                    ID = int.Parse(result.GetString(0)),
                    Username = result.GetString(1),
                    Password = result.GetString(2),
                    Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                    Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                    LastName = !result.IsDBNull(5) ? result.GetString(5) : null,
                    DateOfBirth = !result.IsDBNull(6) ? DateTime.Parse(result.GetString(6)) : null,
                    Address = !result.IsDBNull(7) ? result.GetString(7) : null,
                    IsTest = result.GetString(8) == "1" ? true : false
                });
            }

            connection.Close();

            return customers;
        }

        public void AddCustomer(Customer customer)
        {
            var query = @"
                INSERT INTO `customers` (`Username`, `Password`, `Email`, `Name`, `LastName`, `DateOfBirth`, `Address`, `IsTest`)
                VALUES (?username, ?password, ?email, ?name, ?lastName, ?dateOfBirth, ?address, ?isTest)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", customer.Username);
            command.Parameters.AddWithValue("?password", customer.Password);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(customer.Email) ? (object)DBNull.Value : customer.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(customer.Name) ? (object)DBNull.Value : customer.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(customer.LastName) ? (object)DBNull.Value : customer.LastName);
            command.Parameters.AddWithValue("?dateOfBirth", customer.DateOfBirth is null ? (object)DBNull.Value : customer.DateOfBirth);
            command.Parameters.AddWithValue("?address", string.IsNullOrWhiteSpace(customer.Address) ? (object)DBNull.Value : customer.Address);
            command.Parameters.AddWithValue("?isTest", customer.IsTest ? 1 : 0);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert customer!");

            connection.Close();
        }

        public void UpdateCustomer(Customer customer)
        {
            var query = @$"
                UPDATE `customers`
                SET {(!string.IsNullOrWhiteSpace(customer.Password) ? "`Password` = ?password," : string.Empty)} `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `DateOfBirth` = ?dateOfBirth, `Address` = ?address, `IsTest` = ?isTest
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", customer.ID);
            command.Parameters.AddWithValue("?username", customer.Username);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(customer.Email) ? (object)DBNull.Value : customer.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(customer.Name) ? (object)DBNull.Value : customer.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(customer.LastName) ? (object)DBNull.Value : customer.LastName);
            command.Parameters.AddWithValue("?dateOfBirth", customer.DateOfBirth is null ? (object)DBNull.Value : customer.DateOfBirth);
            command.Parameters.AddWithValue("?address", string.IsNullOrWhiteSpace(customer.Address) ? (object)DBNull.Value : customer.Address);
            command.Parameters.AddWithValue("?isTest", customer.IsTest ? 1 : 0);

            if (!string.IsNullOrWhiteSpace(customer.Password))
                command.Parameters.AddWithValue("?password", customer.Password);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update customer!");

            connection.Close();
        }

        public void DeleteCustomer(int id)
        {
            var query = @"
                DELETE FROM `customers`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete customer!");

            connection.Close();
        }

        private object GetValue(object value) => value switch
        {
            string str => string.IsNullOrWhiteSpace(str) ? (object)DBNull.Value : value,
            _ => value is null ? (object)DBNull.Value : value
        };
    }
}