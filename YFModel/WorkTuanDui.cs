using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Model
{
    public class WorkTuanDui
    {
        public WorkTuanDui() { }

        private int _WorkID;
        private string _tdmc;
        private int _UserID_1;
        private string _UserID_1_des;
        private int _UserID_2;
        private string _UserID_2_des;
        private int _UserID_3;
        private string _UserID_3_des;
        private string _WorkName;
        private string _WorkCate;
        private string _WorkDes;
        private string _WorkTime;
        private string _WorkUrl;
        private string _WorkPicUrl;

        public int WorkID { get => _WorkID; set => _WorkID = value; }
        public string tdmc { get => _tdmc; set => _tdmc = value; }
        public int UserID_1 { get => _UserID_1; set => _UserID_1 = value; }
        public string UserID_1_des { get => _UserID_1_des; set => _UserID_1_des = value; }
        public int UserID_2 { get => _UserID_2; set => _UserID_2 = value; }
        public string UserID_2_des { get => _UserID_2_des; set => _UserID_2_des = value; }
        public int UserID_3 { get => _UserID_3; set => _UserID_3 = value; }
        public string UserID_3_des { get => _UserID_3_des; set => _UserID_3_des = value; }
        public string WorkName { get => _WorkName; set => _WorkName = value; }
        public string WorkCate { get => _WorkCate; set => _WorkCate = value; }
        public string WorkDes { get => _WorkDes; set => _WorkDes = value; }
        public string WorkTime { get => _WorkTime; set => _WorkTime = value; }
        public string WorkUrl { get => _WorkUrl; set => _WorkUrl = value; }
        public string WorkPicUrl { get => _WorkPicUrl; set => _WorkPicUrl = value; }
    }
}
