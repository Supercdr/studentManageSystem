using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class PlayOnline : System.Web.UI.Page
    {
        public string MediaUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request.QueryString["action"].ToString().Trim())
                {
                    case "WorkPerson":
                        SDM.BLL.WorksInfo bllWorksInfo = new SDM.BLL.WorksInfo();
                        int worksInfoID = int.Parse(Request.QueryString["id"]);
                        MediaUrl = "../" + bllWorksInfo.GetModel(worksInfoID).WorkUrl.ToString();
                        this.LiteralSource.Text = string.Format("<source type=\"video/mp4\"src=\"{0}\"/>", MediaUrl);
                        break;
                    case "WorkTuanDui":
                        SDM.BLL.WorkTuanDui bllWorkTuanDui = new SDM.BLL.WorkTuanDui();
                        int WorkTuanDuiID = int.Parse(Request.QueryString["id"]);
                        MediaUrl = "../" + bllWorkTuanDui.GetModel(WorkTuanDuiID).WorkUrl.ToString();
                        this.LiteralSource.Text = string.Format("<source type=\"video/mp4\"src=\"{0}\"/>", MediaUrl);
                        break;
                }
            }
        }
    }
}