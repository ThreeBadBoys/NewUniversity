﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class StudentObject : UserObject
    {
        public int[] passedLessons = new int[70];
        public int[] currentSemisterCourses = new int[20];
        char[] Field = new char[20];
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
            this.firstName = name;
            this.lastName = family;
            this.field = field;
            this.Name = name + " " + family;
            this.password = ID + "";
        }
    }
}
