using System;
namespace newUniversity.Classes
{
    [Serializable]
    public class StudentLessonObject : LessonObject
    {
        public double grade;

        public StudentLessonObject(CourseObject course, int studentID)
        {
            title = course.title;
            name = course.title;
            unitsCount = course.unitsCount;
            masterID = course.masterID;
            ID = int.Parse(studentID + "" + course.ID);
        }

        public StudentLessonObject()
        {
            title = "";
            name = "";
            unitsCount = 0;
            masterID = 0;
            ID = 0;
            grade = 0;
        }
    }
}
