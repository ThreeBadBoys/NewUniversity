using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
   public static class Interface
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

        public static bool createNewUser(string userType,string firstName,string lastName,string major)
        {
            throw new NotImplementedException();
        }
        public static bool createNewCourse(string crsName,string crsId,string masterID,string crsUnit,string examDate,string examTime)
        {
            throw new NotImplementedException();
        }
        public static bool removeUserCompletely(string userType,string userId)
        {
            throw new NotImplementedException();
        }
        public static bool removeStudentTerm(string stdId)
        {
            throw new NotImplementedException();
        }
        public static bool removeCourse(string crsID)
        {
            throw new NotImplementedException();
        }
        public static bool controllingUnitChoice(bool isUnitChoiceActive,bool isAddRemoveActive)
        {
            throw new NotImplementedException();
        }
        public static bool changeUserPassword(string userType,string currentPassword,
            string newPassword,string confirmationPassword)
        {
            switch (userType)
            {
                case "STUDENT":
                    changeStudentPassword(currentPassword, newPassword, confirmationPassword);
                    break;

                case "MASTER":
                    changeMasterPassword(currentPassword, newPassword, confirmationPassword);
                    break;

                case "MANAGER":
                    changManagerPassword(currentPassword, newPassword, confirmationPassword);
                    break;
            }

            throw new NotImplementedException();
        }
        public static bool changeStudentPassword(string currentPassword,
            string newPassword, string confirmationPassword)
        {
            throw new NotImplementedException();
        }

        public static bool changeMasterPassword(string currentPassword,
           string newPassword, string confirmationPassword)
        {
            throw new NotImplementedException();
        }
        public static bool changManagerPassword(string currentPassword,
         string newPassword, string confirmationPassword)
        {
            throw new NotImplementedException();
        }
        public static List<StudentObject> getAllStudents()//TODO
        {
            return null;
        }
        public static List<MasterObject> getAllMasters()//TODO
        {
            return null;
        }
        public static bool passTerm()
        {
            throw new NotImplementedException();
        }
    }
}
