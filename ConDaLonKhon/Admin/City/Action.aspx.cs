using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConDaLonKhon.Common;

namespace ConDaLonKhon.Admin.City
{
    public partial class Action : WebBase
    {
        private Validate _validate;
        private VO.CITY _city;

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
                string strId = Request["id"];
                if (strId != null)
                {
                    btnInsert.Visible = false;
                    btnUpdate.Visible = true;
                    // Convert id
                    short intId;
                    if (!short.TryParse(strId, out intId))
                    {
                        RunJavascript("alert('Id thành phố không hợp lệ');window.location='/Admin/City/Default.aspx';");
                        return;
                    }
                    // Bind object
                    _validate = new Common.Validate();
                    BindCity(intId);
                    if (_validate.IsError)
                    {
                        RunJavascript("alert('" + _validate.Message + "');window.location='/Admin/City/Default.aspx';");
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
        private void BindCity(short id)
        {
            _city = new BUS.CITY().GetById(id);
            if (_city == null)
            {
                _validate.IsError = true;
                _validate.Message = "Không tồn tại thành phố này";
                return;
            }

            txtCityName.Text = _city.CITY_NAME;
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
            string strCityName = txtCityName.Text.Trim();
            if (strCityName == string.Empty)
            {
                _validate.IsError = true;
                _validate.Message = "Yêu cầu nhập tên thành phố";
                return;
            }

            if (strCityName.Length > 255)
            {
                _validate.IsError = true;
                _validate.Message = "Tên thành phố không được quá 255 ký tự";
                return;
            }

            _city.CITY_NAME = strCityName;
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
            _city = new VO.CITY();
            // Validate
            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                ShowMessage(_validate.Message);
                return;
            }
            // Check exist
            BUS.CITY objBUS = new BUS.CITY();
            if (objBUS.CheckExist(_city.ID, _city.CITY_NAME.ToLower()) > 0)
            {
                ShowMessage("Tên thành phố đã tồn tại!");
                return;
            }
            // Insert
            if (objBUS.Insert(_city) > 0)
                RunJavascript("alert('Thêm mới thành công');window.location='/Admin/City/Default.aspx'");
            else
                RunJavascript("alert('Thêm mới thất bại');window.location='/Admin/City/Default.aspx'");
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
            short intId;
            if (!short.TryParse(Request["id"], out intId))
            {
                RunJavascript("alert('Id không hợp lệ!');window.location='/Admin/City/Default.aspx';");
                return;
            }
            BUS.CITY objBUS = new BUS.CITY();
            // Get object update
            _city = objBUS.GetById(intId);
            if (_city == null)
            {
                ShowMessage("Không tìm thấy thành phố này để cập nhật thông tin!");
                return;
            }
            // Validate
            _validate = new Common.Validate();
            GetInput();
            if (_validate.IsError)
            {
                ShowMessage(_validate.Message);
                return;
            }
            // Check exist
            if (objBUS.CheckExist(_city.ID, _city.CITY_NAME.ToLower()) > 0)
            {
                ShowMessage("Tên thành phố đã tồn tại!");
                return;
            }
            // Update
            if (objBUS.Update(_city) > 0)
                RunJavascript("alert('Cập nhật thành công!');window.location='/Admin/City/Default.aspx';");
            else
                ShowMessage("Cập nhật thất bại!");
        }
    }
}