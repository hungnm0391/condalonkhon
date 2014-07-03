using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ConDaLonKhon.DAO
{
    public class CLASS : DataAccess<SqlConnection>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CLASS() : base(ConfigurationManager.ConnectionStrings["CDLK"].ConnectionString) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          26/06/2014      Add
        /// </modified>
        public Nullable<decimal> Insert(string className, int schoolId, string classType)
        {
            SqlParameter[] parameters = new SqlParameter[3];

            parameters[0] = new SqlParameter();
            parameters[0].ParameterName = "@CLASS_NAME";
            if (className != null)
                parameters[0].Value = className;
            else
                parameters[0].Value = DBNull.Value;

            parameters[1] = new SqlParameter();
            parameters[1].ParameterName = "@SCHOOL_ID";
            parameters[1].SqlDbType = SqlDbType.Int;
            parameters[1].Value = schoolId;

            parameters[2] = new SqlParameter();
            parameters[2].ParameterName = "@CLASS_TYPE";
            parameters[2].Value = classType;

            object obj = GetOneValue("CLASS_INSERT", CommandType.StoredProcedure, parameters);

            if (obj == DBNull.Value || obj == null)
                return null;
            else
                return (decimal)obj;
        }
    }
}
