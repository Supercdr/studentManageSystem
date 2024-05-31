using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using Newtonsoft.Json;

namespace studentManage
{
    /// <summary>
    /// Handler 的摘要说明
    /// </summary>
    public class Handler : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["type"];
            string year = context.Request.QueryString["year"];
            string major = context.Request.QueryString["major"];
            DataTable dt;
            string sql;

            try
            {
                switch (type)
                {
                    case "MapData":
                        sql = "select UserAddress as name, count(UserAddress) as value, UserName as stuname from StudentsInfo group by UserAddress, UserName;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "BarChart":
                        sql = $"SELECT Grade, Major, COUNT(*) AS NumOfStu from CollegeStu group by Major, Grade;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "XuRiChart":
                        if (string.IsNullOrEmpty(year))
                        {
                            throw new ArgumentException("year参数为空");
                        }
                        sql = $"select StuClass,Major, count(*) as NumOfStu from CollegeStu where Grade = '{year}' group by StuClass, Major;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    default:
                        throw new ArgumentException("无效的请求类型");
                }
                context.Response.ContentType = "application/json";
                var str = JsonConvert.SerializeObject(dt);
                context.Response.Write(str);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "text/plain";
                context.Response.Write($"发生错误：{ex.Message}");
            }

        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}