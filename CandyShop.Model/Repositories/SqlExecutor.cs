
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using MySql.Data.MySqlClient;

namespace CandyShop.Model.Repositories
{
    public interface ISqlReader
    {
        public bool Read();

        public string GetString(int column);

        public bool IsDBNull(int column);

        public void Close();
    }

    public class MySqlReader(MySqlDataReader mySqlDataReader) : ISqlReader
    {
        public bool Read()
        {
            return mySqlDataReader.Read();
        }

        public string GetString(int column)
        {
            return mySqlDataReader.GetString(column);
        }

        public bool IsDBNull(int column)
        {
            return mySqlDataReader.IsDBNull(column);
        }

        public void Close()
        {
            mySqlDataReader.Close();
        }
    }

    public interface ISqlExecutor
    {
        public ISqlReader GetReader(String query, Dictionary<String, Object> parameters);

        public int ExecuteNonQuery(String query, Dictionary<String, Object> parameters);
    }

    public class MySqlExecutor(MySqlConnection mySqlConnection) : ISqlExecutor
    {
        public ISqlReader GetReader(String query, Dictionary<String, Object> parameters)
        {
            var command = new MySqlCommand(query, mySqlConnection);

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            mySqlConnection.Open();
            var reader = command.ExecuteReader(CommandBehavior.CloseConnection);

            return new MySqlReader(reader);
        }

        public int ExecuteNonQuery(String query, Dictionary<String, Object> parameters)
        {
            var command = new MySqlCommand(query, mySqlConnection);

            foreach (var param in parameters)
            {
                command.Parameters.AddWithValue(param.Key, param.Value);
            }

            mySqlConnection.Open();
            var result = command.ExecuteNonQuery();
            mySqlConnection.Close();

            return result;
        }

    }
}