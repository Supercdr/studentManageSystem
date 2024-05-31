using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace SDM.DAL
{
    public class DbHelperSQL
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["studentmanage"].ConnectionString;
        public DbHelperSQL(){}
        public static object GetSingle(string SQLString)
        {
            using(SqlConnection connection=new SqlConnection(connectionString))
            {
                using(SqlCommand cmd=new SqlCommand(SQLString, connection))
                {
                    try
                    {
                        connection.Open();
                        object obj = cmd.ExecuteScalar();
                        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                        {
                            return null;
                        }
                        else
                        {
                            return obj;
                        }
                    }
                    catch (System.Data.SqlClient.SqlException e)
                    {
                        connection.Close();
                        throw e;
                    }
                }
            }
        }
        //查询数据库表记录的方法GetSingle
        public static object GetSingle(string SQLString, params SqlParameter[] cmdParms)
        {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        try
                        {
                        //调用PrepareCommand()方法，将sql语句和参数结合到SqlCommand对象中
                            PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                        //ExecuteScalar执行查询，返回查询结果的第一行第一列
                            object obj = cmd.ExecuteScalar();
                            cmd.Parameters.Clear();
                        //判断查询结果类型是否为空，System.DBNull.Value用于表示数据库中的空值（NULL）的特殊对象。它通常用于检查和处理数据库中的空值，以防止在读取数据时出现错误。
                        if ((Object.Equals(obj, null))||(Object.Equals(obj, System.DBNull.Value))){
                                return null;
                            }
                            else
                            {
                                return obj;
                            }
                        }catch(System.Data.SqlClient.SqlException e)
                        {
                            connection.Close();
                            throw e;
                        }
                    }
                }
            }
        
        //PrepareCommand()方法，将sql语句和各个参数结合到SqlCommand对象cmd中
            private static void PrepareCommand(SqlCommand cmd, SqlConnection conn, SqlTransaction trans, string cmdText, SqlParameter[] cmdParms)
            {
                if (conn.State != ConnectionState.Open)
                    conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = cmdText;
                cmd.CommandType = CommandType.Text;
            //若传入的事务对象不为空，则将其分配给SqlCommand对象的Transaction属性
                if (trans != null)
                {
                    cmd.Transaction = trans;
                }
            //如果传入的参数数组不为空
                if (cmdParms != null)
                {
                    foreach (SqlParameter parameter in cmdParms)
                    {
                    //如果参数的方向是Input或InputOutput且参数的值为null
                        if ((parameter.Direction == ParameterDirection.InputOutput || parameter.Direction
                            == ParameterDirection.Input) && (parameter.Value == null))
                        {
                        //处理命令参数，将 null 值转换为 DBNull.Value，以正确表示数据库中的 NULL。
                            parameter.Value = DBNull.Value;
                        }
                        //将参数添加到SqlCommand对象的Parameters集合中
                        cmd.Parameters.Add(parameter);
                    }
                }
        }
            public static bool Exists(string strSql,params SqlParameter[] cmdParms)
            {
                object obj = GetSingle(strSql, cmdParms);
                int cmdresult;
                if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)))
                {
                    cmdresult = 0;
                }
                else
                {
                    cmdresult = int.Parse(obj.ToString());
                }
                if (cmdresult == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            public static int ExecuteSql(string SQLstring)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(SQLstring, connection))
                    {
                        try
                        {
                            connection.Open();
                            int rows = cmd.ExecuteNonQuery();
                            return rows;
                        }
                        catch(System.Data.SqlClient.SqlException e)
                        {
                            connection.Close();
                            throw e;
                        }
                    }
                }
            }
            public static int ExecuteSql(string SQLstring,params SqlParameter[] cmdParms)
            {
                using(SqlConnection connection=new SqlConnection(connectionString))
                {
                    using(SqlCommand cmd=new SqlCommand())
                    {
                        try
                        {
                            PrepareCommand(cmd, connection, null, SQLstring, cmdParms);
                            int rows = cmd.ExecuteNonQuery();
                            cmd.Parameters.Clear();
                            return rows;
                        }
                        catch(System.Data.SqlClient.SqlException e)
                        {
                            throw e;
                        }
                    }
                }
            }
            public static DataSet Query(string SQLString)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    DataSet ds = new DataSet();
                    try
                    {
                        connection.Open();
                        SqlDataAdapter command = new SqlDataAdapter(SQLString, connection);
                        command.Fill(ds, "ds");
                    }catch(System.Data.SqlClient.SqlException ex)
                    {
                        throw new Exception(ex.Message);
                    }
                    return ds;
                }
            }
            public static DataSet Query(string SQLString,params SqlParameter[] cmdParms)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand();
                    PrepareCommand(cmd, connection, null, SQLString, cmdParms);
                    using(SqlDataAdapter da=new SqlDataAdapter(cmd))
                    {
                        DataSet ds = new DataSet();
                        try
                        {
                            da.Fill(ds, "ds");
                            cmd.Parameters.Clear();
                        }
                        catch (System.Data.SqlClient.SqlException ex)
                        {
                            throw new Exception(ex.Message);
                        }
                        return ds;
                    }
                
                }
            }

            public static DataTable GetTable(string sql)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    //创建SqlDataAdapter对象
                    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                    //创建DataSet
                    DataSet ds = new DataSet();
                    //填充
                    adapter.Fill(ds);
                    return ds.Tables[0];
                }
            }
        }

}
