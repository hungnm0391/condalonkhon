using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConDaLonKhon.Admin.Knowledge
{
    public partial class Default : WebBase
    {
        /// <summary>
        /// Event page load
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindKnowledge();
            }
        }

        /// <summary>
        /// Bind gridview city
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          19/06/2014      Add
        /// </modified>
        private void BindKnowledge(string knowledgeName = null)
        {
            string strKnowledgeName = txtKnowledgeName.Text.Trim();

            if (string.IsNullOrEmpty(strKnowledgeName))
                strKnowledgeName = null;
            else
            {
                if (strKnowledgeName.Length > 500)
                {
                    ShowMessage("Tên kiến thức tối đa 255 ký tự!");
                    txtKnowledgeName.Text = string.Empty;
                    strKnowledgeName = null;
                }
                else
                    strKnowledgeName = strKnowledgeName.ToLower();
            }

            grvKnowledge.DataSource = new BUS.KNOWLEDGE().Search(strKnowledgeName);
            grvKnowledge.DataBind();
        }

        /// <summary>
        /// Event row command
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void grvKnowledge_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "SUA":
                    Response.Redirect(string.Format("~/Admin/Knowledge/Action.aspx?id={0}", e.CommandArgument));
                    break;

                case "XOA":
                    // Convert id
                    int intId;
                    if (!int.TryParse((string)e.CommandArgument, out intId))
                    {
                        ShowMessage("Id không hợp lệ!");
                        BindKnowledge();
                        return;
                    }

                    BUS.KNOWLEDGE objBUS = new BUS.KNOWLEDGE();
                    // Check delete
                    if (objBUS.CheckDel(intId))
                    {
                        ShowMessage("Đã có lớp học kiến thức này. Không được phép xóa!");
                        return;
                    }
                    // Delete
                    if (objBUS.Delete(intId))
                        ShowMessage("Xóa thành công!");
                    else
                        ShowMessage("Xóa thất bại!");
                    // Rebind gridview
                    BindKnowledge();
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
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void grvKnowledge_RowDataBound(object sender, GridViewRowEventArgs e)
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

                Literal ltrKnowledgeName = (Literal)e.Row.FindControl("ltrKnowledgeName");
                ltrKnowledgeName.Text = Server.HtmlEncode((string)DataBinder.Eval(e.Row.DataItem, "KNOWLEDGE_NAME"));
            }
        }

        /// <summary>
        /// Event button search click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindKnowledge();
        }
    }
}