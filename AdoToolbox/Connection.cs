using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdoToolbox
{
    public sealed class Connection
    {
        private string _connectionString;

        public Connection(string connectionString)
        {
            if(string.IsNullOrWhiteSpace(connectionString)) throw new ArgumentNullException(nameof(connectionString));
            _connectionString = connectionString;
        }

        private SqlConnection CreateConnection()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            return connection;
        }

        private SqlCommand CreateCommand(Command command, SqlConnection c)
        {
            SqlCommand cmd = c.CreateCommand();

            cmd.CommandText = command.Query;
            cmd.CommandType = (command.IsStoredProcedure) ? CommandType.StoredProcedure : CommandType.Text;

            foreach (KeyValuePair<string, object> item in command.Parameters)
            {
                SqlParameter parameter = new SqlParameter
                {
                    ParameterName = item.Key,
                    Value = (item.Value is null) ? DBNull.Value : item.Value
                };

                cmd.Parameters.Add(parameter);
            }

            return cmd;
        }

        public int ExecuteNonQuery(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd, c))
                {
                    c.Open();
                    int result = command.ExecuteNonQuery();
                    c.Close();
                    return result;
                }
            }
        }

        public object ExecuteScalar(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, c))
                {
                    c.Open();
                    object result = command.ExecuteScalar();
                    c.Close();
                    return (result is DBNull) ? null : result;
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(Command cmd) where T : new()
        {
            using (SqlConnection connection = CreateConnection())
            {
                using (SqlCommand command = CreateCommand(cmd, connection))
                {
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Type type = typeof(T);
                        var properties = type.GetProperties();

                        while (reader.Read())
                        {
                            T genericObject = (T)Activator.CreateInstance(type);

                            foreach (var p in properties)
                            {
                                var fieldValue = reader[p.Name];

                                if (fieldValue is DBNull)
                                    fieldValue = null;

                                p.SetValue(genericObject, fieldValue);
                            }

                            yield return genericObject;
                        }
                    }
                }
            }
        }

        //public async IAsyncEnumerable<T> ExecuteReaderAsync<T>(Command cmd) where T : new()
        //{
        //    using (SqlConnection connection = CreateConnection())
        //    {
        //        using (SqlCommand command = CreateCommand(cmd, connection))
        //        {
        //            await connection.OpenAsync();

        //            using (SqlDataReader reader = await command.ExecuteReaderAsync())
        //            {
        //                Type type = typeof(T);
        //                var properties = type.GetProperties();

        //                while (await reader.ReadAsync())
        //                {
        //                    T genericObject = (T)Activator.CreateInstance(type);

        //                    foreach (var p in properties)
        //                    {
        //                        var fieldValue = reader[p.Name];

        //                        if (fieldValue is DBNull)  //== DBNull.Value)
        //                            fieldValue = null;

        //                        p.SetValue(genericObject, fieldValue);
        //                    }

        //                    yield return genericObject;
        //                }
        //            }
        //        }
        //    }
        //}

        public DataTable GetDataTable(Command cmd)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd, c))
                {
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = command;
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    return dt;
                }
            }
        }
    }
}
