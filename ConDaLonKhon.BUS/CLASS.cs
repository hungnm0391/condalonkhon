using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConDaLonKhon.BUS
{
    public class CLASS
    {
        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public bool CheckExist(int id, int schoolId, string className)
        {
            return false;
        }

        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public Nullable<decimal> Insert(VO.CLASS obj)
        {
            return new DAO.CLASS().Insert(obj.CLASS_NAME, obj.SCHOOL_ID, obj.CLASS_TYPE);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public bool Update(VO.CLASS obj)
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
        public bool Delete(VO.CLASS obj)
        {
            return false;
        }

        /// <summary>
        /// Get by key
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public VO.CLASS GetById(int id)
        {
            return null;
        }
    }
}
