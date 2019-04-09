using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    public class User
    {
        static public void changePassword(StudentObject user, string currentPassword, string newPassword, string confirmPassword)
        {
            if (currentPassword != user.password)
                throw new InvalidPasswordException("entered password is not valid!");
            else if (currentPassword != confirmPassword)
                throw new InvalidPasswordException("entered password for confirm is not valid!");
            else
                user.password = newPassword;
            Universal.instance.students.loadObject(user);
            Universal.instance.students.save();
        }

        static public void changePassword(ManagerObject user, string currentPassword, string newPassword, string confirmPassword)
        {
            if (currentPassword != user.password)
                throw new InvalidPasswordException("entered password is not valid!");
            else if (currentPassword != confirmPassword)
                throw new InvalidPasswordException("entered password for confirm is not valid!");
            else
                user.password = newPassword;
            Universal.instance.managers.loadObject(user);
            Universal.instance.managers.save();
        }

        static public void changePassword(MasterObject user, string currentPassword, string newPassword, string confirmPassword)
        {
            if (currentPassword != user.password)
                throw new InvalidPasswordException("entered password is not valid!");
            else if (currentPassword != confirmPassword)
                throw new InvalidPasswordException("entered password for confirm is not valid!");
            else
                user.password = newPassword;
            Universal.instance.masters.loadObject(user);
            Universal.instance.masters.save();
        }

        static public void deleteUser(StudentObject user)
        {
            Universal.instance.students.delete(user);
            Universal.instance.students.save();
        }

        static public void deleteUser(ManagerObject user)
        {
            Universal.instance.managers.delete(user);
            Universal.instance.managers.save();
        }

        static public void deleteUser(MasterObject user)
        {
            Universal.instance.masters.delete(user);
            Universal.instance.masters.save();
        }

        static public string toString(UserObject user)
        {
            return user.ID + ";" + user.firstName + " " + user.lastName;
        }

        static public StudentObject[] allStudents()
        {
            return (Universal.instance.students.getAll().ToArray() as StudentObject[]);
        }

        static public MasterObject[] allMasters()
        {
            return (Universal.instance.masters.getAll().ToArray() as MasterObject[]);
        }

        static public ManagerObject[] allManagers()
        {
            return (Universal.instance.managers.getAll().ToArray() as ManagerObject[]);
        }
    }
}
