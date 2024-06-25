using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.stu
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public string strusername = "";
        public string strusernumber = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["userid"] == null || Session["userid"].ToString() == ""
            || Session["username"] == null || Session["username"].ToString() == "")
            {
                SDM.DAL.ShowInfo.Alert("请登录！", this.Page);
                Response.Redirect("../index.aspx");
            }
            else
            {
                strusername = Session["username"].ToString();
                strusernumber = Session["usernumber"].ToString();
            }
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Write("<script>confirm('确定退出此账号吗？');parent.location.href='../index.aspx'</script>");
        }
    }
}