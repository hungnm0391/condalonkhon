using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace ConDaLonKhon.DAO
{
    public class CLASS_KNOWLEDGE : DataAccess<SqlConnection>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CLASS_KNOWLEDGE() : base(ConfigurationManager.ConnectionStrings["CDLK"].ConnectionString) { }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          26/06/2014      Add
        /// </modified>
        public bool Insert(int classId, int knowledgeId)
        {
            SqlParameter[] parameters = new SqlParameter[2];

            parameters[0] = new SqlParameter("@CLASS_ID", SqlDbType.Int);
            parameters[0].Value = classId;

            parameters[1] = new SqlParameter("@KNOWLEDGE_ID", SqlDbType.Int);
            parameters[1].Value = knowledgeId;

            return Execute("CLASS_KNOWLEDGE_INSERT", CommandType.StoredProcedure, parameters) > 0;
        }
    }
}
