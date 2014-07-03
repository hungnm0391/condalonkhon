using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using ConDaLonKhon.Common;

namespace ConDaLonKhon.BUS
{
    public class CITY
    {
        /// <summary>
        /// Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Insert(VO.CITY obj)
        {
            return new DAO.CITY().Insert(obj.CITY_NAME);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Update(VO.CITY obj)
        {
            return new DAO.CITY().Update(obj.ID, obj.CITY_NAME);
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
            return new DAO.CITY().Delete(id);
        }

        /// <summary>
        /// Check exist object
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int CheckExist(short id, string cityName)
        {
            return new DAO.CITY().CheckExist(id, cityName);
        }

        /// <summary>
        /// Check delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int CheckDel(short cityId)
        {
            return new DAO.CITY().CheckDel(cityId);
        }

        /// <summary>
        /// Get object by key
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public VO.CITY GetById(short id)
        {
            DataTable dt = new DAO.CITY().GetById(id);

            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                VO.CITY obj = new VO.CITY();

                obj.ID = (short)dr["ID"];
                obj.CITY_NAME = (string)dr["CITY_NAME"];

                return obj;
            }
            else
                return null;
        }

        /// <summary>
        /// Search city
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public DataTable Search(string cityName)
        {
            return new DAO.CITY().Search(cityName);
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
            return new DAO.CITY().GetForLI();
        }
    }
}
