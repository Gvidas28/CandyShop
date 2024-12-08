﻿using CandyShop.Model.Entities;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CandyShop.Model.Repositories
{
    public class EmployeeRepository(ISqlExecutor mySql) : IEmployeeRepository
    {
        public Employee GetEmployeeByUsername(string username)
        {
            var query = @$"
                SELECT `ID`, `Username`, `Password`, `Email`, `Name`, `LastName`, `StartDate`, `Sector`
                FROM `employees`
                WHERE `Username` = ?username";

            var reader = mySql.GetReader(query, new Dictionary<string, object> { { "?username", username } });
            if (!reader.Read())
                return null;

            //employee construction from dbResult could be extracted all together
            //single responsibility, modular, easier to test, decouple
            var employee = new Employee()
            {
                //magic numbers: should use constants, or enum, like Employee.idColumn
                ID = int.Parse(reader.GetString(0)),
                Username = reader.GetString(1),
                Password = reader.GetString(2),
                //checking null could be extracted, DRY
                Email = !reader.IsDBNull(3) ? reader.GetString(3) : null,
                Name = !reader.IsDBNull(4) ? reader.GetString(4) : null,
                LastName = !reader.IsDBNull(5) ? reader.GetString(5) : null,
                StartDate = !reader.IsDBNull(6) ? DateTime.Parse(reader.GetString(6)) : null,
                Sector = reader.GetString(7)
            };

            //shouldn't we try catch finally to ensure connection is closed?
            reader.Close();

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
            //should extract string interpolation result to variable, improves code readability, cognitive complexity
            var query = @$"
                UPDATE `employees`
                SET {(!string.IsNullOrWhiteSpace(employee.Password) ? "`Password` = ?password," : string.Empty)} `Username` = ?username, `Email` = ?email, `Name` = ?name, `LastName` = ?lastName, `StartDate` = ?startDate, `Sector` = ?sector
                WHERE `ID` = ?id";

            //again DRY
            var parameters = new Dictionary<string, object> {
                {"?id", employee.ID},
                {"?username", employee.Username},
                {"?email", string.IsNullOrWhiteSpace(employee.Email) ? (object)DBNull.Value : employee.Email},
                {"?name", string.IsNullOrWhiteSpace(employee.Name) ? (object)DBNull.Value : employee.Name},
                {"?lastName", string.IsNullOrWhiteSpace(employee.LastName) ? (object)DBNull.Value : employee.LastName},
                {"?startDate", employee.StartDate is null ? (object)DBNull.Value : employee.StartDate},
                {"?sector", employee.Sector},
            };

            if (!string.IsNullOrWhiteSpace(employee.Password))
                parameters.Add("?password", employee.Password);

            var result = mySql.ExecuteNonQuery(query, parameters);

            if (result < 1)
                throw new Exception("Failed to update employee!");
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