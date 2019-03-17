using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    abstract class UserDB : Database
    {
        public string password;
        public string name;
        public string family;

        public UserDB(string fileName) : base(fileName) { }
    }
}
