using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class WorkTuanDuiList : System.Web.UI.Page
    {
        public SDM.BLL.WorkTuanDui bll = new SDM.BLL.WorkTuanDui();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindLoad();
            }
        }

        public void BindLoad()
        {
            rpTuanDui.DataSource = bll.GetListByPage("1=1", "WorkID DESC", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1) ,
                AspNetPager1.PageSize * AspNetPager1.CurrentPageIndex);
            rpTuanDui.DataBind();
            AspNetPager1.RecordCount = bll.GetRecordCount("1=1");
        }

        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindLoad();
        }
    }
}