using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ConDaLonKhon.Admin.School
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
                BindSchool();
            }
        }

        /// <summary>
        /// Bind school
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        private void BindSchool()
        {
            Nullable<short> intCityId = null;
            short intTemp;
            if (!string.IsNullOrEmpty(ddlCity.SelectedValue))
            {
                if (short.TryParse(ddlCity.SelectedValue, out intTemp))
                    intCityId = intTemp;
                else
                {
                    ddlCity.ClearSelection();
                    ShowMessage("Thành phố không hợp lệ!");
                }
            }

            string strSchoolName = txtSchoolName.Text.Trim();
            if (strSchoolName == string.Empty)
                strSchoolName = null;
            else
            {
                if (strSchoolName.Length > 500)
                {
                    txtSchoolName.Text = string.Empty;
                    strSchoolName = null;
                    ShowMessage("Tên trường học tối đa 500 ký tự!");
                }
                else
                    strSchoolName = strSchoolName.ToLower();
            }

            grvSchool.DataSource = new BUS.SCHOOL().Search(intCityId, strSchoolName);
            grvSchool.DataBind();
        }

        /// <summary>
        /// Bind city
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        private void BindCity()
        {
            DataTable dt = new BUS.CITY().GetForLI();
            ddlCity.DataSource = dt;
            ddlCity.DataTextField = "CITY_NAME";
            ddlCity.DataValueField = "ID";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0, new ListItem("--- Chọn thành phố ---", string.Empty));
        }

        /// <summary>
        /// Event row command
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void grvSchool_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "SUA":
                    Response.Redirect(string.Format("~/Admin/School/Action.aspx?id={0}", e.CommandArgument));
                    break;

                case "XOA":
                    // Convert id
                    int intId;
                    if (!int.TryParse((string)e.CommandArgument, out intId))
                    {
                        ShowMessage("Id không hợp lệ!");
                        BindSchool();
                        return;
                    }
                    BUS.SCHOOL objBUS = new BUS.SCHOOL();
                    // Check delete
                    if (objBUS.CheckDel(intId) > 0)
                    {
                        ShowMessage("Trường học này đã có lớp học. Không được phép xóa!");
                        return;
                    }
                    // Delete
                    if (objBUS.Delete(intId) > 0)
                        ShowMessage("Xóa thành công!");
                    else
                        ShowMessage("Xóa thất bại!");
                    // Rebind girdview
                    BindSchool();
                    break;

                default:
                    ShowMessage("Không tồn tại chức năng này!");
                    break;
            }
        }

        /// <summary>
        /// Event row data bound
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void grvSchool_RowDataBound(object sender, GridViewRowEventArgs e)
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

                object objSCHOOL_NAME = DataBinder.Eval(e.Row.DataItem, "SCHOOL_NAME");
                if (objSCHOOL_NAME != DBNull.Value)
                {
                    Literal ltrSchoolName = (Literal)e.Row.FindControl("ltrSchoolName");
                    ltrSchoolName.Text = Server.HtmlEncode((string)objSCHOOL_NAME);
                }

                Literal ltrCity = (Literal)e.Row.FindControl("ltrCity");
                ltrCity.Text = Server.HtmlEncode((string)DataBinder.Eval(e.Row.DataItem, "CITY_NAME"));
            }
        }

        /// <summary>
        /// Event button search click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindSchool();
        }
    }
}