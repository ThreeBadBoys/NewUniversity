using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class ManagerDB : UserDB
    {
<<<<<<< HEAD
        public ManagerDB(string fileName) : base(fileName) { }
=======
        public ManagerDB(string fileName) : base(fileName)
        {
        }

>>>>>>> 410909b55064670f5dd3e748fafc81ed47eecdb4

        public override int insertRecordToFile()
        {
            throw new NotImplementedException();
        }

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

        public void newManager(string name, string family)
        {
            this.name = name;
            this.family = family;
            this.Name = name + " " + family;
            this.password = ID + "";
        }
    }
}
