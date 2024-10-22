﻿using System;
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
            string paramName = HttpUtility.UrlDecode(context.Request.QueryString["name"], System.Text.Encoding.UTF8);
            DataTable dt;
            string sql;
            try
            {
                switch (type)
                {
                    case "XuRiChart":
                        if (string.IsNullOrEmpty(year))
                        {
                            throw new ArgumentException("year参数为空");
                        }
                        sql = $"select StuClass,Major, count(*) as NumOfStu from CollegeStu where Grade = '{year}' group by StuClass, Major;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;

                    case "bubbling":
                        sql = "select  s.UserName as name,COUNT(w.WorkID) as value from WorksInfo w inner join StudentsInfo s on w.UserID = s.UserID group by s.UserName;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "stuTime":
                        sql = "select stuTime as time from userTime group by stuTime;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "stuScore":
                        sql = $"select name as name,sum as value from userScore group by name,sum order by sum desc;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "stuDetail":
                        if (string.IsNullOrEmpty(paramName))
                        {
                            throw new ArgumentException("name参数为空");
                        }
                        sql = $"select shld as value1,tydl as value2,jz as value3 ,mbook as value4,volunteer as value5,etsc as value6 from userScore where name = '{paramName}';";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "MapData":
                        sql = "select UserAddress as name, count(UserAddress) as value, UserName as stuname from StudentsInfo group by UserAddress, UserName;";
                        dt = SDM.DAL.DbHelperSQL.Query(sql).Tables[0];
                        break;
                    case "BarChart":
                        sql = $"SELECT Grade, Major, COUNT(*) AS NumOfStu from CollegeStu group by Major, Grade;";
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