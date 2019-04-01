using System.Collections.Generic;

namespace newUniversity.Classes
{
    class CourseObject : LessonObject
    {
        public List<int> studentsID;
        
        public CourseObject(int id,  string title, short unitsCount, int masterID)
        {
            this.ID = id;
            this.title = title;
            this.Name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.studentsID = new List<int>();
        }
    }
}
