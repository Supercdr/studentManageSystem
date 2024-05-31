using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SDM.BLL
{
    public class WorksInfo
    {
        private readonly SDM.DAL.WorksInfo work = new SDM.DAL.WorksInfo();
        public WorksInfo() { }
        #region BasicMethod
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public int Add(SDM.Model.WorksInfo model)
        {
            return work.Add(model);
        }

        public bool Exists(int WorkID)
        {
            return work.Exists(WorkID);
        }
        public bool Update(SDM.Model.WorksInfo model)
        {
            return work.Update(model);
        }
        public bool Delete(int WorkID)
        {
            return work.Delete(WorkID);
        }
        public SDM.Model.WorksInfo GetModel(int WorkID)
        {
            return work.GetModel(WorkID);
        }

        public DataSet GetListByPage(string where, string order, int min, int max)
        {
            return work.GetListByPage(where, order, min, max);
        }

        public DataSet GetListByPage(int userid, string order, int min, int max)
        {
            return work.GetListByPage(userid, order, min, max);
        }

        public int GetRecordCount(string where)
        {
            return work.GetRecordCount(where);
        }

        public int GetUserIDByWorkID(string WorkID)
        {
            return work.GetUserIDByWorkID(WorkID);
        }

        #endregion BasicMethod

    }
}
