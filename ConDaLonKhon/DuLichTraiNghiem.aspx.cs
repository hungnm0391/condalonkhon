using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConDaLonKhon
{
    public partial class DuLichTraiNghiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Page.Title = "Du lịch trải nghiệm";
        }
    }
}