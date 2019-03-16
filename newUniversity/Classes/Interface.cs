using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University.Classes
{
    class Interface
    {
        static Universal uni;

        public static bool authentication(string usertype, string userName, string password)
        {
            if (usertype.Equals("Manager"))
            {
                ManagerDB manager = Universal.instance.managers.getByID(Convert.ToInt32(userName)) as ManagerDB;
                if (manager.password.Equals(password))
                    return true;
                return false;
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
