using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace studentManage.admin
{
    public partial class CheckFiles : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int strid = int.Parse(Request.QueryString["id"]);
                string action = Request.QueryString["action"].ToString();
                PlayOnline.Text = "您要查看的是作品视频<br/>" + "<a href='PlayOnline.aspx?id=" + strid + "&action=" + action + "'class='blue'>>>" +
                    "点击这里在线观看作品视频<<</a><br/>";
                Download.Text = "如果您需要下载观看该作品视频<br/>" + "<a href='DownloadFile.aspx?id=" + strid + "&action=" + action + "'class='blue'>>>点击这里下载作品视频<<</a>";
            }
        }
    }
}