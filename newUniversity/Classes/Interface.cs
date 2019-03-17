using System;
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
<<<<<<< HEAD
                ManagerDB manager = Universal.instance.managers.getByID(Convert.ToInt32(userName)) as ManagerDB;
                if (manager.password.Equals(password))
                    return true;
                return false;
=======
                //ManagerDB manager = University.instance.managers.getByID(Convert.ToInt32(userName));
                //if (manager.password.Equals(password))
                  //  return true;
                //return false;
>>>>>>> 410909b55064670f5dd3e748fafc81ed47eecdb4
            }
            else if (usertype.Equals("Master"))
            {
                MasterDB master = Universal.instance.masters.getByID(Convert.ToInt32(userName)) as MasterDB;
                if (master.password.Equals(password))
                    return true;
                return false;
            }
            else
            {
                StudentDB student = Universal.instance.students.getByID(Convert.ToInt32(userName)) as StudentDB;
                if (student.password.Equals(password))
                    return true;
                return false;
            }
        }
    }
}
