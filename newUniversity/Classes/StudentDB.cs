﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class StudentDB : UserDB
    {
        public string field;
        public List<int> passedCourses;
        public List<int> currentSemister;

        public StudentDB(string fileName) : base(fileName) { }

        public override int insertRecordToFile()//ADD
        {
          return FileController.Add<StudentDB>(this.IDTree, this, this.ID, this.getFileName());
        }

        public override int insertEdittedRecordToFile(int index)//EDIT
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
            this.Name = name + " " + family;
            this.password = ID + "";
            this.passedCourses = new List<int>();
            this.currentSemister = new List<int>();
        }
    }
}
