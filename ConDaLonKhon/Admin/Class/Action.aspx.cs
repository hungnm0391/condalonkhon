using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConDaLonKhon.Admin.Class
{
    public partial class Action : WebBase
    {
        private Common.Validate _validate;
        private VO.CLASS _class;
        private List<int> knowledgeIds;

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
                BindSchool();

                string strId = Request["id"];
                if (strId != null)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;

                    int intId;
                    if (!int.TryParse(strId, out intId))
                    {
                        RunJavascript("alert('Id lớp học không hợp lệ');window.location='/Admin/Class/Default.aspx';");
                        return;
                    }

                    _validate = new Common.Validate();
                    BindClass(intId);
                    if (_validate.IsError)
                    {
                        RunJavascript("alert('" + _validate.Message + "');window.location='/Admin/Class/Default.aspx';");
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
        /// Bind class
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        private void BindClass(int id)
        {
            _class = new BUS.CLASS().GetById(id);
            if (_class == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tồn tại lớp học này";
                return;
            }

            txtClassName.Text = _class.CLASS_NAME;

            string strSchoolId = _class.SCHOOL_ID.ToString();
            if (ddlSchool.Items.FindByValue(strSchoolId) != null)
                ddlSchool.SelectedValue = strSchoolId;

            if (ddlClassType.Items.FindByValue(_class.CLASS_TYPE) != null)
                ddlClassType.SelectedValue = _class.CLASS_TYPE;
        }

        /// <summary>
        /// Bind knowledge
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        private void BindKnowledge()
        {
            cblKnowledge.DataSource = new BUS.KNOWLEDGE().GetForLI();
            cblKnowledge.DataTextField = "KNOWLEDGE_NAME";
            cblKnowledge.DataValueField = "ID";
            cblKnowledge.DataBind();
        }

        /// <summary>
        /// Bind knowledge
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        private void BindSchool()
        {
            ddlSchool.DataSource = new BUS.SCHOOL().GetForLI(null);
            ddlSchool.DataTextField = "SCHOOL_NAME";
            ddlSchool.DataValueField = "ID";
            ddlSchool.DataBind();

            ddlSchool.Items.Insert(0, new ListItem("--- Chọn trường học ---", string.Empty));
        }

        /// <summary>
        /// Event Insert
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            _class = new VO.CLASS();
            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                RunJavascript("alert('" + _validate.Message + "');");
                return;
            }

            BUS.CLASS objBUS = new BUS.CLASS();
            if (objBUS.CheckExist(_class.ID, _class.SCHOOL_ID, _class.CLASS_NAME.ToLower()))
            {
                RunJavascript("alert('Tên lớp học đã tồn tại');");
                return;
            }

            Nullable<decimal> intClassId = objBUS.Insert(_class);
            if (intClassId.HasValue)
            {
                VO.CLASS_KNOWLEDGE objClassKnowledge;
                foreach (int item in knowledgeIds)
                {
                    objClassKnowledge = new VO.CLASS_KNOWLEDGE();
                    objClassKnowledge.KNOWLEDGE_ID = item;
                    objClassKnowledge.CLASS_ID = Convert.ToInt32(intClassId.Value);

                    if (!new BUS.CLASS_KNOWLEDGE().Insert(objClassKnowledge))
                    {

                    }
                }

                RunJavascript("alert('Thêm mới thành công');window.location='/Admin/Class/Default.aspx';");
            }
            else
                RunJavascript("alert('Thêm mới thất bại');window.location='/Admin/Class/Default.aspx';");
        }

        /// <summary>
        /// Event Update
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          25/06/2014      Add
        /// </modified>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int intId;
            if (!int.TryParse(Request["id"], out intId))
            {
                RunJavascript("alert('Id không hợp lệ');window.location='/Admin/Class/Default.aspx';");
                return;
            }

            BUS.CLASS objBUS = new BUS.CLASS();
            _class = objBUS.GetById(intId);
            if (_class == null)
            {
                RunJavascript("alert('Không tìm thấy lớp học này để cập nhật thông tin');");
                return;
            }

            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                RunJavascript("alert('" + _validate.Message + "');");
                return;
            }

            if (objBUS.CheckExist(_class.ID, _class.SCHOOL_ID, _class.CLASS_NAME.ToLower()))
            {
                RunJavascript("alert('Tên lớp học đã tồn tại');");
                return;
            }

            if (objBUS.Update(_class))
                RunJavascript("alert('Cập nhật thành công');window.location='/Admin/Class/Default.aspx';");
            else
                RunJavascript("alert('Cập nhật thất bại');window.location='/Admin/Class/Default.aspx';");
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
            string strClassName = txtClassName.Text.Trim();
            if (strClassName == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu nhập tên lớp học";
                return;
            }

            if (strClassName.Length > 500)
            {
                _validate.IsError = true;
                _validate.Message = "Tên lớp học không được quá 500 ký tự";
                return;
            }

            _class.CLASS_NAME = strClassName;

            string strSchoolId = ddlSchool.SelectedValue;
            if (strSchoolId == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu chọn trường học";
                return;
            }

            int intSchoolId;
            if (!int.TryParse(strSchoolId, out intSchoolId))
            {
                _validate.IsError = true;
                _validate.Message = "Id trường học không hợp lệ";
                return;
            }

            if (new BUS.SCHOOL().GetById(intSchoolId) == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tìm thấy trường học này";
                BindSchool();
                return;
            }

            _class.SCHOOL_ID = intSchoolId;

            string strClassType = ddlClassType.SelectedValue;
            if (strClassType == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu chọn loại lớp học";
                return;
            }

            if (strClassType != "01" && strClassType != "02")
            {
                _validate.IsError = true;
                _validate.Message = "Loại lớp học không hợp lệ";
                return;
            }

            _class.CLASS_TYPE = strClassType;

            knowledgeIds = new List<int>();
            int intTemp;
            BUS.KNOWLEDGE busKnowledge = new BUS.KNOWLEDGE();
            foreach (ListItem item in cblKnowledge.Items)
            {
                if (item.Selected)
                {
                    if (!int.TryParse(item.Value, out intTemp))
                    {
                        _validate.IsError = true;
                        _validate.Message = "Có dữ liệu loại kiến thức không hợp lệ";
                        return;
                    }

                    if (busKnowledge.GetById(intTemp) == null)
                    {
                        _validate.IsError = true;
                        _validate.Message = "Có dữ liệu loại kiến thức không tồn tại";
                        BindKnowledge();
                        return;
                    }

                    knowledgeIds.Add(intTemp);
                }
            }
        }
    }
}