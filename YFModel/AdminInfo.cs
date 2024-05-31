using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Model
{
    public class AdminInfo
    {
        public AdminInfo() { }
        #region Model
        //下划线表示私有字段
        private int _adminid;
        private string _adminname;
        private string _adminpass;

        public int AdminID { get => _adminid; set => _adminid = value; }
        public string AdminName { get => _adminname; set => _adminname = value; }
        public string AdminPass { get => _adminpass; set => _adminpass = value; }
        #endregion Model
    }
}
