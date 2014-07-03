using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ConDaLonKhon.Common;

namespace ConDaLonKhon.DAO
{
    public class CITY : DataAccess<SqlConnection>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public CITY()
            : base(ConfigurationManager.ConnectionStrings["CDLK"].ConnectionString) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Insert(string cityName)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@CITY_NAME";
            if (cityName != null)
                parameters[0].Value = cityName;
            else
                parameters[0].Value = DBNull.Value;

            return Execute("CITY_INSERT", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Update(short id, string cityName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.SmallInt;
            parameters[0].Value = id;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@CITY_NAME";
            if (cityName != null)
                parameters[1].Value = cityName;
            else
                parameters[1].Value = DBNull.Value;

            return Execute("CITY_UPDATE", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Delete(short id)
        {
            SqlParameter[] paramaters = { new SqlParameter() };
            paramaters[0].ParameterName = "@ID";
            paramaters[0].SqlDbType = SqlDbType.SmallInt;
            paramaters[0].Value = id;

            return Execute("CITY_DELETE", CommandType.StoredProcedure, paramaters);
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int CheckExist(short id, string cityName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.SmallInt;
            parameters[0].Value = id;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@CITY_NAME";
            if (cityName != null)
                parameters[1].Value = cityName;
            else
                parameters[1].Value = DBNull.Value;

            return (int)GetOneValue("CITY_CHECKEXIST", CommandType.StoredProcedure, parameters);
        }

        /// Check delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public int CheckDel(short cityId)
        {
            SqlParameter[] parameters = { new SqlParameter() };

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@CITY_ID";
            parameters[0].SqlDbType = SqlDbType.SmallInt;
            parameters[0].Value = cityId;

            return (int)GetOneValue("CITY_CHECKDEL", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Get object by key
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public DataTable GetById(short id)
        {
            SqlParameter[] paramaters = { new SqlParameter() };
            paramaters[0].ParameterName = "@ID";
            paramaters[0].SqlDbType = SqlDbType.SmallInt;
            paramaters[0].Value = id;

            return GetData("CITY_GETBYID", CommandType.StoredProcedure, paramaters);
        }

        /// <summary>
        /// Search CITY
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public DataTable Search(string cityName)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@CITY_NAME";
            if (cityName != null)
                parameters[0].Value = cityName;
            else
                parameters[0].Value = DBNull.Value;

            return GetData("CITY_SEARCH", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Get for dropdownlist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          02/07/2014      Add
        /// </modified>
        public DataTable GetForLI()
        {
            return GetData("CITY_GETFORLI", CommandType.Text);
        }
    }
}
