using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.IO;

namespace ConDaLonKhon
{
    public class WebBase : Page
    {
        /// <summary>
        /// Run javascript
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          01/07/2014      Add
        /// </modified>
        protected void RunJavascript(string script, string key = "JS")
        {
            ClientScript.RegisterClientScriptBlock(GetType(), key, script, true);
        }

        /// <summary>
        /// Handled error
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          02/07/2014      Add
        /// </modified>
        private void Page_Error(object sender, EventArgs e)
        {
            Common.Common.WriteException(Server.GetLastError());
            Server.ClearError();

            Response.Clear();
            Response.ContentType = "text/html; charset=utf-8";
            Response.Write("<html><header><title>Trang thông báo lỗi</title></header><body>Có lỗi xảy ra với hệ thống. Vui lòng liên hệ quản trị website!</body></html>");
            Response.End();
        }

        protected void ShowMessage(string msg)
        {
            ClientScript.RegisterClientScriptBlock(GetType(), "MSG", string.Format("alert('{0}');", msg), true);
        }
    }
}