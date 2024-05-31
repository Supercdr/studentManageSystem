using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;

namespace SDM.BLL
{
    public class StudentsInfo
    {
        private readonly SDM.DAL.StudentsInfo stu = new SDM.DAL.StudentsInfo();
        public StudentsInfo() { }
        #region BasicMethod
        public bool Exists(string UserNumber)
        {
            return stu.Exists(UserNumber);
        }
        public int Add(SDM.Model.StudentInfo model)
        {
            return stu.Add(model);
        }
        public bool Update(SDM.Model.StudentInfo model)
        {
            return stu.Update(model);
        }

        public bool Delete(int UserID)
        {
            return stu.Delete(UserID);
        }
        public SDM.Model.StudentInfo GetModel(int UserID)
        {
            return stu.GetModel(UserID);
        }
        public DataSet GetListByPage(string where, string orderBy, int startIndex, int endIndex)
        {
            return stu.GetListByPage(where, orderBy, startIndex, endIndex);
        }

        public DataSet GetStudentListByUserName(string UserName)
        {
            return stu.GetStudentListByUserName(UserName);
        }

        public DataSet GetStudentListByUserXy(string UserXy)
        {
            return stu.GetStudentListByUserXy(UserXy);
        }

        public int GetRecordCount(string strWhere)
        {
            return stu.GetRecordCount(strWhere);
        }

        #endregion BasicMethod
        #region ExtensionMethod
        public DataSet GetLogin(string strName, string strPass)
        {
            return stu.GetLogin(strName, strPass);
        }
        #endregion ExtensionMethod
    }
}
