using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    public class ManagerObject : UserObject
    {
        public ManagerObject(string name, string family)
        {
            this.firstName = name;
            this.lastName = family;
            this.Name = name + " " + family;
            this.password = ID + "";
        }
    }
}
