using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

//AdminInfo对应的数据访问层类
namespace SDM.DAL
{
    public class AdminInfo
    {
        public AdminInfo() { }
        #region BasicMethod
        //AdminInfo的基本方法，完成管理员的登陆验证和管理员账号的增删改查

        //Exists()方法，根据管理员ID查询管理员账户是否存在
        public bool Exists(int AdminID)
        {
            //创建一个可变字符序列对象
            StringBuilder strSql = new StringBuilder();
            //调用strSql对象的Append方法，逐步加入SQL语句
            strSql.Append("select count(1) from AdminInfo ");
            strSql.Append("where AdminID=@AdminID");
            //将传入的管理员ID转化成SQL语句中的参数形式
            SqlParameter[] parameters = { new SqlParameter("@AdminID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = AdminID;
            //调用DbHelperSQL类中的Exists方法，并返回结果
            return DbHelperSQL.Exists(strSql.ToString(), parameters);
        }

        //Add()方法，增加管理员记录
        public int Add(SDM.Model.AdminInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into AdminInfo (");
            strSql.Append("AdminName, AdminPass)");
            strSql.Append(" values (");
            strSql.Append("@AdminName, @AdminPass)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = { 
                new SqlParameter("@AdminName", SqlDbType.VarChar, 50),
                new SqlParameter("@AdminPass", SqlDbType.VarChar, 50)
            };
            parameters[0].Value = model.AdminName;
            parameters[1].Value = model.AdminPass;
            //执行数据库插入操作，返回查询结果
            object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                return Convert.ToInt32(obj);
            }
        }

        //Update()方法，对数据库的管理员信息进行更改
        public bool Update(SDM.Model.AdminInfo model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update AdminInfo set ");
            strSql.Append("AdminName = @AdminName,");
            strSql.Append("AdminPass = @AdminPass ");
            strSql.Append("where AdminID = @AdminID");
            SqlParameter[] parameters = {
                new SqlParameter("@AdminName", SqlDbType.VarChar, 50),
                new SqlParameter("@AdminPass", SqlDbType.VarChar, 50),
                new SqlParameter("@AdminID",SqlDbType.Int,4)
            };
            parameters[0].Value = model.AdminName;
            parameters[1].Value = model.AdminPass;
            parameters[2].Value = model.AdminID;

            //调用ExcuteSql()方法，返回执行SQL语句后受影响的记录数
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
        public bool Delete(int AdminID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminInfo ");
            strSql.Append("where AdminID=@AdminID");
            SqlParameter[] parameters = { new SqlParameter("@AdminID", System.Data.SqlDbType.Int, 4) };
            parameters[0].Value = AdminID;
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
        //deleteList()方法 批量删除数据，传入的list参数中包含需要删除的多个管理员ID
        public bool DeleteList(string AdminIDList)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("delete from AdminInfo ");
            strSql.Append("where AdminID in(" + AdminIDList + ") ");
            int rows = DbHelperSQL.ExecuteSql(strSql.ToString());
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //GetModel()方法 通过管理员ID对数据库进行查询，返回一个管理员类的对象实体
        public SDM.Model.AdminInfo GetModel(int AdminID)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 AdminID,AdminName,AdminPass from AdminInfo ");
            strSql.Append("where AdminID=@AdminID");
            SqlParameter[] parameters = { new SqlParameter("@AdminID", SqlDbType.Int, 4) };
            parameters[0].Value = AdminID;
            //新建一个管理员对象，用于存放结果并返回
            SDM.Model.AdminInfo model = new SDM.Model.AdminInfo();
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
        //DataRowToModel()方法 将传入的DataSet数据表中的一行数据转换为管理员对象实体，并返回该对象
        public SDM.Model.AdminInfo DataRowToModel(DataRow row)
        {
            //新建管理员对象实体
            SDM.Model.AdminInfo model = new SDM.Model.AdminInfo();
            if (row != null)
            {
                if (row["AdminID"] != null && row["AdminID"].ToString() != "")
                {
                    //对管理员对象实体进行赋值
                    model.AdminID = int.Parse(row["AdminID"].ToString());
                }
                if (row["AdminName"] != null)
                {
                    model.AdminName = row["AdminName"].ToString();
                }
                if(row["AdminPass"] != null)
                {
                    model.AdminPass = row["AdminPass"].ToString();
                }
            }
            return model;
        }

        //GetList()方法 通过某些条件来获取一些数据 传入的参数代表SQL语句中的查询条件
        public DataSet GetList(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select AdminID, AdminName, AdminPass ");
            strSql.Append("FROM AdminInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            return DbHelperSQL.Query(strSql.ToString());
        }

        //GetList()方法 有三个传入参数 top是获取前几个数据
        public DataSet GetList(int Top,string strWhere,string filedOrder)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select ");
            if (Top > 0)
            {
                strSql.Append("top " + Top.ToString());
            }
            strSql.Append(" AdminID, AdminName, AdminPass ");
            strSql.Append("from AdminInfo ");
            if (strWhere.Trim() != "")
            {
                strSql.Append(" where " + strWhere);
            }
            strSql.Append(" order by " + filedOrder);
            return DbHelperSQL.Query(strSql.ToString());
        }
        //GetRecordCount()方法 获取符合条件的记录条数，返回一个整型值
        public int GetRecordCount(string strWhere)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select count(1) from AdminInfo ");
            if (strWhere.Trim() !="")
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
        public DataSet GetAdminLogin(string strName, string strPass)
        {
            StringBuilder strsql = new StringBuilder();
            strsql.Append("select * from AdminInfo ");
            strsql.Append(" where ");
            strsql.Append(" AdminName=@strname and AdminPass=@strpass");
            SqlParameter[] parameter = {
                new SqlParameter("@strname", strName),
                new SqlParameter("@strpass", strPass)
            };

            try
            {
                DataSet result = DbHelperSQL.Query(strsql.ToString(), parameter);
                return result;

            }
            catch (Exception ex)
            {
                // 在这里记录异常信息，或者进行其他的错误处理操作
                // 例如，可以将异常信息写入日志文件，或者显示给用户
                Console.WriteLine("An error occurred while executing database query: " + ex.Message);
                return null;
            }
        }
        public DataSet GetStuLogin(string strName, string strPass)
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
