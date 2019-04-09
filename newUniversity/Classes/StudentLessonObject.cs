using System;
namespace newUniversity.Classes
{
    [Serializable]
    class StudentLessonObject : LessonObject
    {
        public int grade;

        public StudentLessonObject(string title, short unitsCount, int courseID, int studentID, int grade)
        {
            CourseObject course = Universal.instance.courses.getByID(courseID) as CourseObject;
            this.title = title;
            this.name = title;
            this.unitsCount = unitsCount;
            this.masterID = course.masterID;
            this.ID = int.Parse(studentID+""+courseID);
            this.grade = grade;
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
