﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    public static class Interface
    {
        //DEFAULT-------------------------------------------------------------------------------------
        public static bool changeUserPassword(object user, string currentPassword,
           string newPassword, string confirmationPassword, string type)
        {

            throw new NotImplementedException();
        }

        //LOGIN--------------------------------------------------------------------------------------
        public static bool authentication(string usertype, string userName, string password)
        {
            //  try
            // {
            //    Universal u = new Universal();
            //    if (usertype.Equals("Manager"))
            //    {
            //        ManagerObject manager = Universal.instance.managers.getByID(Convert.ToInt32(userName)) as ManagerObject;
            //        if (manager.password.Equals(password))
            //            return manager;
            //        return null;
            //    }
            //    else if (usertype.Equals("Master"))
            //    {
            //        MasterObject master = Universal.instance.masters.getByID(Convert.ToInt32(userName)) as MasterObject;
            //        if (master.password.Equals(password))
            //            return master;
            //        return null;
            //    }
            //    else
            //    {
            //        StudentObject student = Universal.instance.students.getByID(Convert.ToInt32(userName)) as StudentObject;
            //        if (student.password.Equals(password))
            //            return student;
            //        return null;
            //    }

            //}
            //catch (NotFoundException)
            //{
            //    return null;
            //}
            return true;
        }

        //MANAGER------------------------------------------------------------------------------------
        public static bool createNewUser(string userType, string firstName, string lastName, string major)
        {
            switch (userType)
            {
                case "Manager":
                    return Manager.addManager(firstName, lastName);
                case "Master":
                    return Manager.addMaster(firstName, lastName, major);
                case "Student":
                    return Manager.addStudent(firstName, lastName, major);
            }
            throw new Exception("It shouldn't reach here : " + userType);
        }
        public static bool createNewCourse(string crsName, string crsId, string masterID, string crsUnit, string examDate, string examTime)
        {
            throw new NotImplementedException();
        }
        public static bool removeUserCompletely(string userType, string userId)
        {
            throw new NotImplementedException();
        }
        public static bool removeStudentTerm(string stdId)
        {
            throw new NotImplementedException();
        }
        public static bool removeCourseCompletely(string crsID)
        {
            throw new NotImplementedException();
        }
        public static bool removeCourseForStudent(string studentId, string crsID)
        {
            throw new NotImplementedException();
        }
        public static bool controllingUnitChoice(bool isUnitChoiceActive, bool isAddRemoveActive)
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
        //MASTER--------------------------------------------------------------------------------------
        public static bool removeCourseMaster(string crsID)
        {
            throw new NotImplementedException();
        }
        public static bool addClass(
            object manager,
            string courseName,
            string courseId,
            string UnitNO,
            string examDate,
            string examTime,
            string courseTime,
            string classDays
            )
        {
            throw new NotImplementedException();
        }

        public static List<CourseObject> getAllClasses(object o)
        {
            throw new  NotImplementedException();
        }


        //STUDENT-------------------------------------------------------------------------------------







    }
}
