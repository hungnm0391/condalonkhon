using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConDaLonKhon.DAO
{
    public class KNOWLEDGE : DataAccess<SqlConnection>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public KNOWLEDGE() : base(ConfigurationManager.ConnectionStrings["CDLK"].ConnectionString) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Insert(string knowledgeName)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@KNOWLEDGE_NAME";
            if (knowledgeName != null)
                parameters[0].Value = knowledgeName;
            else
                parameters[0].Value = DBNull.Value;

            return Execute("KNOWLEDGE_INSERT", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public bool Update(int id, string knowledgeName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@KNOWLEDGE_NAME";
            if (knowledgeName != null)
                parameters[1].Value = knowledgeName;
            else
                parameters[1].Value = DBNull.Value;

            return Execute("KNOWLEDGE_UPDATE", CommandType.StoredProcedure, parameters) > 0;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public bool Delete(int id)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;

            return Execute("KNOWLEDGE_DELETE", CommandType.StoredProcedure, parameters) > 0;
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int CheckExist(int id, string knowledgeName)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@KNOWLEDGE_NAME";
            if (knowledgeName != null)
                parameters[1].Value = knowledgeName;
            else
                parameters[1].Value = DBNull.Value;

            return (int)GetOneValue("KNOWLEDGE_CHECKEXIST", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public DataTable GetById(int id)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@ID";
            parameters[0].SqlDbType = SqlDbType.Int;
            parameters[0].Value = id;

            return GetData("KNOWLEDGE_GETBYID", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Search KNOWLEDGE
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public DataTable Search(string knowledgeName)
        {
            SqlParameter[] parameters = { new SqlParameter() };
            parameters[0].ParameterName = "@KNOWLEDGE_NAME";
            if (knowledgeName != null)
                parameters[0].Value = knowledgeName;
            else
                parameters[0].Value = DBNull.Value;

            return GetData("KNOWLEDGE_SEARCH", CommandType.StoredProcedure, parameters);
        }

        /// <summary>
        /// Get for listitem
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public DataTable GetForLI()
        {
            return GetData("KNOWLEDGE_GETFORLI", CommandType.Text);
        }
    }
}
