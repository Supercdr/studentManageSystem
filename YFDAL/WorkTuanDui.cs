using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace SDM.DAL
{
    public class WorkTuanDui
    {
        public WorkTuanDui() { }
        #region BasicMethod
        /// <summary>
        /// 根据输入的团队成员名称获取当前成员的UserID
        /// </summary>

        public DataSet GetUserIDByUserName(string strUserName)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from StudentsInfo ");
            strsql.Append(" where ");
            strsql.Append("UserName=@strUserName ");
            SqlParameter[] par = { new SqlParameter("@strUserName", strUserName) };
            return DbHelperSQL.Query(strsql.ToString(), par);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SDM.Model.WorkTuanDui model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into WorkTuanDui(");
            strSql.Append("WorkID,tdmc,UserID_1,UserID_1_des,UserID_2,UserID_2_des,UserID_3,UserID_3_des,WorkName,WorkCate,WorkDes,WorkTime,WorkUrl,WorkPicUrl)");
            strSql.Append(" values (");
            strSql.Append("@WorkID,@tdmc,@UserID_1,@UserID_1_des,@UserID_2,@UserID_2_des,@UserID_3,@UserID_3_des,@WorkName,@WorkCate,@WorkDes,@WorkTime,@WorkUrl,@WorkPicUrl)");
            SqlParameter[] parameters = {
                new SqlParameter("@WorkID", SqlDbType.Int,4),
                new SqlParameter("@tdmc", SqlDbType.NVarChar,50),
                new SqlParameter("@UserID_1", SqlDbType.Int,4),
                new SqlParameter("@UserID_1_des", SqlDbType.Text),
                new SqlParameter("@UserID_2", SqlDbType.Int,4),
                new SqlParameter("@UserID_2_des", SqlDbType.Text),
                new SqlParameter("@UserID_3", SqlDbType.Int,4),
                new SqlParameter("@UserID_3_des", SqlDbType.Text),
                new SqlParameter("@WorkName", SqlDbType.NVarChar,50),
                new SqlParameter("@WorkCate", SqlDbType.NVarChar,50),
                new SqlParameter("@WorkDes", SqlDbType.Text),
                new SqlParameter("@WorkTime", SqlDbType.NVarChar,50),
                new SqlParameter("@WorkUrl", SqlDbType.Text),
                new SqlParameter ("@WorkPicUrl",SqlDbType.Text)
            };

            parameters[0].Value = model.WorkID;
            parameters[1].Value = model.tdmc;
            parameters[2].Value = model.UserID_1;
            parameters[3].Value = model.UserID_1_des;
            parameters[4].Value = model.UserID_2;
            parameters[5].Value = model.UserID_2_des;
            parameters[6].Value = model.UserID_3;
            parameters[7].Value = model.UserID_3_des;
            parameters[8].Value = model.WorkName;
            parameters[9].Value = model.WorkCate;
            parameters[10].Value = model.WorkDes;
            parameters[11].Value = model.WorkTime;
            parameters[12].Value = model.WorkUrl;
            parameters[13].Value = model.WorkPicUrl;
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


        //delete()方法  根据传入的管理员ID，删除相应的记录
        public bool Delete(int WorkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from WorkTuanDui ");
            strSql.Append("where WorkID=@WorkID");
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

        public bool Update(SDM.Model.WorkTuanDui model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update WorkTuanDui set ");
            strSql.Append("tdmc = @tdmc, ");
            strSql.Append("UserID_1 = @UserID_1, ");
            strSql.Append("UserID_1_des = @UserID_1_des, ");
            strSql.Append("UserID_2 = @UserID_2, ");
            strSql.Append("UserID_2_des = @UserID_2_des, ");
            strSql.Append("UserID_3 = @UserID_3, ");
            strSql.Append("UserID_3_des = @UserID_3_des, ");
            strSql.Append("WorkName = @WorkName, ");
            strSql.Append("WorkCate = @WorkCate, ");
            strSql.Append("WorkDes = @WorkDes, ");
            strSql.Append("WorkTime = @WorkTime, ");
            strSql.Append("WorkUrl = @WorkUrl, ");
            strSql.Append("WorkPicUrl = @WorkPicUrl ");
            strSql.Append("where WorkID = @WorkID");
            SqlParameter[] parameters = {
                new SqlParameter("@tdmc", SqlDbType.VarChar, 50),
                new SqlParameter("@UserID_1", SqlDbType.Int),
                new SqlParameter("@UserID_1_des", SqlDbType.Text),
                new SqlParameter("@UserID_2", SqlDbType.Int),
                new SqlParameter("@UserID_2_des", SqlDbType.Text),
                new SqlParameter("@UserID_3", SqlDbType.Int),
                new SqlParameter("@UserID_3_des", SqlDbType.Text),
                new SqlParameter("@WorkName", SqlDbType.VarChar, 50),
                new SqlParameter("@WorkCate", SqlDbType.VarChar, 50),
                new SqlParameter("@WorkDes", SqlDbType.Text),
                new SqlParameter("@WorkTime", SqlDbType.VarChar, 50),
                new SqlParameter("@WorkUrl", SqlDbType.Text),
                new SqlParameter("@WorkPicUrl", SqlDbType.Text),
                new SqlParameter("@WorkID", SqlDbType.Int, 4)
            };
            parameters[0].Value = model.tdmc;
            parameters[1].Value = model.UserID_1;
            parameters[2].Value = model.UserID_1_des;
            parameters[3].Value = model.UserID_2;
            parameters[4].Value = model.UserID_2_des;
            parameters[5].Value = model.UserID_3;
            parameters[6].Value = model.UserID_3_des;
            parameters[7].Value = model.WorkName;
            parameters[8].Value = model.WorkCate;
            parameters[9].Value = model.WorkDes;
            parameters[10].Value = model.WorkTime;
            parameters[11].Value = model.WorkUrl;
            parameters[12].Value = model.WorkPicUrl;
            parameters[13].Value = model.WorkID;

            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }

        //Exists()方法，根据管理员ID查询管理员账户是否存在
        public bool Exists(int WorkID)
        {
            //创建一个可变字符序列对象
            StringBuilder strSql = new StringBuilder();
            //调用strSql对象的Append方法，逐步加入SQL语句
            strSql.Append("select count(1) from WorkTuanDui ");
            strSql.Append("where WorkID=@WorkID");
            //将传入的管理员ID转化成SQL语句中的参数形式
            SqlParameter[] parameters = { new SqlParameter("@WorkID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = WorkID;
            //调用DbHelperSQL类中的Exists方法，并返回结果
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }
        public bool Exists(string strUserName)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from StudentsInfo ");
            strsql.Append(" where ");
            strsql.Append("UserName=@strUserName ");
            SqlParameter[] par = { new SqlParameter("@strUserName", strUserName) };
            return DbHelperSQL.Exists(strsql.ToString(), par);
        }
        public SDM.Model.WorkTuanDui GetModel(int WorkID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 WorkID, tdmc, UserID_1, UserID_1_des, UserID_2, UserID_2_des, UserID_3, UserID_3_des, WorkName, WorkCate, WorkDes, WorkTime, WorkUrl, WorkPicUrl from WorkTuanDui ");
            strSql.Append("where WorkID=@WorkID");
            SqlParameter[] parameters = { new SqlParameter("@WorkID", SqlDbType.Int, 4) };
            parameters[0].Value = WorkID;
            //新建一个对象，用于存放结果并返回
            SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui();
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
        public SDM.Model.WorkTuanDui DataRowToModel(DataRow row)
        {
            //新建对象实体
            SDM.Model.WorkTuanDui model = new SDM.Model.WorkTuanDui();
            if (row != null)
            {
                if (row["WorkID"] != null && row["WorkID"] != DBNull.Value)
                {
                    model.WorkID = Convert.ToInt32(row["WorkID"]);
                }
                if (row["tdmc"] != null)
                {
                    model.tdmc = row["tdmc"].ToString();
                }
                if (row["UserID_1"] != null && row["UserID_1"] != DBNull.Value)
                {
                    model.UserID_1 = Convert.ToInt32(row["UserID_1"]);
                }
                if (row["UserID_1_des"] != null)
                {
                    model.UserID_1_des = row["UserID_1_des"].ToString();
                }
                if (row["UserID_2"] != null && row["UserID_2"] != DBNull.Value)
                {
                    model.UserID_2 = Convert.ToInt32(row["UserID_2"]);
                }
                if (row["UserID_2_des"] != null)
                {
                    model.UserID_2_des = row["UserID_2_des"].ToString();
                }
                if (row["UserID_3"] != null && row["UserID_3"] != DBNull.Value)
                {
                    model.UserID_3 = Convert.ToInt32(row["UserID_3"]);
                }
                if (row["UserID_3_des"] != null)
                {
                    model.UserID_3_des = row["UserID_3_des"].ToString();
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
        public DataSet GetListByPage(string where, string order, int min, int max)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select w.WorkID, w.WorkName, w.WorkCate, w.WorkTime, ");
            strSql.Append("w.WorkUrl, w.WorkDes, w.WorkPicUrl, s.UserName ");
            strSql.Append("from WorkTuanDui w ");
            strSql.Append("INNER JOIN StudentsInfo s ON w.UserID_1 = s.UserID ");
            if (!string.IsNullOrEmpty(where.Trim()))
            {
                strSql.Append("WHERE " + where + " ");
            }
            strSql.Append("AND s.UserName IN (SELECT s2.UserName FROM StudentsInfo s2 WHERE s2.UserNumber = s.UserNumber) ");
            strSql.Append("ORDER BY " + order + " ");
            strSql.Append("OFFSET @min ROWS FETCH NEXT @max ROWS ONLY");

            SqlParameter[] parameters =
            {
                new SqlParameter("@min", min),
                new SqlParameter("@max", max)
            };

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int userid, string orderby, int pageIndex, int pageSize)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select w.*, s.UserName from WorkTuanDui w ");
            strSql.Append("inner join StudentsInfo s on w.UserID_1 = s.UserID ");
            strSql.Append("where w.UserID_1 = @UserID or w.UserID_2 = @UserID or w.UserID_3 = @UserID ");
            strSql.Append("ORDER BY " + orderby + " ");
            strSql.Append("offset @startIndex rows fetch next @pageSize rows only");

            int startIndex = (pageIndex - 1) * pageSize;

            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userid),
                new SqlParameter("@startIndex", startIndex),
                new SqlParameter("@pageSize", pageSize)
            };

            try
            {
                return DbHelperSQL.Query(strSql.ToString(), parameters);
            }
            catch (SqlException ex)
            {
                // Log and handle the exception as needed
                throw new Exception("Database query error: " + ex.Message);
            }
        }

        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from WorkTuanDui ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
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
        public DataSet queryUserName(string userID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserName from StudentsInfo ");
            strSql.Append(" where UserID=@UserID");
            SqlParameter[] parameters =
            {
                new SqlParameter("@UserID", userID)
            };
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public bool ExistUser(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StudentsInfo ");
            strSql.Append(" where UserName=@UserName");
            SqlParameter[] parameters = { new SqlParameter("@UserName", UserName) };

            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public DataSet GetUserNumberByUserName(string UserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select UserNumBer from StudentsInfo ");
            strSql.Append("where UserName=@UserName");
            SqlParameter[] parameters ={new SqlParameter("@UserName", UserName)};

            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }
        #endregion BasicMethod
    }
}
