using System;
using System.Collections.Generic;

namespace newUniversity.Classes
{
    [Serializable]
    class CourseObject : LessonObject
    {
        public List<int> studentsID;
        
        public CourseObject(int id,  string title, short unitsCount, int masterID)
        {
            this.ID = id;
            this.title = title;
            this.name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            studentsID = new List<int>(50);
        }

        public CourseObject()
        {
            //create temp object
            this.ID = 0;
            this.title = "";
            this.name = "";
            this.unitsCount = 0;
            this.masterID = 0;
            studentsID = new List<int>(50);
        }
    }
}
