using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SDM.BLL
{
    public class WorkTuanDui
    {
        private readonly SDM.DAL.WorkTuanDui dui = new SDM.DAL.WorkTuanDui();
        public WorkTuanDui() { }
        #region BasicMethod

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(SDM.Model.WorkTuanDui model)
        {
            return dui.Add(model);
        }
        public DataSet GetUserIDByUserName(string strUserName)
        {
            return dui.GetUserIDByUserName(strUserName);
        }
        public bool Exists(int WorkID)
        {
            return dui.Exists(WorkID);
        }
        public bool Exists(string strUserName)
        {
            return dui.Exists(strUserName);
        }
        public bool Update(SDM.Model.WorkTuanDui model)
        {
            return dui.Update(model);
        }
        public bool Delete(int WorkID)
        {
            return dui.Delete(WorkID);
        }
        public SDM.Model.WorkTuanDui GetModel(int WorkID)
        {
            return dui.GetModel(WorkID);
        }
        public DataSet GetListByPage(string where, string order, int offset, int fetch)
        {
            return dui.GetListByPage(where, order, offset, fetch);
        }
        /// <summary>
        /// 分页获取数据列表
        /// </summary>
        public DataSet GetListByPage(int userid, string orderby, int startIndex, int endIndex)
        {
            return dui.GetListByPage(userid, orderby, startIndex, endIndex);
        }

        public int GetRecordCount(string strWhere)
        {
            return dui.GetRecordCount(strWhere);
        }
        public DataSet queryUserName(string UserID)
        {
            return dui.queryUserName(UserID);
        }
        public bool ExistUser(string UserName)
        {
            return dui.ExistUser(UserName);
        }
        public DataSet GetUserNumberByUserName(string UserName)
        {
            return dui.GetUserNumberByUserName(UserName);
        }
        #endregion BasicMethod
    }
}
