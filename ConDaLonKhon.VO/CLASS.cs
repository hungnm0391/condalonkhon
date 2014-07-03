using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConDaLonKhon.VO
{
    public class CLASS
    {
        public Int32 ID { get; set; }
        public String CLASS_NAME { get; set; }
        public Int32 SCHOOL_ID { get; set; }
        public String CLASS_TYPE { get; set; }
        public SCHOOL SCHOOL { get; set; }
    }
}
