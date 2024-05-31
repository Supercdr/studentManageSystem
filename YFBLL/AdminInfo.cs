using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SDM.BLL
{
    public class AdminInfo
    {
        private readonly SDM.DAL.AdminInfo dal = new SDM.DAL.AdminInfo();
        public AdminInfo() { }
        #region BasicMethod
        //是否存在该纪录
        public bool Exists(int AdminID)
        {
            return dal.Exists(AdminID);
        }
        //增加一条数据
        public int Add(SDM.Model.AdminInfo model)
        {
            return dal.Add(model);
        }
        //更新一条数据
        public bool Update(SDM.Model.AdminInfo model)
        {
            return dal.Update(model);
        }
        //删除一条数据
        public bool Delete(int AdminID)
        {
            return dal.Delete(AdminID);
        }
        //得到一个对象实体
        public SDM.Model.AdminInfo GetModel(int AdminID)
        {
            return dal.GetModel(AdminID);
        }
        //获得数据列表
        public DataSet GetList(string strWhere)
        {
            return dal.GetList(strWhere);
        }
        //获得前几行数据
        public DataSet GetList(int Top,string strWhere, string filedOrder)
        {
            return dal.GetList(Top, strWhere, filedOrder);
        }
        //获得数据列表
        public DataSet GetAllList() 
        {
            return GetList("");
        }
        //获取满足条件的数据条数
        public int GetRecordCount(string strWhere)
        {
            return dal.GetRecordCount(strWhere);
        }
        #endregion BasicMethod
        #region ExtensionMethod
        public DataSet GetAdminLogin(string strName,string strPass)
        {
            return dal.GetAdminLogin(strName, strPass);
        }
        public DataSet GetStuLogin(string strName, string strPass)
        {
            return dal.GetStuLogin(strName, strPass);
        }
        #endregion ExtensionMethod
    }
}
