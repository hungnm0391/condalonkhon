using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConDaLonKhon.Admin.Knowledge
{
    public partial class Action : WebBase
    {
        private Common.Validate _validate;
        private VO.KNOWLEDGE _knowledge;

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
                string strId = Request["id"];
                if (strId != null)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;

                    // Convert id
                    int intId;
                    if (!int.TryParse(strId, out intId))
                    {
                        RunJavascript("alert('Id kiến thức không hợp lệ');window.location='/Admin/Knowledge/Default.aspx';");
                        return;
                    }
                    // Bind object
                    _validate = new Common.Validate();
                    BindKnowledge(intId);
                    if (_validate.IsError)
                    {
                        RunJavascript("alert('" + _validate.Message + "');window.location='/Admin/Knowlegde/Default.aspx';");
                        return;
                    }
                }
                else
                {
                    btnInsert.Visible = true;
                    btnUpdate.Visible = false;
                }
            }
        }

        /// <summary>
        /// Bind city
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        private void BindKnowledge(int id)
        {
            _knowledge = new BUS.KNOWLEDGE().GetById(id);
            if (_knowledge == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tồn tại kiến thức này";
                return;
            }

            txtKnowledgeName.Text = _knowledge.KNOWLEDGE_NAME;
        }

        /// <summary>
        /// Get data input
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        private void GetInput()
        {
            string strKnowledgeName = txtKnowledgeName.Text.Trim();
            if (strKnowledgeName == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu nhập tên kiến thức";
                return;
            }

            if (strKnowledgeName.Length > 500)
            {
                _validate.IsError = true;
                _validate.Message = "Tên kiến thức không được quá 500 ký tự";
                return;
            }

            _knowledge.KNOWLEDGE_NAME = strKnowledgeName;
        }

        /// <summary>
        /// Event button insert click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate input
            _knowledge = new VO.KNOWLEDGE();
            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                ShowMessage(_validate.Message);
                return;
            }

            BUS.KNOWLEDGE objBUS = new BUS.KNOWLEDGE();
            // Check exist
            if (objBUS.CheckExist(_knowledge.ID, _knowledge.KNOWLEDGE_NAME.ToLower()) > 0)
            {
                ShowMessage("Tên kiến thức đã tồn tại!");
                return;
            }
            // Insert
            if (objBUS.Insert(_knowledge) > 0)
                RunJavascript("alert('Thêm mới thành công');window.location='/Admin/Knowledge/Default.aspx';");
            else
                ShowMessage("Thêm mới thất bại!");
        }

        /// <summary>
        /// Event button update click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Convert id
            int intId;
            if (!int.TryParse(Request["id"], out intId))
            {
                RunJavascript("alert('Id không hợp lệ');window.location='/Admin/Knowledge/Default.aspx';");
                return;
            }

            BUS.KNOWLEDGE objBUS = new BUS.KNOWLEDGE();
            // Get object update
            _knowledge = objBUS.GetById(intId);
            if (_knowledge == null)
            {
                ShowMessage("Không tìm thấy kiến thức này để cập nhật thông tin!");
                return;
            }
            // Validate input
            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                ShowMessage(_validate.Message);
                return;
            }
            // Check exist
            if (objBUS.CheckExist(_knowledge.ID, _knowledge.KNOWLEDGE_NAME.ToLower()) > 0)
            {
                ShowMessage("Tên kiến thức đã tồn tại!");
                return;
            }
            // Update
            if (objBUS.Update(_knowledge))
                RunJavascript("alert('Cập nhật thành công');window.location='/Admin/Knowledge/Default.aspx';");
            else
                ShowMessage("Cập nhật thất bại!");
        }
    }
}