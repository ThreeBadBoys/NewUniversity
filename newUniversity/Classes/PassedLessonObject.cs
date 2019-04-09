using System;
namespace newUniversity.Classes
{
    [Serializable]
    class PassedLessonObject : LessonObject
    {
        public int grade;

        public PassedLessonObject(string title, short unitsCount, int courseID, int studentID, int grade)
        {
            CourseObject course = Universal.instance.courses.getByID(courseID) as CourseObject;
            this.title = title;
            this.name = title;
            this.unitsCount = unitsCount;
            this.masterID = course.masterID;
            this.ID = int.Parse(studentID+""+courseID);
            this.grade = grade;
        }

        public PassedLessonObject()
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
