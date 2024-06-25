using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class top : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["username"] != null)
                {
                    Label1.Text = "您好" + Session["username"].ToString() + ",欢迎使用学生管理系统！";
                }
            }
        }
        protected void btnLoginOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Write("<script>alert('注销成功！');parent.location.href='../index.aspx'</script>");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Write("<script>confirm('确定退出此账号吗？');parent.location.href='../index.aspx'</script>");
        }
    }
}