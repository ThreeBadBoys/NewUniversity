using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace newUniversity.Classes
{
    class Manager : User
    {
        public bool removeCourse(int courseID)
        {
            var course = Universal.instance.courses.getByID(courseID);
            if (course == null)
                throw new NotFoundException("entered courseId not exists!");
            else
            {
                
                Universal.instance.courses.delete();

            }


        }

        public bool chooseCourse(StudentObject student , int courseID)
        {
            try
            {
                var course = Universal.instance.courses.getByID(courseID);
                if (student.currentSemisterCourses.Contains(courseID))
                    throw new DuplicateException("entered course ID recently selected!");
                else
                {
                    student.currentSemisterCourses.Add(courseID);
                    Universal.instance.students.loadObject(student);
                    Universal.instance.students.save();
                    course.studentsID.Add(student.ID);
                    Universal.instance.courses.loadObject(course);
                    Universal.instance.courses.save();
                }
            }
            catch (NotFoundException)
            {
                throw new NotFoundException("entered course ID not exists!");
            }
        }

        public bool deleteCourse(StudentObject student, int courseID)
        {
            if (student.currentSemisterCourses.Contains(courseID))
            {
                student.currentSemisterCourses.Remove(courseID);
                Universal.instance.students.loadObject(student);
                Universal.instance.students.save();
                CourseObject course = Universal.instance.courses.getByID(courseID);
                course.studentsID.Remove(student.ID);
                Universal.instance.courses.loadObject(course);
                Universal.instance.courses.save();
            }
            else
                throw new NotFoundException("entered course ID was not selected recently!");
        }
    

        public bool addStudent(string name, string family, string field, string password)
        {
        if (name != null && family != null && field != null)
        {
            var student = new StudentObject(name, family, field);
            Universal.instance.students.insert(student);
            return true;
        }
        else
            return false;
        }

        public bool addMaster(string name, string family, string field, string password)
        {
        if (name != null && family != null && field != null)
        {
            var master = new MasterObject(name, family, field);
            Universal.instance.masters.insert(master);
            return true;
            }
        else
            return false;

        }

        public bool addManager(string name, string family, string password)
        {
        if (name != null && family != null)
        {
            var manager = new ManagerObject(name, family);
            Universal.instance.managers.insert(manager);
            return true;
        }
        else
            return false;
        }


    }
}
