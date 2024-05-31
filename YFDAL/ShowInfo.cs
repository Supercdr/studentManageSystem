using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web.Security;

namespace SDM.DAL
{
    public class ShowInfo
    {
        public ShowInfo() { }
        ///<summary>
        ///弹出JavaScrip小窗口
        /// </summary>
        /// <param name="js">窗口信息</param>
        public static void Alert(string message,Page page)
        {
            string js = @"<Script language='JavaScript'>alert('" + message + "');</Script>";
            if (!page.ClientScript.IsStartupScriptRegistered(page.GetType(), "alert"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "alert", js);
            }
        }

        public static void AlertAndRedirect(string message, string redirectUrl, Page page)
        {
            // 使用JavaScript弹出警告框
            string script = $"<script>alert('{message}'); window.location='{redirectUrl}';</script>";

            // 将脚本注册到页面上
            if (page != null && !page.ClientScript.IsClientScriptBlockRegistered("alertRedirectScript"))
            {
                page.ClientScript.RegisterStartupScript(page.GetType(), "alertRedirectScript", script);
            }
        }
    }
}