using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class StudentInfoAdd : System.Web.UI.Page
    {
        public SDM.BLL.StudentsInfo bll = new SDM.BLL.StudentsInfo();
        public SDM.Model.StudentInfo model = new SDM.Model.StudentInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string straction = Request.QueryString["action"].ToString().Trim();
                switch (straction)
                {
                    case "Add":
                        btnOK.Visible = true;
                        btnEdit.Visible = false;
                        txtUserAddTime.Text = Convert.ToString(DateTime.Now.ToString());
                        break;
                    case "Edit":
                        btnOK.Visible = false;
                        btnEdit.Visible = true;
                        EditLoadData();
                        txtUserAddTime.Text = Convert.ToString(DateTime.Now.ToString());
                        break;
                }
            }
        }
        public void EditLoadData()
        {
            int id = int.Parse(Request.QueryString["id"]);
            model = bll.GetModel(id);
            txtUserName.Text = model.UserName.ToString();
            DDLSex.SelectedItem.Text = model.UserSex.ToString();
            txtUserNumber.Text = model.UserNumber.ToString();
            txtUserPass.Text = model.UserPass.ToString();
            txtUserXy.Text = model.UserXy.ToString();
            txtUserZy.Text = model.UserZy.ToString();
            txtUserBj.Text = model.UserBj.ToString();
            DDLSex.Text = model.UserSex.ToString();
            txtUserAddress.Text = model.UserAddress.ToString();
            txtUserAddTime.Text = Convert.ToString(model.UserAddTime.ToString());
        }

        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (txtUserNumber.Text.Trim() == "")
            {
                SDM.DAL.ShowInfo.Alert("请输入学生学号！", this.Page);
                return;
            }else if (bll.Exists(txtUserNumber.Text.Trim()))
            {
                SDM.DAL.ShowInfo.Alert("对不起，此学号已被添加，请更换！！", this.Page);
                txtUserNumber.Focus();
                return;
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("学号未重复！",this.Page);
            }
        }


        protected void btnOK_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text.Trim()==""||txtUserNumber.Text.Trim()==""||txtUserXy.Text.Trim()==""||
                txtUserZy.Text.Trim() == "" || txtUserBj.Text.Trim() == "")
            {
                SDM.DAL.ShowInfo.Alert("学生姓名或学生学号或学生所属院系或学生所学专业或学生所属班级信息必填！！", this.Page);
                return;
            }else if (bll.Exists(txtUserNumber.Text.Trim()))
            {
                SDM.DAL.ShowInfo.Alert("对不起，此学号已被添加，请更换！！", this.Page);
                txtUserNumber.Focus();
            }
            else
            {
                model = CreateModel();
                int count = bll.Add(model);
                if (count > 0)
                {
                    SDM.DAL.ShowInfo.Alert("添加成功！", this.Page);
                    txtUserName.Text = "";
                    txtUserNumber.Text = "";
                }

            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            model = CreateModel();
            int id = int.Parse(Request.QueryString["id"]);
            model.UserID = id;
            if (bll.Update(model))
            {
                SDM.DAL.ShowInfo.AlertAndRedirect("操作成功！", "StudentInfo.aspx", this.Page);
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("操作失败，请重试！", this.Page);
            }
        }
        
        protected SDM.Model.StudentInfo CreateModel()
        {
            model.UserID = int.Parse(txtUserNumber.Text.Trim());
            model.UserName = txtUserName.Text.Trim();
            model.UserSex = DDLSex.SelectedItem.Text;
            model.UserNumber = txtUserNumber.Text.Trim();
            model.UserPass = txtUserPass.Text.Trim();
            model.UserXy = txtUserXy.Text.Trim();
            model.UserZy = txtUserZy.Text.Trim();
            model.UserBj = txtUserBj.Text.Trim();
            model.UserAddress = txtUserAddress.Text.Trim();
            model.UserAddTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            return model;
        }
    }
}