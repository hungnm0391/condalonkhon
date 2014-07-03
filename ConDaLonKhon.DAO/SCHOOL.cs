using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConDaLonKhon.DAO
{
    public class SCHOOL : DataAccess<SqlConnection>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public SCHOOL() : base(ConfigurationManager.ConnectionStrings["CDLK"].ConnectionString) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HuyDH           14/06/2014      Add
        /// </modified>
        public int Insert(string schoolName, string address, string telephone, string email, string website, short cityId)
        {
            SqlParameter[] parameters = new SqlParameter[6];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@SCHOOL_NAME";
            if (schoolName != null)
                parameters[0].Value = schoolName;
            else
                parameters[0].Value = DBNull.Value;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@ADDRESS";
            if (address != null)
                parameters[1].Value = address;
            else
                parameters[1].Value = DBNull.Value;

            parameters[2] = new SqlParameter();
            parameters[2].ParameterName = "@TELEPHONE";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (telephone != null)
                parameters[2].Value = telephone;
            else
                parameters[2].Value = DBNull.Value;

            parameters[3] = new SqlParameter();
            parameters[3].ParameterName = "@EMAIL";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (email != null)
                parameters[3].Value = email;
            else
                parameters[3].Value = DBNull.Value;

            parameters[4] = new SqlParameter();
            parameters[4].ParameterName = "@WEBSITE";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (website != null)
                parameters[4].Value = website;
            else
                parameters[4].Value = DBNull.Value;

            parameters[5] = new SqlParameter();
            parameters[5].ParameterName = "@CITY_ID";
            parameters[5].SqlDbType = SqlDbType.SmallInt;
            parameters[5].Value = cityId;

            return Execute("SCHOOL_INSERT", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HuyDH           14/06/2014      Add
        /// </modified>
        public int Update(int id, string schoolName, string address, string telephone, string email, string website, short cityId)
        {
            SqlParameter[] parameters = new SqlParameter[7];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@SCHOOL_NAME";
            if (schoolName != null)
                parameters[0].Value = schoolName;
            else
                parameters[0].Value = DBNull.Value;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@ADDRESS";
            if (address != null)
                parameters[1].Value = address;
            else
                parameters[1].Value = DBNull.Value;

            parameters[2] = new SqlParameter();
            parameters[2].ParameterName = "@TELEPHONE";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (telephone != null)
                parameters[2].Value = telephone;
            else
                parameters[2].Value = DBNull.Value;

            parameters[3] = new SqlParameter();
            parameters[3].ParameterName = "@EMAIL";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (email != null)
                parameters[3].Value = email;
            else
                parameters[3].Value = DBNull.Value;

            parameters[4] = new SqlParameter();
            parameters[4].ParameterName = "@WEBSITE";
            parameters[2].SqlDbType = SqlDbType.VarChar;
            if (website != null)
                parameters[4].Value = website;
            else
                parameters[4].Value = DBNull.Value;

            parameters[5] = new SqlParameter();
            parameters[5].ParameterName = "@CITY_ID";
            parameters[5].SqlDbType = SqlDbType.SmallInt;
            parameters[5].Value = cityId;

            parameters[6] = new SqlParameter();
            parameters[6].ParameterName = "@ID";
            parameters[6].SqlDbType = SqlDbType.Int;
            parameters[6].Value = id;

            return Execute("SCHOOL_UPDATE", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HuyDH           14/06/2014      Add
        /// </modified>
        public int Delete(int id)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;
            return Execute("SCHOOL_DELETE", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HuyDH           14/06/2014      Add
        /// </modified>
        public int CheckExist(int id, string schoolName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@SCHOOL_NAME";
            if (schoolName != null)
                parameters[1].Value = schoolName;
            else
                parameters[1].Value = DBNull.Value;

            return (int)GetOneValue("SCHOOL_CHECKEXIST", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Check delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public int CheckDel(int schoolId)
        {
            SqlParameter[] parameters = { new SqlParameter() };

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = schoolId;

            return (int)GetOneValue("SCHOOL_CHECKDEL", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HuyDH           14/06/2014      Add
        /// </modified>
        public DataTable Search(Nullable<short> cityId, string schoolName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@CITY_ID";
            parameters[0].SqlDbType = SqlDbType.SmallInt;
            if (cityId.HasValue)
                parameters[0].Value = cityId;
            else
                parameters[0].Value = DBNull.Value;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@SCHOOL_NAME";
            if (schoolName != null)
                parameters[1].Value = schoolName;
            else
                parameters[1].Value = DBNull.Value;

            return GetData("SCHOOL_SEARCH", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public DataTable GetById(int id)
        {
            SqlParameter[] parameter = { new SqlParameter() };
            parameter[0].ParameterName = "@ID";
            parameter[0].SqlDbType = SqlDbType.Int;
            parameter[0].Value = id;

            return GetData("SCHOOL_GETBYID", CommandType.StoredProcedure, parameter);
        }

        /// <summary>
        /// Get for dropdownlist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public DataTable GetForLI(short? cityId)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@CITY_ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            if (cityId.HasValue)
                parameters[0].Value = cityId.Value;
            else
                parameters[0].Value = DBNull.Value;

            return GetData("SCHOOL_GETFORLI", CommandType.StoredProcedure, parameters);
        }
    }
}