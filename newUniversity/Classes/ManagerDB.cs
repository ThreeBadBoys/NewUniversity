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
        public ManagerDB(string fileName) : base(fileName)
        {
        }

        public override void getByID(int id)
        {
            throw new NotImplementedException();
        }

        public override void getByName(string Name)
        {
            throw new NotImplementedException();
        }

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

        public void newStudent(string name, string family)
        {
            this.name = name;
            this.family = family;
            this.password = ID + "";
        }
    }
}
