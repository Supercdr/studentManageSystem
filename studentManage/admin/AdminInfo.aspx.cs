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
        protected void bind()
        {
            Repeater1.DataSource = bll.GetAllList();
            Repeater1.DataBind();
        }
        protected SDM.Model.AdminInfo CreateModel()
        {
            model.AdminName = txtAdminName.Text.Trim();
            model.AdminPass = txtPwd.Text.Trim();
            return model;
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
        
    }
}