using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConDaLonKhon.VO
{
    public class SCHOOL
    {
        public Int32 ID { get; set; }
        public String SCHOOL_NAME { get; set; }
        public String ADDRESS { get; set; }
        public String TELEPHONE { get; set; }
        public String EMAIL { get; set; }
        public String WEBSITE { get; set; }
        public Int16 CITY_ID { get; set; }
        public CITY CITY { get; set; } // FK
    }
}
