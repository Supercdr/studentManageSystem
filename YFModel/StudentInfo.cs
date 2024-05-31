using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDM.Model
{

    [Serializable]
    public class StudentInfo
    {
        public int UserID { get => _UserID; set => _UserID = value; }
        public string UserName { get => _UserName; set => _UserName = value; }
        public string UserSex { get => _UserSex; set => _UserSex = value; }
        public string UserNumber { get => _UserNumber; set => _UserNumber = value; }
        public string UserPass { get => _UserPass; set => _UserPass = value; }
        public string UserXy { get => _UserXy; set => _UserXy = value; }
        public string UserZy { get => _UserZy; set => _UserZy = value; }
        public string UserBj { get => _UserBj; set => _UserBj = value; }
        public string UserAddTime { get => _UserAddTime; set => _UserAddTime = value; }
        public string UserAddress { get => _UserAddress; set => _UserAddress = value; }

        private int _UserID;

        private string _UserName;

        private string _UserSex;

        private string _UserNumber;

        private string _UserPass;

        private string _UserXy;

        private string _UserZy;

        private string _UserBj;

        private string _UserAddTime;
        
        private string _UserAddress;

    }
}
