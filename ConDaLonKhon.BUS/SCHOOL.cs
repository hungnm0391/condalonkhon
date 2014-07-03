using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace ConDaLonKhon.BUS
{
    public class SCHOOL
    {
        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public int CheckExist(int id, string schoolName)
        {
            return new DAO.SCHOOL().CheckExist(id, schoolName);
        }

        /// <summary>
        /// Check delete
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public int CheckDel(int schoolId)
        {
            return new DAO.SCHOOL().CheckDel(schoolId);
        }

        /// <summary>
        /// Check exist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public int Insert(VO.SCHOOL obj)
        {
            return new DAO.SCHOOL().Insert(obj.SCHOOL_NAME, obj.ADDRESS, obj.TELEPHONE, obj.EMAIL,
                obj.WEBSITE, obj.CITY_ID);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public int Update(VO.SCHOOL obj)
        {
            return new DAO.SCHOOL().Update(obj.ID, obj.SCHOOL_NAME, obj.ADDRESS, obj.TELEPHONE,
                obj.EMAIL, obj.WEBSITE, obj.CITY_ID);
        }

        /// <summary>
        /// Delete school
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          20/06/2014      Add
        /// </modified>
        public int Delete(int id)
        {
            return new DAO.SCHOOL().Delete(id);
        }

        /// <summary>
        /// Get by id
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        public VO.SCHOOL GetById(int id)
        {
            DataTable dt = new DAO.SCHOOL().GetById(id);
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow dr = dt.Rows[0];
                VO.SCHOOL obj = new VO.SCHOOL();

                obj.ID = (int)dr["ID"];
                obj.SCHOOL_NAME = (string)dr["SCHOOL_NAME"];

                if (dr["ADDRESS"] != DBNull.Value)
                    obj.ADDRESS = (string)dr["ADDRESS"];

                if (dr["TELEPHONE"] != DBNull.Value)
                    obj.TELEPHONE = (string)dr["TELEPHONE"];

                if (dr["EMAIL"] != DBNull.Value)
                    obj.EMAIL = (string)dr["EMAIL"];

                if (dr["WEBSITE"] != DBNull.Value)
                    obj.WEBSITE = (string)dr["WEBSITE"];

                obj.CITY_ID = (short)dr["CITY_ID"];

                return obj;
            }
            else
                return null;
        }

        /// <summary>
        /// Search school
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        public DataTable Search(Nullable<short> cityId, string schoolName)
        {
            return new DAO.SCHOOL().Search(cityId, schoolName);
        }

        /// <summary>
        /// Get for dropdownlist
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        public DataTable GetForLI(short? cityId)
        {
            return new DAO.SCHOOL().GetForLI(cityId);
        }
    }
}
