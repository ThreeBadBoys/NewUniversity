﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Interface
    {
        static University uni;

        public static bool authentication(string usertype, string userName, string password)
        {
            if (usertype.Equals("Manager"))
            {
                //ManagerDB manager = University.instance.managers.getByID(Convert.ToInt32(userName));
                //if (manager.password.Equals(password))
                  //  return true;
                //return false;
            }

            return true;
        }
    }
}
