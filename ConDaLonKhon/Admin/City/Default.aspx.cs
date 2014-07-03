using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConDaLonKhon.Admin.City
{
    public partial class Default : WebBase
    {
        /// <summary>
        /// Event page load
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCity();
            }
        }

        /// <summary>
        /// Bind gridview city
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        private void BindCity()
        {
            string strCityName = txtCityName.Text.Trim();

            if (string.IsNullOrEmpty(strCityName))
                grvCity.DataSource = new BUS.CITY().Search(null);
            else
            {
                if (strCityName.Length > 255)
                {
                    ShowMessage("Tên thành phố tối đa 255 ký tự!");
                    txtCityName.Text = string.Empty;
                    grvCity.DataSource = new BUS.CITY().Search(null);
                }
                else
                    grvCity.DataSource = new BUS.CITY().Search(strCityName.ToLower());
            }

            grvCity.DataBind();
        }

        /// <summary>
        /// Event row data bound
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void grvCity_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string strId = DataBinder.Eval(e.Row.DataItem, "ID").ToString();

                ImageButton ibtnEdit = (ImageButton)e.Row.FindControl("ibtnEdit");
                ibtnEdit.CommandArgument = strId;

                ImageButton ibtnDelete = (ImageButton)e.Row.FindControl("ibtnDelete");
                ibtnDelete.CommandArgument = strId;

                Literal ltrSTT = (Literal)e.Row.FindControl("ltrSTT");
                ltrSTT.Text = (e.Row.RowIndex + 1).ToString();

                Literal ltrCityName = (Literal)e.Row.FindControl("ltrCityName");
                ltrCityName.Text = Server.HtmlEncode((string)DataBinder.Eval(e.Row.DataItem, "CITY_NAME"));
            }
        }

        /// <summary>
        /// Event gridview button
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void grvCity_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "SUA":
                    Response.Redirect(string.Format("~/Admin/City/Action.aspx?id={0}", e.CommandArgument));
                    break;

                case "XOA":
                    // Convert id
                    short intId;
                    if (!short.TryParse((string)e.CommandArgument, out intId))
                    {
                        ShowMessage("Id không hợp lệ!");
                        BindCity();
                        return;
                    }
                    BUS.CITY objBUS = new BUS.CITY();
                    // Check delete
                    if (objBUS.CheckDel(intId) > 0)
                    {
                        ShowMessage("Thành phố này đã có trường học. Không được phép xóa!");
                        return;
                    }
                    // Delete
                    if (objBUS.Delete(intId) > 0)
                        ShowMessage("Xóa thành công!");
                    else
                        ShowMessage("Xóa thất bại!");
                    // Rebind girdview
                    BindCity();
                    break;

                default:
                    ShowMessage("Không tồn tại chức năng này!");
                    break;
            }
        }

        /// <summary>
        /// Event search button click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindCity();
        }
    }
}