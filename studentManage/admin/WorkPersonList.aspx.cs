using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class WorkPersonList : System.Web.UI.Page
    {
        public SDM.BLL.WorksInfo bll = new SDM.BLL.WorksInfo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userid"] == null || Session["userid"].ToString() == "")
                {
                    Response.Redirect("login.aspx");
                }
                else
                {
                    BindLoad();
                }
            }
        }
        
        public void BindLoad()
        {
            rpWorkPerson.DataSource = bll.GetListByPage("1=1", "WorkID desc", AspNetPager1.PageSize
                * (AspNetPager1.CurrentPageIndex - 1) , AspNetPager1.PageSize);
            rpWorkPerson.DataBind();
            AspNetPager1.RecordCount = bll.GetRecordCount("1=1");
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindLoad();
        }
    }
}