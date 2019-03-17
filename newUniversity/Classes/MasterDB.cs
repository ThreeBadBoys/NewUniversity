using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class MasterDB : UserDB
    {
        public string field;
        public List<int> courses;

        public MasterDB(string fileName) : base(fileName) { }

<<<<<<< HEAD
        public override int insertRecordToFile()
        {
            throw new NotImplementedException();
        }

=======
 
>>>>>>> 410909b55064670f5dd3e748fafc81ed47eecdb4

        public override int insertRecordToFile(int index)
        {
            throw new NotImplementedException();
        }

        public override void loadRecordFromFile(int index)
        {
            throw new NotImplementedException();
        }

        public override void loadRecordFromFile(FileStream file, int index)
        {
            throw new NotImplementedException();
        }

        public void newMaster(string name, string family)
        {
            this.name = name;
            this.family = family;
            this.Name = name + " " + family;
            this.password = ID + "";
            this.courses = new List<int>();
        }
    }
}
