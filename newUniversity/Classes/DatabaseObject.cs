using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class DatabaseObject
    {
        public int ID = 0;
        char[] Name = new char[50];

        public string name
        {
            get
            {
                string temp = "";
                for (int i = 0; i < Name.Length; i++)
                {
                    if (Name[i] != '\0')
                        temp += Name[i];
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
                    Name[i] = value[i];
                }
                Name[i] = '\0';
            }
        }
    }
}
