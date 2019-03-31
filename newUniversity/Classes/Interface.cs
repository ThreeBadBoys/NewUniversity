using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Interface
    {
      //  static Universal uni;

        public static bool authentication(string usertype, string userName, string password)
        {
            //if (usertype.Equals("Manager"))
            //{
            //    ManagerObject manager = Universal.instance.managers.getByID(Convert.ToInt32(userName)) as ManagerObject;
            //    if (manager.password.Equals(password))
            //        return true;
            //    return false;
            //}
            //else if (usertype.Equals("Master"))
            //{
            //    MasterObject master = Universal.instance.masters.getByID(Convert.ToInt32(userName)) as MasterObject;
            //    if (master.password.Equals(password))
            //        return true;
            //    return false;
            //}
            //else
            //{
            //    StudentObject student = Universal.instance.students.getByID(Convert.ToInt32(userName)) as StudentObject;
            //    if (student.password.Equals(password))
            //        return true;
            //    return false;
            //}
            return true;
        }
    }
}
