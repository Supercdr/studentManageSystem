using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.stu
{
    public partial class Person : System.Web.UI.Page
    {
        private SDM.BLL.StudentsInfo bll = new SDM.BLL.StudentsInfo();
        private SDM.Model.StudentInfo model = new SDM.Model.StudentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int id = int.Parse(Session["userid"].ToString());
                model = bll.GetModel(id);
                txtBj.Text = model.UserBj.ToString();
                txtBj.Enabled = false;
                txtXy.Text = model.UserXy.ToString();
                txtXy.Enabled = false;
                txtZy.Text = model.UserZy.ToString();
                txtZy.Enabled = false;
                txtUserSex.Text = model.UserSex.ToString();
                txtUserSex.Enabled = false;
                txtUserPass.Text = model.UserPass.ToString();
                txtUserNumber.Text = model.UserNumber.ToString();
                txtUserNumber.Enabled = false;
                txtUserName.Text = model.UserName.ToString();
                txtUserName.Enabled = false;
                txtTime.Text = model.UserAddTime.ToString();
                txtTime.Enabled = false;
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            int id = int.Parse(Session["userid"].ToString());
            model.UserID = id;
            model.UserName = txtUserName.Text.Trim();
            model.UserPass = txtUserPass.Text.Trim();
            model.UserNumber = txtUserNumber.Text.Trim();
            model.UserSex = txtUserSex.Text.Trim();
            model.UserXy = txtXy.Text.Trim();
            model.UserZy = txtZy.Text.Trim();
            model.UserBj = txtBj.Text.Trim();
            model.UserAddTime = Convert.ToString(txtTime.Text.Trim());
            bll.Update(model);
            SDM.DAL.ShowInfo.Alert("修改成功！", this.Page);
        }
    }
}