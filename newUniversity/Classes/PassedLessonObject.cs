namespace newUniversity.Classes
{
    class PassedLessonObject : LessonObject
    {
        public int grade;

        public PassedLessonObject(string title, short unitsCount, int masterID, int grade)
        {
            this.title = title;
            //this.Name = title;
            this.unitsCount = unitsCount;
            this.masterID = masterID;
            this.grade = grade;
        }
    }
}
