using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class sql : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //从查询字符串中读取需要删除的id值
            int id = int.Parse(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                switch (Request.QueryString["action"].ToString().Trim())
                {
                    case "DelStudent":
                        SDM.BLL.StudentsInfo bllStudent = new SDM.BLL.StudentsInfo();
                        bllStudent.Delete(id);
                        SDM.DAL.ShowInfo.AlertAndRedirect("删除成功！", "StudentInfo.aspx?action=add", this.Page);
                        break;
                    case "DelAdmin":
                        SDM.BLL.AdminInfo bllAdminInfo = new SDM.BLL.AdminInfo();
                        bllAdminInfo.Delete(id);
                        SDM.DAL.ShowInfo.AlertAndRedirect("删除成功！", "AdminInfo.aspx?action=add", this.Page);
                        break;
                    case "DelWorkPerson":
                        SDM.BLL.WorksInfo bllWorksInfo = new SDM.BLL.WorksInfo();
                        bllWorksInfo.Delete(id);
                        SDM.DAL.ShowInfo.AlertAndRedirect("删除成功！", "WorkPersonList.aspx", this.Page);
                        break;
                    case "DelWorkTuanDui":
                        SDM.BLL.WorkTuanDui bllTuanDui = new SDM.BLL.WorkTuanDui();
                        bllTuanDui.Delete(id);
                        SDM.DAL.ShowInfo.AlertAndRedirect("删除成功！", "WorkTuanDuiList.aspx", this.Page);
                        break;
                }
            }
        }
    }
}