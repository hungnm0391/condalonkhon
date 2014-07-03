using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Common;

namespace ConDaLonKhon.DAO
{
    public class DataAccess<T> where T : DbConnection, new()
    {
        private DbConnection _connection;

        /// <summary>
        /// Contructor
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          16/06/2014      Add
        /// </modified>
        public DataAccess(string value)
        {
            _connection = new T();
            _connection.ConnectionString = value;
        }

        /// <summary>
        /// Open connection
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          16/06/2014      Add
        /// </modified>
        private void OpenConnection()
        {
            try
            {
                switch (_connection.State)
                {
                    case ConnectionState.Closed:
                        _connection.Open();
                        break;

                    case ConnectionState.Broken:
                        _connection.Close();
                        _connection.Open();
                        break;

                    default:
                        throw new InvalidOperationException("Connection state invalid");
                }
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Execute query and get data
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          16/06/2014      Add
        /// </modified>
        public DataTable GetData(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters = null)
        {
            try
            {
                OpenConnection();
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    if (parameters != null)
                    {
                        Type cmdType = command.GetType();
                        if (cmdType.FullName == "Oracle.ManagedDataAccess.Client.OracleCommand"
                            || cmdType.FullName == "Oracle.DataAccess.Client.OracleCommand")
                            cmdType.GetProperty("BindByName").SetValue(command, true, null);

                        foreach (DbParameter item in parameters)
                            command.Parameters.Add(item);
                    }

                    using (DataTable dt = new DataTable())
                    {
                        using (DbDataReader reader = command.ExecuteReader())
                            dt.Load(reader);

                        if (command.Parameters != null && command.Parameters.Count > 0)
                            command.Parameters.Clear();

                        return dt;
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_connection != null)
                    _connection.Close();
            }
        }

        /// <summary>
        /// Get first column of first row
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public object GetOneValue(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters = null)
        {
            try
            {
                OpenConnection();
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    if (parameters != null)
                    {
                        Type cmdType = command.GetType();
                        if (cmdType.FullName == "Oracle.ManagedDataAccess.Client.OracleCommand"
                            || cmdType.FullName == "Oracle.DataAccess.Client.OracleCommand")
                            cmdType.GetProperty("BindByName").SetValue(command, true, null);

                        foreach (DbParameter item in parameters)
                            command.Parameters.Add(item);
                    }

                    object obj = command.ExecuteScalar();

                    if (command.Parameters != null && command.Parameters.Count > 0)
                        command.Parameters.Clear();

                    return obj;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_connection != null)
                    _connection.Close();
            }
        }

        /// <summary>
        /// Execute query
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          16/06/2014      Add
        /// </modified>
        public int Execute(string commandText, CommandType commandType, IEnumerable<DbParameter> parameters = null)
        {
            try
            {
                OpenConnection();
                using (DbCommand command = _connection.CreateCommand())
                {
                    command.CommandText = commandText;
                    command.CommandType = commandType;

                    if (parameters != null)
                    {
                        Type cmdType = command.GetType();
                        if (cmdType.FullName == "Oracle.ManagedDataAccess.Client.OracleCommand"
                            || cmdType.FullName == "Oracle.DataAccess.Client.OracleCommand")
                            cmdType.GetProperty("BindByName").SetValue(command, true, null);

                        foreach (DbParameter item in parameters)
                            command.Parameters.Add(item);
                    }

                    int rowAffected = command.ExecuteNonQuery();

                    if (command.Parameters != null && command.Parameters.Count > 0)
                        command.Parameters.Clear();

                    return rowAffected;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_connection != null)
                    _connection.Close();
            }
        }
    }
}
