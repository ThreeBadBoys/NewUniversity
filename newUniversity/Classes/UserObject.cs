using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    abstract class UserObject
    {
        public int ID = 0;
        protected string Name = null;
        char[] Password = new char[20];
        public string password
        {
            get
            {
                string temp = "";
                for (int i = 0; i < Password.Length; i++)
                {
                    if (Password[i] != '\0')
                        temp += Password[i];
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
                    Password[i] = value[i];
                }
                Password[i] = '\0';
            }
        }

        char[] FirstName = new char[20];
        public string firstName
        {
            get
            {
                string temp = "";
                for (int i = 0; i < FirstName.Length; i++)
                {
                    if (FirstName[i] != '\0')
                        temp += FirstName[i];
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
                    FirstName[i] = value[i];
                }
                FirstName[i] = '\0';
            }
        }

        public char[] LastName = new char[20];
        public string lastName
        {
            get
            {
                string temp = "";
                for (int i = 0; i < LastName.Length; i++)
                {
                    if (LastName[i] != '\0')
                        temp += LastName[i];
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
                    LastName[i] = value[i];
                }
                LastName[i] = '\0';
            }
        }
    }
}
