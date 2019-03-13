﻿using System;
using System.Collections.Generic;
using System.IO;

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

        public override void getByID(int id)
        {
            
        }

        public override void getByName(string Name)
        {
            
        }

        public override void save()
        {
            
        }

        public void newCourse(string title, short unitsCount, int masterID)
        {
            this.title = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.studentsID = new List<int>();
        }

        public override void loadRecordFromFile(int index)
        {
            throw new NotImplementedException();
        }

        public override void loadRecordFromFile(FileStream file, int index)
        {
            throw new NotImplementedException();
        }

        public override int insertRecordToFile()
        {
            throw new NotImplementedException();
        }
    }
}