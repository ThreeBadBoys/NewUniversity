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
            this.ID = int.Parse(Universal.instance.managers.getLastID()) + 1;
            this.firstName = name;
            this.lastName = family;
            this.name = name + " " + family;
            this.password = ID + "";
        }
    }
}
