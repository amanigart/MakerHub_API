using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdoToolbox
{
    public class Connection
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

        /*public IEnumerable<T> ExecuteReader<T>(Command cmd, Func<SqlDataReader, T> Convert)
        {
            using(SqlConnection c = CreateConnection())
            {
                using(SqlCommand command = CreateCommand(cmd,c))
                {
                    c.Open();
                    using(SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            yield return Convert(reader);
                        }
                    }
                }
            }
        }*/

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
                        /*var defaultConstructor = type.GetConstructor(Type.EmptyTypes);

                        if (defaultConstructor is null)
                            throw new Exception("Erreur DataReader. Constructeur sans paramètres inexistant.");*/

                        while (reader.Read())
                        {
                            //var genericObject = Activator.CreateInstance(type);
                            T genericObject = new T();

                            foreach (var p in properties)
                                p.SetValue(genericObject, reader[p.Name]);

                            //yield return (T)genericObject;
                            yield return genericObject;
                        }
                    }
                }
            }
        }

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
