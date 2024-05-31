using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SDM.DAL
{
    public class WorksInfo
    {
        public WorksInfo() { }
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SDM.Model.WorksInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WorksInfo( ");
            strSql.Append("UserID,WorkName,WorkCate,WorkDes,WorkTime,WorkUrl,WorkPicUrl) ");
            strSql.Append(" values ( ");
            strSql.Append("@UserID,@WorkName,@WorkCate,@WorkDes,@WorkTime,@WorkUrl,@WorkPicUrl) ");
            strSql.Append("; select @@IDENTITY ");
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", SqlDbType.Int,4),
                new SqlParameter("@WorkName", SqlDbType.VarChar,500),
                new SqlParameter("@WorkCate", SqlDbType.VarChar,50),
                new SqlParameter("@WorkDes", SqlDbType.Text),
                new SqlParameter("@WorkTime", SqlDbType.VarChar,50),
                new SqlParameter("@WorkUrl", SqlDbType.Text),
                new SqlParameter ("@WorkPicUrl",SqlDbType.Text)
             };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.WorkName;
            parameters[2].Value = model.WorkCate;
            parameters[3].Value = model.WorkDes;
            parameters[4].Value = model.WorkTime;
            parameters[5].Value = model.WorkUrl;
            parameters[6].Value = model.WorkPicUrl;
            object obj = DbHelperSQL.GetSingle(strSql.ToString(), parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        public bool Exists(int WorkID)
        {
            //创建一个可变字符序列对象
            StringBuilder strSql = new StringBuilder();
            //调用strSql对象的Append方法，逐步加入SQL语句
            strSql.Append("select count(1) from WorksInfo");
            strSql.Append("where WorkID=@WorkID");
            //将传入的管理员ID转化成SQL语句中的参数形式
            SqlParameter[] parameters = { new SqlParameter("@WorkID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = WorkID;
            //调用DbHelperSQL类中的Exists方法，并返回结果
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Update(SDM.Model.WorksInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WorksInfo set ");
            strSql.Append("UserID = @UserID, ");
            strSql.Append("WorkName = @WorkName, ");
            strSql.Append("WorkCate = @WorkCate, ");
            strSql.Append("WorkDes = @WorkDes, ");
            strSql.Append("WorkTime = @WorkTime, ");
            strSql.Append("WorkUrl = @WorkUrl, ");
            strSql.Append("WorkPicUrl = @WorkPicUrl ");
            strSql.Append("where WorkID = @WorkID");
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", SqlDbType.Int),
                new SqlParameter("@WorkName", SqlDbType.VarChar, 500),
                new SqlParameter("@WorkCate", SqlDbType.VarChar, 50),
                new SqlParameter("@WorkDes", SqlDbType.Text),
                new SqlParameter("@WorkTime", SqlDbType.VarChar, 50),
                new SqlParameter("@WorkUrl", SqlDbType.VarChar, 300),
                new SqlParameter("@WorkPicUrl", SqlDbType.VarChar, 300),
                new SqlParameter("@WorkID", SqlDbType.Int, 4)
            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.WorkName;
            parameters[2].Value = model.WorkCate;
            parameters[3].Value = model.WorkDes;
            parameters[4].Value = model.WorkTime;
            parameters[5].Value = model.WorkUrl;
            parameters[6].Value = model.WorkPicUrl;
            parameters[7].Value = model.WorkID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }


        //delete()方法  根据传入的管理员ID，删除相应的记录
        public bool Delete(int WorkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorksInfo ");
            strSql.Append("where WorkID = @WorkID");
            SqlParameter[] parameters = { new SqlParameter("@WorkID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = WorkID;
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public DataSet GetListByPage(string where, string order, int min, int max)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("SELECT WorkID, WorkName, WorkCate, WorkDes, WorkTime, WorkUrl, WorkPicUrl, UserName from WorksInfo, StudentsInfo ");
            
            if (!string.IsNullOrEmpty(where.Trim()))
            {
                strSql.Append("where " + where + " ");
            }
            strSql.Append("and UserName in (select UserName from StudentsInfo where StudentsInfo.UserID = WorksInfo.UserID)  ");
            strSql.Append("order by " + order + " ");
            strSql.Append("OFFSET @min ROWS FETCH NEXT @max ROWS ONLY");

            SqlParameter[] parameters =
            {
                new SqlParameter("@min", min),
                new SqlParameter("@max", max)
            };

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }



        public DataSet GetListByPage(int userid, string order, int min, int max)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select WorkID, WorkName, WorkCate, WorkDes, WorkTime, WorkUrl, WorkPicUrl, UserID from WorksInfo ");
            strSql.Append(" where UserID=@UserID ");
            strSql.Append("order by " + order + " ");
            strSql.Append("OFFSET @min ROWS FETCH NEXT @max ROWS ONLY");

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userid),
                new SqlParameter("@min", min),
                new SqlParameter("@max", max)
            };

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }


        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WorksInfo ");
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append("where " + strWhere);
            }

            object obj = DbHelperSQL.GetSingle(strSql.ToString());
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }



        public SDM.Model.WorksInfo GetModel(int WorkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 WorkID,UserID,WorkName,WorkCate,WorkDes,WorkTime,WorkUrl,WorkPicUrl from WorksInfo ");
            strSql.Append("where WorkID=@WorkID");
            SqlParameter[] parameters = { new SqlParameter("@WorkID", SqlDbType.Int, 4) };
            parameters[0].Value = WorkID;
            //新建一个学生对象，用于存放结果并返回
            SDM.Model.StudentInfo model = new SDM.Model.StudentInfo();
            //调用DbHelperSQL类中的Query方法，得到结果集ds
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            //判读ds是否为空
            if (ds.Tables[0].Rows.Count > 0)
            {
                //返回ds中第一行第一列的数据
                return DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }
        public SDM.Model.WorksInfo DataRowToModel(DataRow row)
        {
            //新建对象实体
            SDM.Model.WorksInfo model = new SDM.Model.WorksInfo();
            if (row != null)
            {
                if (row["WorkID"] != null && row["WorkID"].ToString() != "")
                {
                    //对学生对象实体进行赋值
                    model.WorkID = int.Parse(row["WorkID"].ToString());
                }
                if (row["UserID"] != null)
                {
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["WorkName"] != null)
                {
                    model.WorkName = row["WorkName"].ToString();
                }
                if (row["WorkCate"] != null)
                {
                    model.WorkCate = row["WorkCate"].ToString();
                }
                if (row["WorkDes"] != null)
                {
                    model.WorkDes = row["WorkDes"].ToString();
                }
                if (row["WorkTime"] != null)
                {
                    model.WorkTime = row["WorkTime"].ToString();
                }
                if (row["WorkUrl"] != null)
                {
                    model.WorkUrl = row["WorkUrl"].ToString();
                }
                if (row["WorkPicUrl"] != null)
                {
                    model.WorkPicUrl = row["WorkPicUrl"].ToString();
                }
            }
            return model;
        }

        public int GetUserIDByWorkID(string workID)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("SELECT UserID FROM WorksInfo WHERE WorkID = @WorkID");
            SqlParameter[] parameters = {
                new SqlParameter("@WorkID", SqlDbType.Int)
                { Value = int.Parse(workID) }};
            object result = DbHelperSQL.GetSingle(strsql.ToString(), parameters);
            if (result != null)
            {
                return Convert.ToInt32(result);
            }
            throw new InvalidOperationException("No user associated with the work ID " + workID);
        }

        #endregion BasicMethod
    }
}
