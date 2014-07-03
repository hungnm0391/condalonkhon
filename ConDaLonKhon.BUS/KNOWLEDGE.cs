using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConDaLonKhon.BUS
{
    public class KNOWLEDGE
    {
        /// <summary>
        /// Get by key
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public VO.KNOWLEDGE GetById(int id)
        {
            DataTable dt = new DAO.KNOWLEDGE().GetById(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                VO.KNOWLEDGE obj = new VO.KNOWLEDGE();
                obj.ID = (int)dr["ID"];
                obj.KNOWLEDGE_NAME = (string)dr["KNOWLEDGE_NAME"];
                return obj;
            }
            else
                return null;
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public int CheckExist(int id, string knowledgeName)
        {
            return new DAO.KNOWLEDGE().CheckExist(id, knowledgeName);
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public int Insert(VO.KNOWLEDGE obj)
        {
            return new DAO.KNOWLEDGE().Insert(obj.KNOWLEDGE_NAME);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public bool Update(VO.KNOWLEDGE obj)
        {
            return new DAO.KNOWLEDGE().Update(obj.ID, obj.KNOWLEDGE_NAME);
        }

        /// <summary>
        /// Search
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public DataTable Search(string knowledgeName)
        {
            return new DAO.KNOWLEDGE().Search(knowledgeName);
        }

        /// <summary>
        /// Check delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public bool CheckDel(int knowledgeId)
        {
            return false;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public bool Delete(int id)
        {
            return new DAO.KNOWLEDGE().Delete(id);
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
            return new DAO.KNOWLEDGE().GetForLI();
        }
    }
}
