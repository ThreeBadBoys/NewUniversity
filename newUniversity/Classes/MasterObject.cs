using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    [Serializable]
    public class MasterObject : UserObject
    {
        char[] Field = new char[20];
        public List<int> courses;

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

        public MasterObject(string name, string family, string field)
        {
            ID = int.Parse(Universal.instance.masters.getLastID()) + 1;
            firstName = name;
            lastName = family;
            this.field = field;
            this.name = name + " " + family;
            password = ID + "";
            courses = new List<int>(20);
        }

        public MasterObject()
        {
            ID = 0;
            firstName = "";
            lastName = "";
            field = "";
            name = "";
            password = ID + "";
            courses = new List<int>(20);
        }
    }
}
