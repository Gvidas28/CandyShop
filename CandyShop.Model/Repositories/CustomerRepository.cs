using CandyShop.Model.Entities;
using Microsoft.Extensions.Configuration;
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
        private const int CUSTOMER_LIMIT = 50;

        private readonly ISqlExecutor _sqlExecutor;

        public CustomerRepository(
            ISqlExecutor sqlExecutor
            )
        {
            _sqlExecutor = sqlExecutor;
        }

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

            var reader = _sqlExecutor.GetReader(query, new Dictionary<string, object>());

            var customers = new List<Customer>();

            while (reader.Read() && customers.Count < CUSTOMER_LIMIT)
            {
                customers.Add(new Customer
                {
                    ID = int.Parse(reader.GetString(0)),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2),
                    Email = Nullable(reader, 3),
                    Name = Nullable(reader, 4),
                    LastName = Nullable(reader, 5),
                    DateOfBirth = NullableDate(reader, 6),
                    Address = Nullable(reader, 7),
                    IsTest = NullableBool(reader, 8)
                });
            }

            reader.Close();

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
            var passwordCondition = !string.IsNullOrWhiteSpace(customer.Password) ? "`Password` = ?password," : string.Empty;

            var query = @$"
                UPDATE `customers`
                SET {passwordCondition} `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `DateOfBirth` = ?dateOfBirth, `Address` = ?address, `IsTest` = ?isTest
                WHERE `ID` = ?id";

            var parameters = new Dictionary<string, object> {
                {"?id", customer.ID},
                {"?username", customer.Username },
                {"?email",  GetValue(customer.Email) },
                {"?name",  GetValue(customer.Name) },
                {"?lastName",  GetValue(customer.LastName) },
                {"?dateOfBirth",  GetValue(customer.DateOfBirth) },
                {"?address", GetValue(customer.Address) },
                { "?isTest", GetValue(customer.IsTest) }
            };

            if (!string.IsNullOrWhiteSpace(customer.Password))
                parameters.Add("?password", customer.Password);

            var update = _sqlExecutor.ExecuteNonQuery(query, parameters);
            if (update < 1)
                throw new DatabaseException(DatabaseOperationResult.UpdateUnsuccesful);
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
            bool b => b ? 1 : 0,
            _ => value is null ? (object)DBNull.Value : value
        };

        string? Nullable(ISqlReader reader, int column)
        {
            return !reader.IsDBNull(column) ? reader.GetString(column) : null;
        }

        DateTime? NullableDate(ISqlReader reader, int column)
        {
            return !reader.IsDBNull(column) ? DateTime.Parse(reader.GetString(column)) : null;
        }

        public bool NullableBool(ISqlReader reader, int column)
        {
            return reader.GetString(column) == "1" ? true : false;
        }
    }
}