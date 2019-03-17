using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class CourseDB : Database
    {
        public string title;
        public short unitsCount;
        public int masterID;
        public List<int> studentsID;

        public CourseDB(string fileName) : base(fileName)
        {
        }

        public override void loadRecordFromFile(int index)
        {
            throw new NotImplementedException();
        }


        public override int insertRecordToFile(int index)
        {
            throw new NotImplementedException();
        }

        public override int insertRecordToFile()
        {
            throw new NotImplementedException();
        }

        public override Database getByID(int id)
        {
            return null;
        }

        public override Database getByName(string Name)
        {
            return null;

        }

        public void newCourse(string title, short unitsCount, int masterID)
        {
            this.title = title;
            this.Name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.studentsID = new List<int>();
        }

        public override void loadRecordFromFile(FileStream file, int index)
        {
            throw new NotImplementedException();
        }

    }
}
