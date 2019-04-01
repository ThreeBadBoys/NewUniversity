using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class User
    {
        public void changePassword(StudentObject user, string currentPassword, string newPassword, string confirmPassword)
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

        public void changePassword(ManagerObject user, string currentPassword, string newPassword, string confirmPassword)
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

        public void changePassword(MasterObject user, string currentPassword, string newPassword, string confirmPassword)
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

        public string toString(UserObject user)
        {
            return user.ID + ";" + user.firstName + " " + user.lastName;
        }
    }
}
