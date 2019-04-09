using System;
using System.Collections.Generic;

namespace newUniversity.Classes
{
    [Serializable]
  public  class CourseObject : LessonObject
    {
        public List<int> studentsID;
        public string examDate;
        public string examTime;
        public string courseTime;
        public string classDays;

        public CourseObject(int id,  string title, short unitsCount, int masterID, string examDate, string examTime, string courseTime, string classDays)
        {
            ID = id;
            this.title = title;
            name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            studentsID = new List<int>(50);
            this.examDate = examDate;
            this.examTime = examTime;
            this.courseTime = courseTime;
            this.classDays = classDays;
        }

        public CourseObject()
        {
            //create temp object
            ID = 0;
            title = "";
            name = "";
            unitsCount = 0;
            masterID = 0;
            studentsID = new List<int>(50);
            examDate = "";
            examTime = "";
            courseTime = "";
            classDays = "";
        }
    }
}
