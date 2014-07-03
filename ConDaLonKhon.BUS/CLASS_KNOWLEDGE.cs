using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConDaLonKhon.BUS
{
    public class CLASS_KNOWLEDGE
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          26/06/2014      Add
        /// </modified>
        public bool Insert(VO.CLASS_KNOWLEDGE obj)
        {
            return new DAO.CLASS_KNOWLEDGE().Insert(obj.CLASS_ID, obj.KNOWLEDGE_ID);
        }
    }
}
