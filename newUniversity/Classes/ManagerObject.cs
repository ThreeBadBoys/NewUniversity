using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    [Serializable]
    public class ManagerObject : UserObject
    {
        public ManagerObject(string name, string family)
        {
            ID = int.Parse(Universal.instance.managers.getLastID()) + 1;
            firstName = name;
            lastName = family;
            this.name = name + " " + family;
            password = ID + "";
        }
        public ManagerObject()
        {
            ID = 98000;
            firstName = "admin";
            lastName = "admin";
            name = "admin" + " " + "admin";
            password = ID + "";
        }
    }
}
