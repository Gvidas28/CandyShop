using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace CandyShop.Model.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        public Employee GetEmployeeByUsername(string username)
        {
            var query = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`
                FROM `employees`
                WHERE `Username` = ?username";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", username);

            connection.Open();

            var result = command.ExecuteReader();
            if (!result.Read())
                return null;

            var employee = new Employee()
            {
                ID = int.Parse(result.GetString(0)),
                Username = result.GetString(1),
                Password = result.GetString(2),
                Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                LastName = !result.IsDBNull(5) ? result.GetString(5) : null,
                StartDate = !result.IsDBNull(6) ? DateTime.Parse(result.GetString(6)) : null,
                Sector = result.GetString(7)
            };

            connection.Close();

            return employee;
        }

        public List<Employee> GetEmployeeList()
        {
            var query = @"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`
                FROM `employees`";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            connection.Open();

            var result = command.ExecuteReader();
            var employees = new List<Employee>();

            while (result.Read())
            {
                employees.Add(new Employee
                {
                    ID = int.Parse(result.GetString(0)),
                    Username = result.GetString(1),
                    Password = result.GetString(2),
                    Email = !result.IsDBNull(3) ? result.GetString(3) : null,
                    Name = !result.IsDBNull(4) ? result.GetString(4) : null,
                    LastName = !result.IsDBNull(5) ? result.GetString(5) : null,
                    StartDate = !result.IsDBNull(6) ? DateTime.Parse(result.GetString(6)) : null,
                    Sector = result.GetString(7)
                });
            }

            connection.Close();

            return employees;
        }

        public void AddEmployee(Employee employee)
        {
            var query = @"
                INSERT INTO `employees` (`Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`)
                VALUES (?username, ?password, ?email, ?name, ?lastName, ?startDate, ?sector)";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?username", employee.Username);
            command.Parameters.AddWithValue("?password", employee.Password);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(employee.Email) ? (object)DBNull.Value : employee.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(employee.Name) ? (object)DBNull.Value : employee.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(employee.LastName) ? (object)DBNull.Value : employee.LastName);
            command.Parameters.AddWithValue("?startDate", employee.StartDate is null ? (object)DBNull.Value : employee.StartDate);
            command.Parameters.AddWithValue("?sector", employee.Sector);

            connection.Open();

            var insert = command.ExecuteNonQuery();
            if (insert < 1)
                throw new Exception("Failed to insert employee!");

            connection.Close();
        }

        public void UpdateEmployee(Employee employee)
        {
            var query = @$"
                UPDATE `employees`
                SET {(!string.IsNullOrWhiteSpace(employee.Password) ? "`Password` = ?password," : string.Empty)} `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `StartDate` = ?startDate, `Sector` = ?sector
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", employee.ID);
            command.Parameters.AddWithValue("?username", employee.Username);
            command.Parameters.AddWithValue("?email", string.IsNullOrWhiteSpace(employee.Email) ? (object)DBNull.Value : employee.Email);
            command.Parameters.AddWithValue("?name", string.IsNullOrWhiteSpace(employee.Name) ? (object)DBNull.Value : employee.Name);
            command.Parameters.AddWithValue("?lastName", string.IsNullOrWhiteSpace(employee.LastName) ? (object)DBNull.Value : employee.LastName);
            command.Parameters.AddWithValue("?startDate", employee.StartDate is null ? (object)DBNull.Value : employee.StartDate);
            command.Parameters.AddWithValue("?sector", employee.Sector);

            if (!string.IsNullOrWhiteSpace(employee.Password))
                command.Parameters.AddWithValue("?password", employee.Password);

            connection.Open();

            var update = command.ExecuteNonQuery();
            if (update < 1)
                throw new Exception("Failed to update employee!");

            connection.Close();
        }

        public void DeleteEmployee(int id)
        {
            var query = @"
                DELETE FROM `employees`
                WHERE `ID` = ?id";

            var connection = new MySqlConnection(Constants.CONNECTION_STRING);
            var command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("?id", id);

            connection.Open();

            var delete = command.ExecuteNonQuery();
            if (delete < 1)
                throw new Exception("Failed to delete employee!");

            connection.Close();
        }
    }
}