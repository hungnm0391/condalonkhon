using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ConDaLonKhon.Common;

namespace ConDaLonKhon.Admin.School
{
    public partial class Action : WebBase
    {
        private VO.SCHOOL _school;
        private Validate _validate;

        /// <summary>
        /// Event page load
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCity();

                string strId = Request["id"];
                if (strId != null)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;

                    // Convert id
                    int intId;
                    if (!int.TryParse(strId, out intId))
                    {
                        RunJavascript("alert('Id của trường không hợp lệ!');window.location='/Admin/School/Default.aspx';");
                        return;
                    }
                    // Bind object
                    _validate = new Common.Validate();
                    BindSchool(intId);
                    if (_validate.IsError)
                    {
                        RunJavascript("alert('" + _validate.Message + "');window.location='/Admin/School/Default.aspx';");
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
        /// Bind dropdownlist City
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        private void BindCity()
        {
            DataTable dt = new BUS.CITY().GetForLI();
            ddlCity.DataSource = dt;
            ddlCity.DataValueField = "ID";
            ddlCity.DataTextField = "CITY_NAME";
            ddlCity.DataBind();

            ddlCity.Items.Insert(0, new ListItem("--- Chọn thành phố ---", string.Empty));
        }

        /// <summary>
        /// Bind school
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        private void BindSchool(int id)
        {
            _school = new BUS.SCHOOL().GetById(id);
            if (_school == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tìm thấy trường này!";
                return;
            }

            txtSchoolName.Text = _school.SCHOOL_NAME;
            txtAddress.Text = _school.ADDRESS;
            txtEmail.Text = _school.EMAIL;
            txtTelephone.Text = _school.TELEPHONE;
            txtWebsite.Text = _school.WEBSITE;

            string strCityID = _school.CITY_ID.ToString();
            if (ddlCity.Items.FindByValue(strCityID) != null)
                ddlCity.SelectedValue = strCityID;
        }

        /// <summary>
        /// Get data input
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        private void GetInput()
        {
            // Validate school name
            _school.SCHOOL_NAME = txtSchoolName.Text.Trim();
            if (_school.SCHOOL_NAME == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu nhập tên trường học!";
                return;
            }

            if (_school.SCHOOL_NAME.Length > 500)
            {
                _validate.IsError = true;
                _validate.Message = "Tên trường học tối đa 500 ký tự!";
                return;
            }

            // Validate address
            string strAddress = txtAddress.Text.Trim();
            if (strAddress != string.Empty)
            {
                if (strAddress.Length > 500)
                {
                    _validate.IsError = true;
                    _validate.Message = "Địa chỉ tối đa 500 ký tự!";
                    return;
                }
                _school.ADDRESS = strAddress;
            }

            // Validate telephone
            string strTelephone = txtTelephone.Text.Trim();
            if (strTelephone != string.Empty)
            {
                if (strTelephone.Length > 20)
                {
                    _validate.IsError = true;
                    _validate.Message = "Số điện thoại tối đa 20 ký tự!";
                    return;
                }

                if (!Common.Common.ValidateTelephoneNumber(strTelephone))
                {
                    _validate.IsError = true;
                    _validate.Message = "Số điện thoại không hợp lệ!";
                    return;
                }

                _school.TELEPHONE = strTelephone;
            }

            // Validate email address
            string strEmail = txtEmail.Text.Trim();
            if (strEmail != string.Empty)
            {
                if (strEmail.Length > 320)
                {
                    _validate.IsError = true;
                    _validate.Message = "Email tối đa 320 ký tự";
                    return;
                }

                if (!Common.Common.ValidateEmailAddress(strEmail))
                {
                    _validate.IsError = true;
                    _validate.Message = "Email không hợp lệ!";
                    return;
                }

                _school.EMAIL = strEmail;
            }

            // Validate website
            string strWebsite = txtWebsite.Text.Trim();
            if (strWebsite != string.Empty)
            {
                if (strWebsite.Length > 253)
                {
                    _validate.IsError = true;
                    _validate.Message = "Website tối đa 253 ký tự";
                    return;
                }

                if (!Common.Common.ValidateDomain(strWebsite))
                {
                    _validate.IsError = true;
                    _validate.Message = "Website không hợp lệ!";
                    return;
                }

                _school.WEBSITE = strWebsite;
            }

            // Validate city
            if (string.IsNullOrEmpty(ddlCity.SelectedValue))
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu chọn thành phố!";
                return;
            }

            short sCityId;
            if (!short.TryParse(ddlCity.SelectedValue, out sCityId))
            {
                _validate.IsError = true;
                _validate.Message = "Id thành phố không hợp lệ!";
                return;
            }

            VO.CITY objCity = new BUS.CITY().GetById(sCityId);
            if (objCity == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tìm thấy thành phố này!";
                return;
            }

            _school.CITY_ID = objCity.ID;
        }

        /// <summary>
        /// Event button insert click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        protected void btnInsert_Click(object sender, EventArgs e)
        {
            // Validate input
            _validate = new Common.Validate();
            _school = new VO.SCHOOL();
            GetInput();
            if (_validate.IsError)
            {
                ShowMessage(_validate.Message);
                return;
            }

            BUS.SCHOOL objBUS = new BUS.SCHOOL();
            // Check exist
            if (objBUS.CheckExist(_school.ID, _school.SCHOOL_NAME.ToLower()) > 0)
            {
                ShowMessage("Đã tồn tại trường học với tên này!");
                return;
            }
            // Insert
            if (objBUS.Insert(_school) > 0)
                RunJavascript("alert('Thêm mới thành công!');window.location='/Admin/School/Default.aspx';");
            else
                ShowMessage("Thêm mới thất bại!");
        }

        /// <summary>
        /// Event button update click
        /// </summary>
        /// <modified>
        /// Author          Date            Comment
        /// HungNM          14/06/2014      Add
        /// </modified>
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Convert id
            int intId;
            if (!int.TryParse(Request["id"], out intId))
            {
                RunJavascript("alert('Id không hợp lệ');window.location='/Admin/School/Default.aspx';");
                return;
            }

            BUS.SCHOOL objBUS = new BUS.SCHOOL();
            // Get object update
            _school = objBUS.GetById(intId);
            if (_school == null)
            {
                RunJavascript("alert('Không tìm thấy trường để sửa');window.location='/Admin/School/Default.aspx';");
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
            if (objBUS.CheckExist(_school.ID, _school.SCHOOL_NAME.ToLower()) > 0)
            {
                ShowMessage("Đã tồn tại trườnghọc với tên này!");
                return;
            }
            // Update
            if (objBUS.Update(_school) > 0)
                RunJavascript("alert('Cập nhật thành công!');window.location='/Admin/School/Default.aspx';");
            else
                ShowMessage("Cập nhật thất bại!");
        }
    }
}