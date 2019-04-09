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
            ID = int.Parse(courseId + student.ID + "");
        }

        public StudentLessonObject()
        {
            this.title = "";
            this.name = "";
            this.unitsCount = 0;
            this.masterID = 0;
            this.ID = 0;
            this.grade = 0;
        }
    }
}
