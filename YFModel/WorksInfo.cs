using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Model
{
    public class WorksInfo
    {
        public WorksInfo() { }
        private int _WorkID;

        private int _UserID;

        private string _WorkName;
        
        private string _WorkCate;

        private string _WorkDes;

        private string _WorkTime;

        private string _WorkUrl;

        private string _WorkPicUrl;

        public int WorkID { get => _WorkID; set => _WorkID = value; }
        public int UserID { get => _UserID; set => _UserID = value; }
        public string WorkName { get => _WorkName; set => _WorkName = value; }
        public string WorkCate { get => _WorkCate; set => _WorkCate = value; }
        public string WorkDes { get => _WorkDes; set => _WorkDes = value; }
        public string WorkTime { get => _WorkTime; set => _WorkTime = value; }
        public string WorkUrl { get => _WorkUrl; set => _WorkUrl = value; }
        public string WorkPicUrl { get => _WorkPicUrl; set => _WorkPicUrl = value; }
    }
}
