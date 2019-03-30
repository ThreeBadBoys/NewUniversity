using System.Collections.Generic;

namespace newUniversity.Classes
{
    class CourseObject : LessonObject
    {
        public List<int> studentsID;
        
        public CourseObject(string title, short unitsCount, int masterID)
        {
            this.title = title;
            this.Name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.studentsID = new List<int>();
        }
    }
}
