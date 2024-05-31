using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SDM.DAL
{
    public class StudentsInfo
    {
        public StudentsInfo() { }
        #region BasicMethod
        //Exists()方法，根据管理员ID查询管理员账户是否存在
        public bool Exists(string UserNumber)
        {
            //创建一个可变字符序列对象
            StringBuilder strSql = new StringBuilder();
            //调用strSql对象的Append方法，逐步加入SQL语句
            strSql.Append("select count(1) from StudentsInfo ");
            strSql.Append("where UserNumber=@UserNumber");
            //将传入的管理员ID转化成SQL语句中的参数形式
            SqlParameter[] parameters = { new SqlParameter("@UserNumber", System.Data.SqlDbType.VarChar, 200) };
            parameters[0].Value = UserNumber;
            //调用DbHelperSQL类中的Exists方法，并返回结果
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        public int Add(SDM.Model.StudentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into StudentsInfo (");
            strSql.Append("UserID, UserName, UserSex, UserNumber, UserPass, UserXy, UserZy, UserBj, UserAddTime, UserAddress)");
            strSql.Append(" values (");
            strSql.Append("@UserID, @UserName, @UserSex, @UserNumber, @UserPass, @UserXy ,@UserZy ,@UserBj, @UserAddTime, @UserAddress)");
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", SqlDbType.Int, 4),
                new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                new SqlParameter("@UserSex", SqlDbType.VarChar, 50),
                new SqlParameter("@UserNumber", SqlDbType.VarChar, 200),
                new SqlParameter("@UserPass", SqlDbType.VarChar, 50),
                new SqlParameter("@UserXy", SqlDbType.VarChar, 200),
                new SqlParameter("@UserZy", SqlDbType.VarChar, 200),
                new SqlParameter("@UserBj", SqlDbType.VarChar, 50),
                new SqlParameter("@UserAddTime", SqlDbType.VarChar, 50),
                new SqlParameter("@UserAddress", SqlDbType.VarChar, 200),

            };
            parameters[0].Value = model.UserID;
            parameters[1].Value = model.UserName;
            parameters[2].Value = model.UserSex;
            parameters[3].Value = model.UserNumber;
            parameters[4].Value = model.UserPass;
            parameters[5].Value = model.UserXy;
            parameters[6].Value = model.UserZy;
            parameters[7].Value = model.UserBj;
            parameters[8].Value = model.UserAddTime;
            parameters[9].Value = model.UserAddress;
            //执行数据库插入操作，返回查询结果
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows;
        }

        public bool Update(SDM.Model.StudentInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update StudentsInfo set ");
            strSql.Append("UserName = @UserName, ");
            strSql.Append("UserSex = @UserSex, ");
            strSql.Append("UserNumber = @UserNumber, ");
            strSql.Append("UserPass = @UserPass, ");
            strSql.Append("UserXy = @UserXy, ");
            strSql.Append("UserZy = @UserZy, ");
            strSql.Append("UserBj = @UserBj, ");
            strSql.Append("UserAddTime = @UserAddTime, ");
            strSql.Append("UserAddress = @UserAddress ");
            strSql.Append("where UserID = @UserID");

            SqlParameter[] parameters = {
                new SqlParameter("@UserName", SqlDbType.VarChar, 50),
                new SqlParameter("@UserSex", SqlDbType.VarChar, 50),
                new SqlParameter("@UserNumber", SqlDbType.VarChar, 200),
                new SqlParameter("@UserPass", SqlDbType.VarChar, 50),
                new SqlParameter("@UserXy", SqlDbType.VarChar, 200),
                new SqlParameter("@UserZy", SqlDbType.VarChar, 200),
                new SqlParameter("@UserBj", SqlDbType.VarChar, 50),
                new SqlParameter("@UserAddTime", SqlDbType.VarChar, 50),
                new SqlParameter("@UserAddress", SqlDbType.VarChar, 200),
                new SqlParameter("@UserID", SqlDbType.Int, 4)
            };

            parameters[0].Value = model.UserName;
            parameters[1].Value = model.UserSex;
            parameters[2].Value = model.UserNumber;
            parameters[3].Value = model.UserPass;
            parameters[4].Value = model.UserXy;
            parameters[5].Value = model.UserZy;
            parameters[6].Value = model.UserBj;
            parameters[7].Value = model.UserAddTime;
            parameters[8].Value = model.UserAddress;
            parameters[9].Value = model.UserID;
            
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString(), parameters);
            return rows > 0;
        }


        //delete()方法  根据传入的管理员ID，删除相应的记录
        public bool Delete(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from StudentsInfo ");
            strSql.Append("where UserID=@UserID");
            SqlParameter[] parameters = { new SqlParameter("@UserID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = UserID;
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

        public SDM.Model.StudentInfo GetModel(int UserID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 UserID,UserName,UserSex,UserNumber,UserPass,UserXy,UserZy,UserBj,UserAddTime,UserAddress from StudentsInfo ");
            strSql.Append("where UserID=@UserID");
            SqlParameter[] parameters = { new SqlParameter("@UserID", SqlDbType.Int, 4) };
            parameters[0].Value = UserID;
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
        public SDM.Model.StudentInfo DataRowToModel(DataRow row)
        {
            //新建对象实体
            SDM.Model.StudentInfo model = new SDM.Model.StudentInfo();
            if (row != null)
            {
                if (row["UserID"] != null && row["UserID"].ToString() != "")
                {
                    //对学生对象实体进行赋值
                    model.UserID = int.Parse(row["UserID"].ToString());
                }
                if (row["UserName"] != null)
                {
                    model.UserName = row["UserName"].ToString();
                }
                if (row["UserSex"] != null)
                {
                    model.UserSex = row["UserSex"].ToString();
                }
                if (row["UserNumber"] != null)
                {
                    model.UserNumber = row["UserNumber"].ToString();
                }
                if (row["UserPass"] != null)
                {
                    model.UserPass = row["UserPass"].ToString();
                }
                if (row["UserXy"] != null)
                {
                    model.UserXy = row["UserXy"].ToString();
                }
                if (row["UserZy"] != null)
                {
                    model.UserZy = row["UserZy"].ToString();
                }
                if (row["UserBj"] != null)
                {
                    model.UserBj = row["UserBj"].ToString();
                }
                if (row["UserAddTime"] != null)
                {
                    model.UserAddTime = row["UserAddTime"].ToString();
                }
                if (row["UserAddress"] != null)
                {
                    model.UserAddress = row["UserAddress"].ToString();
                }
            }
            return model;
        }

        public DataSet GetListByPage(string strWhere, string orderBy, int startIndex, int endIndex)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select * from ( ");
            strSql.Append(" select row_number() over (");
            if (!string.IsNullOrEmpty(orderBy.Trim()))
            {
                strSql.Append("order by T." + orderBy);
            }
            else
            {
                strSql.Append("order by T.UserID ASC");
            }
            strSql.Append(") as Row, T.*  from StudentsInfo T ");
            // 如果有条件，则添加 WHERE 子句
            if (!string.IsNullOrEmpty(strWhere.Trim()))
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" ) TT");
            strSql.AppendFormat(" where TT.Row between {0} and {1}", startIndex, endIndex);

            SqlParameter[] parameters = {
            new SqlParameter("@StartIndex", startIndex),
            new SqlParameter("@EndIndex", endIndex)
            };
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetStudentListByUserName(string username)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from StudentsInfo ");
            strSql.Append(" where ");
            strSql.Append(" UserName like @strname");
            SqlParameter[] parameters = { new SqlParameter("@strname", username) };
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        public DataSet GetStudentListByUserXy(string userxy)
        {
            StringBuilder strSql = new StringBuilder();

            strSql.Append("select * from StudentsInfo ");
            strSql.Append(" where ");
            strSql.Append(" UserXy like @userXy");
            SqlParameter[] parameters = { new SqlParameter("@userXy", userxy) };
            return DbHelperSQL.Query(strSql.ToString(), parameters);
        }

        //GetRecordCount()方法 获取符合条件的记录条数，返回一个整型值
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from StudentsInfo ");
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
        #endregion BasicMethod
        #region ExtensionMethod
        public DataSet GetLogin(string strName, string strPass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from StudentsInfo");
            strsql.Append(" where ");
            strsql.Append("UserName=@strname and UserPass=@strpass");
            SqlParameter[] parameter =
            {
                new SqlParameter("@strname",strName),
                new SqlParameter("@strpass", strPass)
            };
            return DbHelperSQL.Query(strsql.ToString(), parameter);
        }
        #endregion ExtensionMethod
    }
}
