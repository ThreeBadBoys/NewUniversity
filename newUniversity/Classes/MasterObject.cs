using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class MasterObject : UserObject
    {
        public string field;
        public List<int> courses;
        
        public MasterObject(string name, string family, string field)
        {
            this.Firstname = name;
            this.Lastname = family;
            this.field = field;
            this.Name = name + " " + family;
            this.password = ID + "";
            this.courses = new List<int>();
        }
    }
}
