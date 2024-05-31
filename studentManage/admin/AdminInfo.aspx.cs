using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class AdminInfo : System.Web.UI.Page
    {
        public SDM.BLL.AdminInfo bll = new SDM.BLL.AdminInfo();
        public SDM.Model.AdminInfo model = new SDM.Model.AdminInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["action"])){
                    switch (Request.QueryString["action"].ToString().Trim())
                    {
                        //当需要添加管理员时，显示提交按钮，隐藏保存按钮
                        case "Add":
                            btnEdit.Visible = false;
                            btnAdd.Visible = true;
                            break;
                        case "Edit":
                            btnEdit.Visible = true;
                            btnAdd.Visible = false;
                            int id = int.Parse(Request.QueryString["id"]);
                            model = bll.GetModel(id);
                            txtAdminName.Text = model.AdminName.ToString();
                            txtPwd.Text = model.AdminPass.ToString();
                            break;
                    }
                    bind();
                }
            }
        }
        //定义一个bind方法，将管理员信息绑定到Repeater控件上
        protected void bind()
        {
            //调用BLL层中的函数返沪所有管理员账户信息，并绑定到Repeater控件
            Repeater1.DataSource = bll.GetAllList();
            Repeater1.DataBind();
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            model = CreateModel();
            string id = Request.QueryString["id"];
            if (string.IsNullOrEmpty(Request.QueryString["id"]) || !int.TryParse(Request.QueryString["id"], out int adminId))
            {
                SDM.DAL.ShowInfo.Alert("ID 参数格式不正确或缺失。", this.Page);
                return;
            }
            model.AdminID = adminId;
            bll.Update(model);
            SDM.DAL.ShowInfo.Alert("操作成功！", this.Page);
            bind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtAdminName.Text == "" || txtPwd.Text == "")
            {
                SDM.DAL.ShowInfo.Alert("账号和密码不能为空！", this.Page);
                return;
            }
            else
            {
                bll.Add(CreateModel());
                SDM.DAL.ShowInfo.Alert("操作成功！", this.Page);
                bind();
            }
        }
        //createmodel方法用于构造一个管理员数据模型对象
        protected SDM.Model.AdminInfo CreateModel()
        {
            model.AdminName = txtAdminName.Text.Trim();
            model.AdminPass = txtPwd.Text.Trim();
            return model;
        }
    }
}