﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    [Serializable]
    public class StudentObject : UserObject
    {
        public List<int> passedLessons;
        public List<int> currentSemisterCourses;
        char[] Field = new char[20];
        public int passedUnits;
        public string field
        {
            get
            {
                string temp = "";
                for (int i = 0; i < Field.Length; i++)
                {
                    if (Field[i] != '\0')
                        temp += Field[i];
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
                    Field[i] = value[i];
                }
                Field[i] = '\0';
            }
        }

        public StudentObject(string name, string family, string field)
        {
            ID = int.Parse(Universal.instance.students.getLastID()) + 1;
            firstName = name;
            lastName = family;
            this.field = field;
            this.name = name + " " + family;
            password = ID + "";
            currentSemisterCourses = new List<int>(20);
            passedLessons = new List<int>(100);
        }

        public StudentObject()
        {
            ID = 0;
            firstName = "";
            lastName = "";
            field = "";
            name = "";
            password = ID + "";
            currentSemisterCourses = new List<int>(20);
            passedLessons = new List<int>(100);
        }
    }
}
