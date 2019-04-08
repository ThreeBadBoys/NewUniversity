using System;
using System.Collections.Generic;

namespace newUniversity.Classes
{
    [Serializable]
    class LessonObject : DatabaseObject
    {
        char[] Title = new char[20];
        public string title
        {
            get
            {
                string temp = "";
                for (int i = 0; i < Title.Length; i++)
                {
                    if (Title[i] != '\0')
                        temp += Title[i];
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
                    Title[i] = value[i];
                }
                Title[i] = '\0';
            }
        }
        public short unitsCount;
        public int masterID;
    }
}
