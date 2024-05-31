using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.stu
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
            // 获取数据源
            int id = int.Parse(Session["userid"].ToString());
            var dataSource = bll.GetListByPage(id, "WorkID DESC", AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1) ,
                AspNetPager1.PageSize * AspNetPager1.CurrentPageIndex);

            // 绑定数据到GridView
            gdvWishList.DataSource = dataSource;
            gdvWishList.DataBind();

            // 设置分页控件的记录总数
            AspNetPager1.RecordCount = bll.GetRecordCount("1=1");

            // 检查分页控件是否可见
            AspNetPager1.Visible = AspNetPager1.RecordCount > 0;

            // 调试日志
            System.Diagnostics.Debug.WriteLine("RecordCount: " + AspNetPager1.RecordCount);
            System.Diagnostics.Debug.WriteLine("CurrentPageIndex: " + AspNetPager1.CurrentPageIndex);
        }
        protected void AspNetPager1_PageChanging(object src, Wuqi.Webdiyer.PageChangingEventArgs e)
        {
            AspNetPager1.CurrentPageIndex = e.NewPageIndex;
            BindLoad();
        }

        protected void gdvWishList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[1].Text = id.ToString();
            }
        }

    }
}