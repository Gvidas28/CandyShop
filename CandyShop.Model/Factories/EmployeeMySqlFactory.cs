using System;
using CandyShop.Model.Repositories;
using MySqlX.XDevAPI.Relational;

namespace CandyShop.Model.Entities.Factories
{
    public static class EmployeeMySqlFactory
    {
        private static class Columns
        {
            public const int Id = 0;
            public const int Username = 1;
            public const int Password = 2;
            public const int Email = 3;
            public const int Name = 4;
            public const int LastName = 5;
            public const int StartDate = 6;
            public const int Sector = 7;
        };

        public static Employee Create(ISqlReader reader)
        {
            string? Nullable(int column)
            {
                return !reader.IsDBNull(column) ? reader.GetString(column) : null;
            }

            DateTime? NullableDate(int column)
            {
                return !reader.IsDBNull(column) ? DateTime.Parse(reader.GetString(column)) : null;
            }
            return new Employee()
            {
                ID = int.Parse(reader.GetString(Columns.Id)),
                Username = reader.GetString(Columns.Username),
                Password = reader.GetString(Columns.Password),
                Email = Nullable(Columns.Email),
                Name = Nullable(Columns.Name),
                LastName = Nullable(Columns.LastName),
                StartDate = NullableDate(Columns.StartDate),
                Sector = reader.GetString(Columns.Sector)
            };
        }

    }
}
