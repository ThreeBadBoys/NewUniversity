using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace newUniversity.Classes
{
    public static class Interface
    {
        //DEFAULT-------------------------------------------------------------------------------------
        //Change The users Password according the type of the user
        public static void changeUserPassword(object user, string currentPassword,
           string newPassword, string confirmationPassword, string type)
        {
            switch (type)
            {
                case "Manager":
                    Manager.changePassword(user as ManagerObject, currentPassword, newPassword, confirmationPassword);
                    break;

                case "Master":
                    Master.changePassword(user as MasterObject, currentPassword, newPassword, confirmationPassword);
                    break;

                case "Student":
                    Student.changePassword(user as StudentObject, currentPassword, newPassword, confirmationPassword);
                    break;
            }
        }

        //LOGIN--------------------------------------------------------------------------------------
        public static object authentication(string usertype, string userName, string password)
        {
            try
            {
                Universal u = new Universal();
                if (usertype.Equals("Manager"))
                {
                    ManagerObject manager = Universal.instance.managers.getByID(Convert.ToInt32(userName)) as ManagerObject;
                    if (manager.password.Equals(password))
                        return manager;
                    return null;
                }
                else if (usertype.Equals("Master"))
                {
                    MasterObject master = Universal.instance.masters.getByID(Convert.ToInt32(userName)) as MasterObject;
                    if (master.password.Equals(password))
                        return master;
                    return null;
                }
                else
                {
                    StudentObject student = Universal.instance.students.getByID(Convert.ToInt32(userName)) as StudentObject;
                    if (student.password.Equals(password))
                        return student;
                    return null;
                }

            }
            catch (NotFoundException)
            {
                return null;
            }
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
        //
        public static bool createNewCourse(string crsName, string crsId, string masterID, string crsUnit, string examDate, string examTime)
        {
            throw new NotImplementedException();
        }

        //Deleting the User from the DataBase Completely
        public static void removeUserCompletely(string type, string userId)
        {
            switch (type)
            {
                case "Manager":
                    ManagerObject manager = Universal.instance.managers.getByID(int.Parse(userId)) as ManagerObject;
                    User.deleteUser(manager);
                    break;

                case "Master":
                    MasterObject master = Universal.instance.masters.getByID(int.Parse(userId)) as MasterObject;
                    User.deleteUser(master);
                    break;

                case "Student":
                    StudentObject student = Universal.instance.students.getByID(int.Parse(userId)) as StudentObject;
                    User.deleteUser(student);
                    break;
            }
        }
        
        //Removing the Student current Term
        public static void removeStudentTerm(string studentId)
        {
            StudentObject student = Universal.instance.students.getByID(int.Parse(studentId)) as StudentObject;
            Student.deleteTerm(student);
        }

        public static bool removeCourseCompletely(string crsID)
        {
            throw new NotImplementedException();
        }
        //Removing the Course from the student
        public static void removeCourseForStudent(string studentId, string crsID)
        {
            StudentObject student = Universal.instance.students.getByID(int.Parse(studentId)) as StudentObject;
            Student.deleteCourse(student, int.Parse(crsID));
        }
        public static void controllingUnitChoice(bool isUnitChoiceActive, bool isAddRemoveActive)
        {
            Universal.instance.isAbleUnitChoice = isUnitChoiceActive;
            Universal.instance.isAbleUnitEdit = isAddRemoveActive;
            FileStream file = File.Create("Uni");
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(file, Universal.instance);
            file.Close();
        }

        public static List<object> getAllStudents()//TODO
        {
            return User.allStudents();
        }

        public static List<object> getAllMasters()//TODO
        {
            return User.allMasters();
        }

        public static bool passTerm()
        {
            throw new NotImplementedException();
        }
        //MASTER--------------------------------------------------------------------------------------
        public static void removeCourseMaster(object master, string crsID)
        {
            Master.deleteCourse(master as MasterObject, int.Parse(crsID));
        }

        public static void addClass(
            object master,
            string courseTitle,
            string courseId,
            string UnitsCount,
            string examDate,
            string examTime,
            string courseTime,
            string classDays
            )
        {
            Master.addCourse(master as MasterObject, int.Parse(courseId), courseTitle, short.Parse(UnitsCount), examDate, examTime, courseTime, classDays);
        }

        //Getting the CourseObjects of the Master that chose
        public static List<object> getAllClasses(object mst)
        {
            return Master.getAllCourses(mst as MasterObject);
        }

        public static void insertGrade(object master,string courseID,string studentID,string grade)
        {
            Master.insertGrade(master, int.Parse(courseID), int.Parse(studentID), double.Parse(grade));
        }


        //STUDENT-------------------------------------------------------------------------------------

        public static List<object> chooseCourse(object std ,string courseId)
        {
            Student.chooseCourse(std as StudentObject, int.Parse(courseId));
            return Student.getCurrentCourses(Universal.instance.students.getByID((std as StudentObject).ID) as StudentObject);
        }

        //Getting the Student's current Term Courses
        public static List<object> getThisTermCourse(object std)
        {
            return Student.getCurrentCourses(std as StudentObject);
        }





    }
}
