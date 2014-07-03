using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

namespace ConDaLonKhon.Admin
{
    public partial class Login : System.Web.UI.Page
    {
        /// <summary>
        /// Event page load
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Event login button click
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">Event Args</param>
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string strUsername = txtUsername.Text.Trim();
            if (strUsername == string.Empty)
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "JS", "alert('Yêu cầu nhập tên đăng nhập!');", true);
                return;
            }

            string strPassword = txtPassword.Text;
            if (strUsername != "admin" && strPassword != "admin@2014")
            {
                ClientScript.RegisterClientScriptBlock(GetType(), "JS", "alert('Sai tên đăng nhập hoặc mật khấu!')", true);
                return;
            }

            FormsAuthentication.SetAuthCookie(strUsername, true);
            Response.Redirect("/Admin/Default.aspx");
        }
    }
}