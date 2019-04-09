using System;
using System.Collections.Generic;

namespace newUniversity.Classes
{
    [Serializable]
  public  class CourseObject : LessonObject
    {
        public List<int> studentsID;
        public char[] ExamDate = new char[10];
        public char[] ExamTime = new char[5];
        public char[] CourseTime = new char[20];
        public char[] ClassDays = new char[20];


        public string examDate
        {
            get
            {
                string temp = "";
                for (int i = 0; i < ExamDate.Length; i++)
                {
                    if (ExamDate[i] != '\0')
                        temp += ExamDate[i];
                    else
                        break;
                }
                return temp;
            }
            set
            {
                int i;
                for (i = 0; i < value.Length; i++)
                {
                    ExamDate[i] = value[i];
                }
                ExamDate[i] = '\0';
            }
        }

        public string examTime
        {
            get
            {
                string temp = "";
                for (int i = 0; i < ExamTime.Length; i++)
                {
                    if (ExamTime[i] != '\0')
                        temp += ExamTime[i];
                    else
                        break;
                }
                return temp;
            }
            set
            {
                int i;
                for (i = 0; i < value.Length; i++)
                {
                    ExamTime[i] = value[i];
                }
                ExamTime[i] = '\0';
            }
        }

        public string courseTime
        {
            get
            {
                string temp = "";
                for (int i = 0; i < CourseTime.Length; i++)
                {
                    if (CourseTime[i] != '\0')
                        temp += CourseTime[i];
                    else
                        break;
                }
                return temp;
            }
            set
            {
                int i;
                for (i = 0; i < value.Length; i++)
                {
                    CourseTime[i] = value[i];
                }
                CourseTime[i] = '\0';
            }
        }

        public string classDays
        {
            get
            {
                string temp = "";
                for (int i = 0; i < ClassDays.Length; i++)
                {
                    if (ClassDays[i] != '\0')
                        temp += ClassDays[i];
                    else
                        break;
                }
                return temp;
            }
            set
            {
                int i;
                for (i = 0; i < value.Length; i++)
                {
                    ClassDays[i] = value[i];
                }
                ClassDays[i] = '\0';
            }
        }
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
