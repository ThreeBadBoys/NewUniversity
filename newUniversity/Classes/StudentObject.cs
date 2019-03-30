using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class StudentObject : UserObject
    {
        public string field;
        public List<int> passedLessons;
        public List<int> currentSemisterCourses;

        public StudentObject(string name, string family, string field)
        {
            this.name = name;
            this.family = family;
            this.field = field;
            this.Name = name + " " + family;
            this.password = ID + "";
            this.passedLessons = new List<int>();
            this.currentSemisterCourses = new List<int>();
        }
    }
}
