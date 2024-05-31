using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage
{
    public partial class login : System.Web.UI.Page
    {
        public SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
        public SDM.BLL.StudentsInfo sll = new SDM.BLL.StudentsInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtUserName.Focus();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text.Trim()))
            {
                SDM.DAL.ShowInfo.Alert("请输入账号名称！", this.Page);
                txtUserName.Focus();
                return;
            }
            if (string.IsNullOrEmpty(txtUserPass.Text.Trim()))
            {
                SDM.DAL.ShowInfo.Alert("请输入登录密码！", this.Page);
                txtUserPass.Focus();
                return;
            }

            string username = txtUserName.Text.Trim();
            string password = txtUserPass.Text.Trim();
            string role = GetSelectedRole();
            DataTable dt;

            if (role == "admin")
            {
                dt = bll.GetAdminLogin(username, password).Tables["ds"];
                if (dt.Rows.Count > 0)
                {
                    Session["userid"] = dt.Rows[0][0].ToString();
                    Session["username"] = dt.Rows[0][1].ToString();
                    Session["role"] = role;
                    Response.Redirect("ad_index.aspx");
                }
                else
                {
                    SDM.DAL.ShowInfo.Alert("对不起，管理员账号不存在或密码错误！", this.Page);
                    txtUserName.Text = "";
                    txtUserPass.Text = "";
                }
            }
            else if (role == "student")
            {
                dt = bll.GetStuLogin(username, password).Tables["ds"];
                if (dt.Rows.Count > 0)
                {
                    Session["userid"] = dt.Rows[0][0].ToString();
                    Session["username"] = dt.Rows[0][1].ToString();
                    Session["usernumber"] = dt.Rows[0][3].ToString();
                    Session["role"] = role;
                    Response.Redirect("../stu/stu_index.aspx");
                }
                else
                {
                    SDM.DAL.ShowInfo.Alert("对不起，学生账号不存在或密码错误！", this.Page);
                    txtUserName.Text = "";
                    txtUserPass.Text = "";
                }
            }
            else
            {
                SDM.DAL.ShowInfo.Alert("未授权的角色，请联系管理员！", this.Page);
            }
        }


        private string GetSelectedRole()
        {
            if (rblRoleAdmin.Checked)
            {
                return "admin";
            }
            if (rblRoleStudent.Checked)
            {
                return "student";
            }
            return string.Empty;
        }
    }
}