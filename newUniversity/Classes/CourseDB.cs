using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Classes
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

        public override void loadRecordFromFile(FileStream file, int index)
        {
            throw new NotImplementedException();
        }

        public override int insertRecordToFile(int index)
        {
            throw new NotImplementedException();
        }

        public override void getByID(int id)
        {
            
        }

        public override void getByName(string Name)
        {
            
        }

        public void newCourse(string title, short unitsCount, int masterID)
        {
            this.title = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.studentsID = new List<int>();
        }

      
    }
}
