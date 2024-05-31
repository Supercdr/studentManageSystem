using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class DownloadFile : System.Web.UI.Page
    {
        public string MediaUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                switch (Request.QueryString["action"].ToString().Trim())
                {
                    case "WorkPerson":
                        SDM.BLL.WorksInfo bllWorkPerson = new SDM.BLL.WorksInfo();
                        int WorksInfoID = int.Parse(Request.QueryString["id"]);
                        MediaUrl = "../" + bllWorkPerson.GetModel(WorksInfoID).WorkUrl.ToString();
                        Download(MediaUrl);
                        break;
                    case "WorkTuanDui":
                        SDM.BLL.WorkTuanDui bllWorkTuanDui = new SDM.BLL.WorkTuanDui();
                        int WorkTuanDuiID = int.Parse(Request.QueryString["id"]);
                        MediaUrl = "../" + bllWorkTuanDui.GetModel(WorkTuanDuiID).WorkUrl.ToString();
                        Download(MediaUrl);
                        break;
                }
            }
        }
        private void Download(string url)
        {
            string filename = Path.GetFileName(url);
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AppendHeader("Content-Disposition", "attachment;   Filename=" +
                System.Convert.ToChar(34) + filename + System.Convert.ToChar(34));
            Response.Charset = "";
            Response.ContentEncoding = System.Text.Encoding.UTF8;
            Response.Flush();
            Response.WriteFile(url);

        }
    }
}