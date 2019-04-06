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
                
                Universal.instance.courses.delete(course);
                Universal.instance.courses.save();
                return true;
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
                    return true;
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
                return true;
            }
            else
                throw new NotFoundException("entered course ID was not selected recently!");
        }
    

        public bool addStudent(string name, string family, string field)
        {
        if (name != null && family != null && field != null)
        {
            var student = new StudentObject(name, family, field);
            Universal.instance.students.insert(student);
            Universal.instance.students.save();
            return true;
        }
        else
            return false;
        }

        public bool addMaster(string name, string family, string field)
        {
        if (name != null && family != null && field != null)
        {
            var master = new MasterObject(name, family, field);
            Universal.instance.masters.insert(master);
            Universal.instance.masters.save();
            return true;
            }
        else
            return false;

        }

        public bool addManager(string name, string family)
        {
        if (name != null && family != null)
        {
            var manager = new ManagerObject(name, family);
            Universal.instance.managers.insert(manager);
            Universal.instance.managers.save();
            return true;
        }
        else
            return false;
        }


    }
}
